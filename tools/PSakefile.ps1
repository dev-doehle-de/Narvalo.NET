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
    if ($Developer -eq $null) { $Developer = $false }

    # Define the NuGet verbosity level.
    $NuGetVerbosity = ConvertTo-NuGetVerbosity $Verbosity

    # MSBuild options.
    $Opts = '/nologo', "/verbosity:$Verbosity", '/maxcpucount', '/nodeReuse:false'

    # Main MSBuild projects.
    $Everything  = Get-LocalPath 'tools\Make.proj'
    $Foundations = Get-LocalPath 'tools\Make.Foundations.proj'
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
    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:Configuration=Debug',
        '/p:VisibleInternals=false',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:Filter="_Core_;_Mvp_"'

    Invoke-OpenCover 'Debug+Closed' -Summary
}

Task OpenCoverVerbose `
    -Description 'Run OpenCover (full details).' `
    -Depends _CI-InitializeVariables `
    -Alias CoverVerbose `
{
    Write-Host "** WARNING ** Excluding some assemblies from the report." -ForegroundColor Yellow

    # Use debug build to also cover debug-only tests.
    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:Configuration=Debug',
        '/p:VisibleInternals=false',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:Filter=_Core_'

    Invoke-OpenCover 'Debug+Closed'
}

Task Analyze `
    -Description 'Build, analyze, then run PEVerify.' `
    -Depends _CI-InitializeVariables `
{
    $output = Get-LocalPath 'docs\engineering\code-analysis.txt'

    # Perform the following operations:
    # - Build all projects
    # - Run Source Analysis
    # - Verify Portable Executable (PE) format
    # NB: Adding Build to the targets is not necessary, but it makes clearer that
    # we do not just run PEVerify. In fact, we need to rebuild otherwise CA may
    # fail.
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
#Task SourceAnalysis `
#    -Description 'Run source analysis.' `
#    -Depends _CI-InitializeVariables `
#{
#    MSBuild $Foundations $Opts $CI_Props `
#        '/t:Build',
#        '/p:Configuration=Debug',
#        '/p:SkipCodeContractsReferenceAssembly=true',
#        '/p:SkipDocumentation=true',
#        '/p:SourceAnalysisEnabled=true',
#        '/p:Filter=_Analyze_'
#}
#Task CodeAnalysis `
#    -Description 'Run Code Analysis.' `
#    -Depends _CI-InitializeVariables `
#{
#    # For static analysis, we hide internals, otherwise we might not truly
#    # analyze the public API.
#    MSBuild $Foundations $Opts $CI_Props `
#        '/t:Build',
#        '/p:VisibleInternals=false',
#        '/p:RunCodeAnalysis=true',
#        '/p:SkipCodeContractsReferenceAssembly=true',
#        '/p:SkipDocumentation=true',
#        '/p:Filter=_Analyze_'
#}

Task GendarmeAnalysis `
    -Description '** Disabled ** Run Mono.Gendarme.' `
    -Depends _CI-InitializeVariables `
    -Alias Keuf `
{
    Exit-Gracefully -ExitCode 1 ` 'Gendarme does not work with the binaries produced by VS 2015.'

    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:EnableGendarme=true',
        '/p:VisibleInternals=false',
        '/p:SkipCodeContractsReferenceAssembly=true',
        '/p:SkipDocumentation=true',
        '/p:Filter=_Analyze_'

    Invoke-Gendarme 'Release+Closed'
}

Task CodeContractsAnalysis `
    -Description 'Run Code Contracts Analysis.' `
    -Depends _CI-InitializeVariables `
    -Alias CC `
{
    $output = Get-LocalPath 'docs\engineering\code-contracts.txt'

    # For static analysis, we hide internals, otherwise we might not truly
    # analyze the public API.
    MSBuild $Foundations $Opts $CI_Props `
        '/t:Build',
        '/p:VisibleInternals=false',
        '/p:Configuration=CodeContracts',
        '/p:Filter=_CodeContracts_' | Tee-Object -file $output
}

Task SecurityAnalysis `
    -Description 'Run Secuirty Analysis.' `
    -Depends _CI-InitializeVariables `
    -Alias SA `
{
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
        '/p:Filter=_Security_'
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

Task Package-All `
    -Description 'Package everything.' `
    -Depends Package-Core, Package-Mvp, Package-Build `
    -Alias Pack

Task Package-Core `
    -Description 'Create the core NuGet packages.' `
    -Depends _Package-InitializeVariables `
    -Alias PackCore `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Core_'
}

Task Package-Mvp `
    -Description 'Create the MVP-related packages.' `
    -Depends _Package-InitializeVariables `
    -Alias PackMvp `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Mvp_'
}

Task Package-Build `
    -Description 'Create the Narvalo.Build package.' `
    -Depends _Package-InitializeVariables `
    -Alias PackBuild `
{
    MSBuild $Foundations $Opts $Package_Targets $Package_Props `
        '/p:Filter=_Build_'
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
# Publication tasks
# ------------------------------------------------------------------------------

Task Publish-All `
    -Description 'Publish everything.' `
    -Depends Publish-Core, Publish-Mvp, Publish-Build `
    -Alias Push

Task Publish-Core `
    -Description 'Publish the core packages.' `
    -Depends _Publish-DependsOn, Package-Core `
    -RequiredVariables Retail `
    -Alias PushCore `
{
    Invoke-NuGetAgent $Publish_StagingDirectory -Retail:$Retail
}

Task Publish-Mvp `
    -Description 'Publish the MVP-related packages.' `
    -Depends _Publish-DependsOn, Package-Mvp `
    -RequiredVariables Retail `
    -Alias PushMvp `
{
    Invoke-NuGetAgent $Publish_StagingDirectory -Retail:$Retail
}

Task Publish-Build `
    -Description 'Publish the Narvalo.Build package.' `
    -Depends _Publish-DependsOn, Package-Build `
    -RequiredVariables Retail `
    -Alias PushBuild `
{
    Invoke-NuGetAgent $Publish_StagingDirectory -Retail:$Retail
}

Task _Publish-DependsOn `
    -Description 'Dependencies shared among the Publish-* tasks.' `
    -Depends _Publish-InitializeVariables, _Publish-Clean, NuGetAgent-Build

Task _Publish-Clean `
    -Description 'Remove the staging directory for packages.' `
    -Depends _Publish-InitializeVariables `
{
    Remove-LocalItem -Path $Publish_StagingDirectory -Recurse
}

Task _Publish-InitializeVariables `
    -Description 'Initialize variables only used by the Publish-* tasks.' `
{
    $script:Publish_StagingDirectory = Get-LocalPath 'work\packages'
}

# ------------------------------------------------------------------------------
# NuGetAgent project
# ------------------------------------------------------------------------------

Task NuGetAgent-Build `
    -Description 'Build the project NuGetAgent.' `
    -Depends _NuGetAgent-InitializeVariables, _NuGetAgent-RestorePackages `
    -Alias NuGetAgent `
{
    MSBuild $NuGetAgent_Project $Opts '/p:Configuration=Release', '/t:Build'
}

Task _NuGetAgent-RestorePackages `
    -Description 'Restore packages for the project NuGetAgent.' `
    -Depends _NuGetAgent-InitializeVariables, _Tools-InitializeVariables `
{
    Restore-Packages -Source $NuGetAgent_PackagesConfig `
        -PackagesDirectory $Tools_PackagesDirectory `
        -ConfigFile $Tools_NuGetConfig `
        -Verbosity $NuGetVerbosity
}

Task _NuGetAgent-InitializeVariables `
    -Description 'Initialize variables only used by the NuGetAgent-* tasks.' `
{
    $script:NuGetAgent_Project        = Get-LocalPath 'tools\src\NuGetAgent\NuGetAgent.fsproj'
    $script:NuGetAgent_PackagesConfig = Get-LocalPath 'tools\src\NuGetAgent\packages.config'
}

# ------------------------------------------------------------------------------
# MyGet project
# ------------------------------------------------------------------------------

Task MyGet-Package `
    -Description 'Package the project MyGet.' `
    -Depends _MyGet-InitializeVariables, _MyGet-DeleteStagingDirectory, _MyGet-Publish, _MyGet-Zip `
    -Alias MyGet `
{
    Write-Host "A ready to publish zip file for MyGet may be found here: '$MyGet_ZipFile'." -ForegroundColor Green
}

Task _MyGet-Publish `
    -Description 'Clean up, build then publish the project MyGet.' `
    -Depends _MyGet-InitializeVariables, _MyGet-RestorePackages `
{
    # Force the value of "VisualStudioVersion", otherwise MSBuild won't publish the project on build.
    # Cf. http://sedodream.com/2012/08/19/VisualStudioProjectCompatabilityAndVisualStudioVersion.aspx.
    MSBuild $MyGet_Project $Opts `
        '/t:Rebuild',
        '/p:Configuration=Release;PublishProfile=NarvaloOrg;DeployOnBuild=true;VisualStudioVersion=14.0'
}

Task _MyGet-RestorePackages `
    -Description 'Restore packages for the project MyGet.' `
    -Depends _MyGet-InitializeVariables, _Tools-InitializeVariables `
{
    Restore-Packages -Source $MyGet_PackagesConfig `
        -PackagesDirectory $Tools_PackagesDirectory `
        -ConfigFile $Tools_NuGetConfig `
        -Verbosity $NuGetVerbosity
}

Task _MyGet-DeleteStagingDirectory `
    -Description 'Remove the directory ''work\myget''.' `
    -Depends _MyGet-InitializeVariables `
{
    Remove-LocalItem -Path $MyGet_StagingDirectory -Recurse
}

Task _MyGet-DeleteZipFile `
    -Description 'Delete the package for MyGet.' `
    -Depends _MyGet-InitializeVariables `
{
    Remove-LocalItem -Path $MyGet_ZipFile
}

Task _MyGet-Zip `
    -Description 'Zip the publication artefacts for the project MyGet.' `
    -Depends _MyGet-InitializeVariables, _MyGet-DeleteZipFile `
    -PreAction {
        if (!(Test-Path $MyGet_StagingDirectory)) {
            # We do not add a dependency on _MyGet-Publish so that we can run this task alone.
            # MyGet-Package provides the stronger version.
            Exit-Gracefully -ExitCode 1 `
                'Can not create the Zip package: did you forgot to call the _MyGet-Publish task?'
        }
    } -Action {
        . (Get-7Zip -Install) -mx9 a $MyGet_ZipFile $MyGet_StagingDirectory | Out-Null

        if (!$?) {
            Exit-Gracefully -ExitCode 1 'Failed to create the Zip package.'
        }
    }

Task _MyGet-InitializeVariables `
    -Description 'Initialize variables only used by the MyGet-* tasks.' `
{
    $script:MyGet_Project          = Get-LocalPath 'tools\src\MyGet\MyGet.csproj'
    $script:MyGet_PackagesConfig   = Get-LocalPath 'tools\src\MyGet\packages.config'
    $script:MyGet_StagingDirectory = Get-LocalPath 'work\myget'
    $script:MyGet_ZipFile          = Get-LocalPath 'work\myget.7z'
}

# ------------------------------------------------------------------------------
# Edge solution
# ------------------------------------------------------------------------------
#
#Task Edge-FullBuild `
#    -Description 'Update then re-build the solution Edge.' `
#    -Depends _Edge-Update, _Edge-Rebuild
#
#Task _Edge-Rebuild `
#    -Description 'Re-build the solution Edge.' `
#    -Depends _Edge-InitializeVariables, _Edge-RestorePackages `
#{
#    MSBuild $Edge_Solution $Opts '/p:Configuration=Release', '/t:Rebuild'
#}
#
#Task _Edge-RestorePackages `
#    -Description 'Restore packages for the solution Edge.' `
#    -Depends _Edge-InitializeVariables `
#{
#    Restore-Packages -Source $Edge_Solution `
#        -PackagesDirectory $Edge_PackagesDirectory `
#        -ConfigFile $Edge_NuGetConfig `
#        -Verbosity $NuGetVerbosity
#}
#
#Task _Edge-Update `
#    -Description 'Safely update NuGet packages for the solution Edge.' `
#    -Depends _Edge-InitializeVariables `
#{
#    $nuget = Get-NuGet -Install
#
#    try {
#        . $nuget update $Edge_Solution `
#            -Safe `
#            -RepositoryPath $Edge_PackagesDirectory `
#            -ConfigFile $Edge_NuGetConfig `
#            -Verbosity $NuGetVerbosity
#    } catch {
#        Exit-Gracefully -ExitCode 1 "'nuget.exe update' failed: $_"
#    }
#}
#
#Task _Edge-InitializeVariables `
#    -Description 'Initialize variables only used by the Edge-* tasks.' `
#{
#    $script:Edge_Solution          = Get-LocalPath 'tools\src\MyPackages\Edge\Edge.sln'
#    $script:Edge_NuGetConfig       = Get-LocalPath 'tools\src\MyPackages\Edge\.nuget\NuGet.Config'
#    $script:Edge_PackagesDirectory = Get-LocalPath 'tools\src\MyPackages\Edge\packages'
#}
#
# ------------------------------------------------------------------------------
# Retail solution
# ------------------------------------------------------------------------------
#
#Task Retail-FullBuild `
#    -Description 'Update then re-build the solution Retail.' `
#    -Depends _Retail-Update, _Retail-Rebuild
#
#Task _Retail-Rebuild `
#    -Description 'Re-build the solution Retail.' `
#    -Depends _Retail-InitializeVariables, _Retail-RestorePackages `
#{
#    MSBuild $Retail_Solution $Opts '/p:Configuration=Release', '/t:Rebuild'
#}
#
#Task _Retail-RestorePackages `
#    -Description 'Restore packages for the solution Retail.' `
#    -Depends _Retail-InitializeVariables `
#{
#    Restore-Packages -Source $Retail_Solution `
#        -PackagesDirectory $Retail_PackagesDirectory `
#        -ConfigFile $Retail_NuGetConfig `
#        -Verbosity $NuGetVerbosity
#}
#
#Task _Retail-Update `
#    -Description 'Safely update NuGet packages for the solution Retail.' `
#    -Depends _Retail-InitializeVariables `
#{
#    $nuget = Get-NuGet -Install
#
#    try {
#        . $nuget update $Retail_Solution `
#            -Safe `
#            -RepositoryPath $Retail_PackagesDirectory `
#            -ConfigFile $Retail_NuGetConfig `
#            -Verbosity $NuGetVerbosity
#    } catch {
#        Exit-Gracefully -ExitCode 1 "'nuget.exe update' failed: $_"
#    }
#}
#
#Task _Retail-InitializeVariables `
#    -Description 'Initialize variables only used by the Retail-* tasks.' `
#{
#    $script:Retail_Solution          = Get-LocalPath 'tools\src\MyPackages\Retail\Retail.sln'
#    $script:Retail_NuGetConfig       = Get-LocalPath 'tools\src\MyPackages\Retail\.nuget\NuGet.Config'
#    $script:Retail_PackagesDirectory = Get-LocalPath 'tools\src\MyPackages\Retail\packages'
#}
#
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

Task Environment `
    -Description 'Display infos on the build environment.' `
    -Alias Env `
{
    # The output of running "MSBuild /version" looks like:
    # >   Microsoft (R) Build Engine, version 12.0.31101.0
    # >   [Microsoft .NET Framework, Version 4.0.30319.34209]
    # >   Copyright (C) Microsoft Corporation. Tous droits réservés.
    # >
    # >   12.0.31101.0
    # Since VS 2015, we no longer get the framework version.
    $infos = (MSBuild '/version') -Split "`n", 3

    $msbuild = $infos[3]
    #$netFramework = ($infos[1] -Split ' ', 5)[4].TrimEnd(']')
    $psakeFramework = $psake.context.peek().config.framework
    $psakeVersion = $psake.version

    Write-Host "  MSBuild         v$msbuild"
    #Write-Host "  .NET Framework  v$netFramework"
    Write-Host "  PSake           v$psakeVersion"
    Write-Host "  PSake Framework v$psakeFramework"
}

Task _Documentation `
    -Description 'Display a description of the public tasks.' `
{
    # PSake allows to display a description of the tasks by using:
    # > Invoke-PSake $buildFile -Docs
    # but I find the result more geared towards developers.
    # Here is my own version of the underlying WriteDocumentation function.
    $currentContext = $psake.context.Peek()

    if ($currentContext.tasks.default) {
        $defaultTaskDependencies = $currentContext.tasks.default.DependsOn
    } else {
        $defaultTaskDependencies = @()
    }

    $currentContext.tasks.Keys | %{
        # Ignore default and private tasks.
        if ($_ -eq 'default') {
            return
        }

        if (!$Developer -and $_.StartsWith('_')) {
            return
        }

        $task = $currentContext.tasks.$_

        if ($defaultTaskDependencies -Contains $task.Name) {
            $name = "$($task.Name) (DEFAULT)"
        } else {
            $name = $task.Name
        }

        New-Object PSObject -Property @{
            Task = $name;
            Alias = $task.Alias;
            Synopsis = $task.Description;
        }
    } |
        sort 'Task' |
        Format-Table -AutoSize -Wrap -Property Task, Alias, Synopsis
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

function Invoke-NuGetAgent {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)] [string] $Path,

        [Parameter(Mandatory = $false, Position = 1)] [string] $Configuration = 'Release',

        [switch] $Retail
    )

    try {
        $cmd = Get-LocalPath "tools\src\NuGetAgent\bin\$Configuration\nuget-agent.exe" -Resolve

        if ($Retail) {
            . $cmd --path $path --retail 2>&1
        } else {
            . $cmd --path $path 2>&1
        }
    } catch {
        Exit-Gracefully -ExitCode 1 "'nuget-agent.exe' failed: $_"
    }
}

# TODO: Quick and dirty function!
function Invoke-Gendarme {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string] $Configuration,

        [Parameter(Mandatory = $false, Position = 1)]
        [int] $Limit = 100,

        [Parameter(Mandatory = $false, Position = 2)]
        [string] $RuleSet = 'narvalo-strict'
    )

    # TODO: Make it survive NuGet updates.
    $gendarmeVersion = '2.11.0.20121120'

    $gendarme = Get-LocalPath "packages\Mono.Gendarme.$gendarmeVersion\tools\gendarme.exe" -Resolve

    $configFile = Get-LocalPath 'etc\gendarme.xml' -Resolve
    $ignoreFile = Get-LocalPath 'etc\gendarme.ignore' -Resolve
    $logFile    = Get-LocalPath 'work\log\gendarme.log'

    . $gendarme `
      --v `
      --console `
      --limit $limit `
      --config $configFile `
      --set $ruleSet `
      --severity all `
      --confidence all `
      --ignore "$ignoreFile" `
      --log "$logFile" `
      (Get-LocalPath "work\bin\$Configuration\Narvalo.Cerbere.dll") `
      (Get-LocalPath "work\bin\$Configuration\Narvalo.Fx.dll") `
      (Get-LocalPath "work\bin\$Configuration\Narvalo.Core.dll") `
      (Get-LocalPath "work\bin\$Configuration\Narvalo.Common.dll") `
      (Get-LocalPath "work\bin\$Configuration\Narvalo.Finance.dll")
}

# TODO: Quick and dirty function!
function Invoke-OpenCover {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string] $Configuration,
        [switch] $Summary
    )

    # TODO: Make it survive NuGet updates.
    $openCoverVersion       = '4.6.519'
    $reportGeneratorVersion = '2.5.1'
    $xunitVersion           = '2.1.0'

    $openCover = Get-LocalPath "packages\OpenCover.$openCoverVersion\tools\OpenCover.Console.exe" -Resolve
    $reportGenerator = Get-LocalPath "packages\ReportGenerator.$reportGeneratorVersion\tools\ReportGenerator.exe" -Resolve
    $xunit = Get-LocalPath "packages\xunit.runner.console.$xunitVersion\tools\xunit.console.exe" -Resolve

    $coverageFile = Get-LocalPath 'work\log\opencover.xml'
    $coverageFilter = '+[Narvalo*]* -[*Facts]* -[Xunit.*]*'
    $coverageExcludeByAttribute = 'System.Runtime.CompilerServices.CompilerGeneratedAttribute;Narvalo.ExcludeFromCodeCoverageAttribute;System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute'

    $coreTestAssembly = Get-LocalPath "work\bin\$Configuration\Narvalo.Facts.dll" -Resolve
    $mvpTestAssembly  = Get-LocalPath "work\bin\$Configuration\Narvalo.Mvp.Facts.dll" -Resolve
    $testsAssembly = "$coreTestAssembly $mvpTestAssembly"

    # Be very careful with arguments containing spaces.
    . $openCover `
      -register:user `
      "-filter:$coverageFilter" `
      "-excludebyattribute:$coverageExcludeByAttribute" `
      "-output:$coverageFile" `
      "-target:$xunit"  `
      "-targetargs:$testsAssembly -nologo -noshadow"

    if ($summary.IsPresent) {
        $summaryDirectory = Get-LocalPath 'work\log'
        $summaryFilters = '+*'

        . $reportGenerator `
          -verbosity:Info `
          -reporttypes:HtmlSummary `
          -filters:$summaryFilters `
          -reports:$coverageFile `
          -targetdir:$summaryDirectory

        Copy-Item -Path (Get-LocalPath 'work\log\summary.htm') -Destination (Get-LocalPath 'docs\engineering\code-coverage.html') -Force
    }
    else {
        $reportDirectory = Get-LocalPath 'work\log\opencover'
        # REVIEW: Add a commandline filter
        $reportFilters = '-Narvalo.Common;-Narvalo.Core;-Narvalo.Fx;-Narvalo.Mvp;-Narvalo.Mvp.Web;-Narvalo.Web'
        #$reportFilters = '-*;+Narvalo.Core'  # Does not work.

        . $reportGenerator `
          -verbosity:Info `
          -reporttypes:Html `
          "-filters:$reportFilters" `
          -reports:$coverageFile `
          -targetdir:$reportDirectory
    }
}

# ------------------------------------------------------------------------------
