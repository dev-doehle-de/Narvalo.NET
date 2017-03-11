# PSakefile script.
# Requires the module 'Narvalo.ProjectAutomation'.
#

# We force the framework to be sure we use the v12.0 of the build tools.
# For instance, this is a requirement for the _MyGet-Publish target where
# the DeployOnBuild instruction is not understood by previous versions of MSBuild.
# TODO: Check if this is still necessary.
# NB: We could also use
#   Invoke-psake -framework '4.5.1x64' in make.ps1.
#Framework '4.5.1x64'
Framework '4.6.1x64'

# ------------------------------------------------------------------------------
# Properties
# ------------------------------------------------------------------------------

Properties {
    # Process mandatory parameters.
    Assert($Retail -ne $null) "`$Retail must not be null, e.g. run with -Parameters @{ 'retail' = `$true; }"

    # Process optional parameters.
    if ($Verbosity -eq $null) { $Verbosity = 'minimal' }

    # Define the NuGet verbosity level.
    $NuGetVerbosity = ConvertTo-NuGetVerbosity $Verbosity

    # MSBuild options.
    $Opts = '/nologo', "/verbosity:$Verbosity", '/maxcpucount', '/nodeReuse:false'

    # Main MSBuild projects.
    $Everything  = Get-LocalPath 'tools\Make.proj'
    $Foundations = Get-LocalPath 'tools\Make.Foundations.proj'

    # NuGet packages.
    # TODO: Make it survive NuGet updates.
    $OpenCoverVersion       = '4.6.519'
    $ReportGeneratorVersion = '2.5.1'
    $XunitVersion           = '2.1.0'

    $OpenCoverXml = Get-LocalPath 'work\log\opencover.xml'
}

FormatTaskName {
    param([Parameter(Mandatory = $true)] [string] $TaskName)

    Write-Host "Executing Task '$taskName'." -ForegroundColor DarkCyan
}

TaskTearDown {
    # Catch errors from both PowerShell and Win32 exe.
    if (!$?) {
        Exit-Gracefully -ExitCode 1 'Build failed.'
    }

    #if ($LastExitCode -ne 0) {
    #    Exit-Gracefully -ExitCode $LastExitCode 'Build failed.'
    #}
}

Task Default -Depends Build

# ------------------------------------------------------------------------------
# Continuous Integration and development tasks
# ------------------------------------------------------------------------------

# NB: No need to restore packages before building the projects $Everything
# or $Foundations; this will be done in MSBuild.

Task FullClean `
    -Description 'Delete permanently the "work" directory.' `
    -Alias Clean `
    -ContinueOnError `
{
    # Sometimes this task fails for some obscure reasons. Maybe the directory is locked?
    Remove-LocalItem 'work' -Recurse
}

Task Build `
    -Description 'Build.' `
    -Depends _CI-InitializeVariables `
{
    MSBuild $Everything $Opts $CI_Props '/t:Build'
}

Task Test `
    -Description 'Build then run tests.' `
    -Depends _CI-InitializeVariables `
{
    MSBuild $Everything $Opts $CI_Props `
        '/t:Xunit',
        '/p:Configuration=Debug',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true'
}

Task OpenCover `
    -Description 'Run OpenCover (summary only).' `
    -Depends _CI-InitializeVariables `
    -Alias Cover `
{
    # Use debug build to also cover debug-only tests.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:Configuration=Debug',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:Filter="_Core_;_Mvp_"'

    Invoke-OpenCover 'Debug'
    Invoke-ReportGenerator -Summary
}

Task OpenCoverVerbose `
    -Description 'Run OpenCover (full details).' `
    -Depends _CI-InitializeVariables `
    -Alias CoverVerbose `
{
    # Use debug build to also cover debug-only tests.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:Configuration=Debug',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:Filter="_Core_;_Mvp_"'

    Invoke-OpenCover 'Debug'
    Invoke-ReportGenerator
}

Task CodeAnalysis `
    -Description 'Build, analyze, then run PEVerify.' `
    -Depends _CI-InitializeVariables `
    -Alias CA `
{
    $output = Get-LocalPath 'work\log\code-analysis.log'

    # Perform the following operations:
    # - Build all projects
    # - Run Source Analysis
    # - Verify Portable Executable (PE) format
    # NB: For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    # NB: Adding Build to the targets is not necessary, but it makes clearer that
    # we do not just run PEVerify. In fact, we need to rebuild otherwise CA might fail.
    # NB: Removed '/p:SourceAnalysisEnabled=true' (replaced by StyleCop.Analyzers)
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Rebuild;PEVerify',
        '/p:Configuration=Debug',
        '/p:VisibleInternals=false',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:RunCodeAnalysis=true',
        '/p:Filter=_Analyze_' | Tee-Object -file $output
}

Task CodeContractsAnalysis `
    -Description 'Run Code Contracts Analysis.' `
    -Depends _CI-InitializeVariables `
    -Alias CC `
{
    $output = Get-LocalPath 'work\log\code-contracts.log'

    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:VisibleInternals=false',
        '/p:Configuration=CodeContracts',
        '/p:Filter=_CodeContracts_' | Tee-Object -file $output
}

Task SecurityAnalysis `
    -Description 'Run Security Analysis.' `
    -Depends _CI-InitializeVariables `
    -Alias SA `
{
    $output = Get-LocalPath 'work\log\security-analysis.log'

    # Keep the PEVerify target (see the comments in the MSBuild target _PEVerify).
    MSBuild $Foundations $Opts $CI_Props `
        '/t:SecAnnotate;PEVerify',
        # For static analysis, we hide internals, otherwise we might not truly
        # analyze the public API.
        '/p:VisibleInternals=false',
        '/p:SignAssembly=true',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:EnableSecurityAnnotations=true',
        '/p:Filter=_Security_' | Tee-Object -file $output
}

Task _CI-InitializeVariables `
    -Description 'Initialize variables only used by the CI tasks.' `
    -RequiredVariables Retail `
{
    # Default CI properties:
    # - Release configuration
    # - Do not generate assembly versions
    # - Do not sign assemblies
    # - Do not skip the generation of the Code Contracts reference assembly
    # - Leak internals to enable all white-box tests.
    # FIXME: CodeContracts disabled.
    $script:CI_Props = `
        '/p:Configuration=Release',
        '/p:BuildGeneratedVersion=false',
        "/p:Retail=$Retail",
        '/p:SignAssembly=false',
        '/p:SkipCodeContractsReferenceAssembly=false',
        '/p:VisibleInternals=true',
        '/p:EnableSecurityAnnotations=false'

    # FIXME: Don't understand why doing what follows does not work.
    # Either MSBuild or PowerShell mixes up the MSBuild parameters.
    # The result is that Configuration property takes all following properties
    # as its value. For instance, Configuration is read as "Release /p:BuildGeneratedVersion=false...".
    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    #$script:CI_AnalysisProps = $CI_Props, '/p:VisibleInternals=false'
}

# ------------------------------------------------------------------------------
# Packaging tasks
# ------------------------------------------------------------------------------

Task Package-Build `
    -Description 'Create the Narvalo.Build package.' `
    -Depends _Package-InitializeVariables `
    -Alias PackBuild `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Build_'
}

Task Package-Cerbere `
    -Description 'Create the package Narvalo.Cerbere.' `
    -Depends _Package-InitializeVariables `
    -Alias PackCerbere `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Cerbere_'
}

Task Package-Common `
    -Description 'Create the package Narvalo.Common.' `
    -Depends _Package-InitializeVariables `
    -Alias PackCommon `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Common_'
}

Task Package-Core `
    -Description 'Create the package Narvalo.Core.' `
    -Depends _Package-InitializeVariables `
    -Alias PackCore `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Core_'
}

Task Package-Finance `
    -Description 'Create the package Narvalo.Finance.' `
    -Depends _Package-InitializeVariables `
    -Alias PackFinance `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Finance_'
}

Task Package-Fx `
    -Description 'Create the package Narvalo.Fx.' `
    -Depends _Package-InitializeVariables `
    -Alias PackFx `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Fx_'
}

Task Package-Money `
    -Description 'Create the package Narvalo.Money.' `
    -Depends _Package-InitializeVariables `
    -Alias PackMoney `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Money_'
}

Task Package-Mvp `
    -Description 'Create the package Narvalo.Mvp.' `
    -Depends _Package-InitializeVariables `
    -Alias PackMvp `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Mvp_'
}

Task Package-MvpWeb `
    -Description 'Create the package Narvalo.Mvp.Web.' `
    -Depends _Package-InitializeVariables `
    -Alias PackMvpWeb `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_MvpWeb_'
}

Task Package-Web `
    -Description 'Create the package Narvalo.Web.' `
    -Depends _Package-InitializeVariables `
    -Alias PackWeb `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Web_'
}

Task _Package-InitializeVariables `
    -Description 'Initialize variables only used by the Package-* tasks.' `
    -Depends _Initialize-GitCommitHash, _Package-CheckVariablesForRetail `
    -RequiredVariables Retail `
{
    # Packaging properties:
    # - Release configuration
    # - Generate assembly versions (necessary for NuGet packaging)
    # - Sign assemblies
    # - Do not skip the generation of the Code Contracts reference assembly
    # - Unconditionally hide internals (implies no white-box testing)
    # FIXME: CodeContracts disabled.
    $script:Package_Props = `
        '/p:Configuration=Release',
        '/p:BuildGeneratedVersion=true',
        "/p:GitCommitHash=$GitCommitHash",
        "/p:Retail=$Retail",
        '/p:SignAssembly=true',
        '/p:SkipCodeContractsReferenceAssembly=false',
        '/p:VisibleInternals=false',
        '/p:EnableSecurityAnnotations=false'

    # Packaging targets:
    # - Rebuild all
    # - Verify Portable Executable (PE) format
    # - Run Xunit tests
    # - Package
    $script:Package_Targets = '/t:PEVerify;Xunit;Package'
}

Task _Package-CheckVariablesForRetail `
    -Description 'Check conditions are met for creating retail packages.' `
    -Depends _Initialize-GitCommitHash `
    -PreCondition { $Retail } `
{
    if ($GitCommitHash -eq '') {
        Exit-Gracefully -ExitCode 1 `
            'When building retail packages, the git commit hash MUST not be empty.'
    }
}

# ------------------------------------------------------------------------------
# Miscs
# ------------------------------------------------------------------------------

Task RestoreSolutionPackages `
    -Description 'Restore solution-level packages.' `
    -Alias restore `
{
    # Usually, it is not necessary to run this task, since it is already done in make.ps1.
    Restore-SolutionPackages -Verbosity quiet
}

Task _Initialize-GitCommitHash `
    -Description 'Initialize GitCommitHash.' `
{
    $git = (Get-Git)

    $hash = ''

    if ($git -ne $null) {
        $status = Get-GitStatus $git -Short

        if ($status -eq $null) {
            Write-Warning 'Skipping... unabled to verify the git status.'
        } elseif ($status -ne '') {
            Write-Warning 'Skipping... uncommitted changes are pending.'
        } else {
            $hash = Get-GitCommitHash $git
        }
    }

    $script:GitCommitHash = $hash
}

Task _Tools-InitializeVariables `
    -Description 'Initialize variables for the tooling projects.' `
{
    $script:Tools_PackagesDirectory = Get-LocalPath 'tools\packages'
    $script:Tools_NuGetConfig       = Get-LocalPath 'tools\.nuget\NuGet.Config'
}

# ------------------------------------------------------------------------------
# Functions
# ------------------------------------------------------------------------------

<#
.SYNOPSIS
    Convert a MSBuild verbosity level to a NuGet verbosity level.
.PARAMETER Verbosity
    Specifies the MSBuild verbosity.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function ConvertTo-NuGetVerbosity {
    param([Parameter(Mandatory = $true, Position = 0)] [string] $Verbosity)

    switch ($verbosity) {
        'q'          { return 'quiet' }
        'quiet'      { return 'quiet' }
        'm'          { return 'normal' }
        'minimal'    { return 'normal' }
        'n'          { return 'normal' }
        'normal'     { return 'normal' }
        'd'          { return 'detailed' }
        'detailed'   { return 'detailed' }
        'diag'       { return 'detailed' }
        'diagnostic' { return 'detailed' }

        default      { return 'normal' }
    }
}

# TODO: Should be a task.
function Invoke-OpenCover {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string] $Configuration
    )

    $opencover = Get-LocalPath "packages\OpenCover.$OpenCoverVersion\tools\OpenCover.Console.exe" -Resolve
    $xunit     = Get-LocalPath "packages\xunit.runner.console.$XunitVersion\tools\xunit.console.exe" -Resolve

    $filter = '+[Narvalo*]* -[*Facts]* -[Xunit.*]*'
    $excludeByAttribute = 'System.Runtime.CompilerServices.CompilerGeneratedAttribute;Narvalo.ExcludeFromCodeCoverageAttribute;System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute'

    $asm1 = Get-LocalPath "work\bin\$Configuration\Narvalo.Facts.dll" -Resolve
    $asm2  = Get-LocalPath "work\bin\$Configuration\Narvalo.Finance.Facts.dll" -Resolve
    $asm3  = Get-LocalPath "work\bin\$Configuration\Narvalo.Mvp.Facts.dll" -Resolve
    $asms = "$asm1 $asm2 $asm3"

    # Be very careful with arguments containing spaces.
    . $opencover `
      -register:user `
      "-filter:$filter" `
      "-excludebyattribute:$excludeByAttribute" `
      "-output:$OpenCoverXml" `
      "-target:$xunit"  `
      "-targetargs:$asms -nologo -noshadow"
}

# TODO: Should be a task.
function Invoke-ReportGenerator {
    [CmdletBinding()]
    param(
        [switch] $Summary
    )

    $reportgenerator = Get-LocalPath "packages\ReportGenerator.$ReportGeneratorVersion\tools\ReportGenerator.exe" -Resolve

    if ($summary.IsPresent) {
        $targetdir   = Get-LocalPath 'work\log'
        $filters     = '+*'
        $reporttypes = 'HtmlSummary'
    }
    else {
        $targetdir   = Get-LocalPath 'work\log\opencover'
        $filters     = '-Narvalo.Common;-Narvalo.Core;-Narvalo.Fx;-Narvalo.Mvp;-Narvalo.Mvp.Web;-Narvalo.Web'
        $reporttypes = 'Html'
    }

    . $reportgenerator `
        -verbosity:Info `
        -reporttypes:$reporttypes `
        "-filters:$filters" `
        -reports:$OpenCoverXml `
        -targetdir:$targetdir
}

# ------------------------------------------------------------------------------
