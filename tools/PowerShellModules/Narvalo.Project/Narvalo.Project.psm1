Set-StrictMode -Version Latest

function Approve-ProjectRoot {
    param([Parameter(Mandatory = $true)] [string] $path) 

    if (![System.IO.Path]::IsPathRooted($path)) {
        throw 'When importing the ''Narvalo.Project'' module, ',
            'you MUST specify an absolute path for the Narvalo.NET project repository.'
    }

    if (!(Test-Path $path)) {
        throw 'When importing the ''Narvalo.Project'' module,',
            'you MUST specify an existing directory for the Narvalo.NET project repository.'
    }

    return $path
}

if ($args.Length -ne 1) {
    throw 'When importing the ''Narvalo.Project'' module,',
        'you MUST specify the Narvalo.NET project repository,',
        ' e.g. ''Import-Module Narvalo.Project -Args $projectRoot''.'
}

Set-Variable -Name ProjectRoot `
    -Value (Approve-ProjectRoot $args[0]) `
    -Scope Script `
    -Option ReadOnly `
    -Description 'Path to the local repository for the Narvalo.NET project.'

#$MyInvocation.MyCommand.ScriptBlock.Module.OnRemove = {
#    Remove-Variable -Name ProjectRoot -Scope Script -Force
#}

# ------------------------------------------------------------------------------
# Private variables
# ------------------------------------------------------------------------------

[string] $script:CopyrightHeader = '// Copyright (c) Narvalo.Org.',
    'All rights reserved. See LICENSE.txt in the project root for license information.'

# ------------------------------------------------------------------------------
# Public functions
# ------------------------------------------------------------------------------

<# 
.SYNOPSIS
    Exit with the error code 1.
.PARAMETER Message
    The message to be written.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Exit-Error {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [string] $Message
    )
    
    Write-Host "`n", $message, "`n" -BackgroundColor Red -ForegroundColor Yellow
    Exit 1
}

<# 
.SYNOPSIS
    Get the path to the 7-Zip command.
.INPUTS
    None.
.OUTPUTS
    System.String. Get-7Zip returns a string that contains the path to the 7-Zip executable.
#>
function Get-7Zip {
    [CmdletBinding()]
    param([switch] $Install)

    $sevenZip = Get-ProjectItem 'tools\7za.exe'

    if ($install.IsPresent -and !(Test-Path $sevenZip)) {
        Install-7Zip $sevenZip | Out-Null
    }

    return $sevenZip
}

<# 
.SYNOPSIS
    Get the path to the installed git command.
.INPUTS
    None.
.OUTPUTS
    System.String. Get-Git returns a string that contains the path to the git command 
    or $null if git is nowhere to be found.
#>
function Get-Git {
    [CmdletBinding()]
    param()

    Write-Verbose 'Finding the installed git command.'

    $git = (Get-Command "git.exe" -CommandType Application -TotalCount 1 -ErrorAction SilentlyContinue)

    if ($git -eq $null) { 
        Write-Warning 'git.exe could not be found in your PATH. Please ensure git is installed.'
        return $null
    } else {
        return $git.Path
    }
}

<#
.SYNOPSIS
    Get the last git commit hash.
.PARAMETER Abbrev
    If present, finds the abbreviated commit hash.
.PARAMETER Git
    Specifies the path to the Git executable.
.INPUTS
    The path to the Git executable.
.OUTPUTS
    System.String. Get-GitCommitHash returns a string that contains the git commit hash.
.NOTES
    If anything fails, returns an empty string.
#>
function Get-GitCommitHash {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [string] $Git,

        [switch] $Abbrev
    )

    Write-Verbose 'Getting the last git commit hash.'

    if ($abbrev.IsPresent) {
        $fmt = '%h'
    } else {
        $fmt = '%H'
    }

    $hash = ''

    try {
        Write-Debug 'Call git.exe log.'
        $hash = . $git log -1 --format="$fmt" 2>&1
    } catch {
        Write-Warning "Git command failed: $_"
    }

    $hash
}

<#
.SYNOPSIS
    Get the path to the NuGet command.
.INPUTS
    None.
.OUTPUTS
    System.String. Get-NuGet returns a string that contains the path to the NuGet executable.
#>
function Get-NuGet {
    [CmdletBinding()]
    param([switch] $Install)

    $nuget = Get-ProjectItem 'tools\nuget.exe'

    if ($install.IsPresent -and !(Test-Path $nuget)) {
        Install-NuGet $nuget | Out-Null
    }

    $nuget
}

<#
.SYNOPSIS
    Combine the repository path and several parts.
.PARAMETER PathList
    Specifies the elements to append to the repository path.
.INPUTS
    None.
.OUTPUTS
    System.String. Get-ProjectItem returns a string that contains the resulting path.
#>
function Get-ProjectItem {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)] 
        [AllowEmptyString()]
        [Alias('p')] [string] $Path,

        [switch] $Resolve
    )

    if ($path -eq '') {
       $ProjectRoot
    } else {
        Join-Path -Path $ProjectRoot -ChildPath $path -Resolve:$resolve.IsPresent
    }
}

<#
.SYNOPSIS
    Get the path to the PSake module.
.PARAMETER NoVersion
    If present, do not include a version independent path.
.INPUTS
    None.
.OUTPUTS
    System.String. Get-PSakeModulePath returns a string that contains the path to the PSake module.
#>
function Get-PSakeModulePath {
    [CmdletBinding()]
    param([switch] $NoVersion)
    
    if ($noVersion.IsPresent) {
        Get-ProjectItem 'packages\psake\tools\psake.psm1'
    } else {
        (ls (Get-ProjectItem 'packages\psake.*\tools\psake.psm1') | select -First 1)
    }
}

<#
.SYNOPSIS
    Install 7-Zip if it is not already installed.
.PARAMETER Force
    If present, override the previous installed 7-Zip if any.
.INPUTS
    None.
.OUTPUTS
    System.String. Install-7Zip returns a string that contains the path to the 7-Zip executable.
#>
function Install-7Zip {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [Alias('o')] [string] $OutFile,

        [switch] $Force
    )

    [System.Uri] $uri = 'http://narvalo.org/7z936.exe'
    $uri | Install-WebResource -Name '7-Zip' -o $outFile -Force:$force
}

<#
.SYNOPSIS
    Install NuGet if it is not already installed.
.PARAMETER Force
    If present, override the previous installed NuGet if any.
.INPUTS
    None.
.OUTPUTS
    System.String. Install-NuGet returns a string that contains the path to the NuGet executable.
#>
function Install-NuGet {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [Alias('o')] [string] $OutFile,

        [switch] $Force
    )

    [System.Uri] $uri = 'https://nuget.org/nuget.exe'
    $uri | Install-WebResource -Name 'NuGet' -o $outFile -Force:$force
}

<#
.SYNOPSIS
    Install PSake.
.PARAMETER NuGet
    Specifies the path to the NuGet executable.
.INPUTS
    The path to the NuGet executable.
.OUTPUTS
    System.String. Install-PSake returns a string that contains the path to the PSake module.
.NOTES
    This function is rather slow to execute.
#>
function Install-PSake {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)]
        [string] $NuGet
    )
    
    Write-Verbose 'Installing PSake.'
    
    try {
        Write-Debug 'Call nuget.exe install psake.'
        . $nuget install psake `
           -ExcludeVersion `
           -OutputDirectory (Get-ProjectItem 'packages') `
           -ConfigFile (Get-ProjectItem '.nuget\NuGet.Config') `
           -Verbosity quiet 2>&1
    } catch {
        throw "'nuget.exe install' failed: $_"
    }

    Get-PSakeModulePath -NoVersion
}

<#
.SYNOPSIS
    Remove the 'bin' and 'obj' directories created by Visual Studio.
.PARAMETER PathList
    Specifies the list of paths to traverse.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Remove-BinAndObj {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [Alias('p')] [string[]] $PathList
    )

    BEGIN { }

    PROCESS {
        $pathList | %{
            if (!(Test-Path $_)) { return }

            Write-Verbose "Processing directory '$_'."

            ls $_ -Include bin,obj -Recurse | ?{ rm $_.FullName -Force -Recurse -ErrorAction SilentlyContinue }
        }
    }
}

<#
.SYNOPSIS
    Remove files untracked by git.
.PARAMETER Git
    Specifies the path to the git executable.
.INPUTS
    The path to the git executable.
.OUTPUTS
    None.
.NOTES
    We do not remove ignored files (see -x and -X options from git).
.LINK
    http://git-scm.com/docs/git-clean
#>
function Remove-UntrackedItems {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [string] $Git,

        [Parameter(Mandatory = $true, Position = 1)] 
        [Alias('p')] [string] $Path
    )
    
    Write-Verbose 'Removing untracked files.'

    try {
        Push-Location $path

        # We exclude all folders named 'Internal' (some of them only contain linked files).
        if ($PSCmdlet.ShouldProcess($path, 'Calling git to permanently delete all untracked files')) {
            . $git clean -d -f -e 'Internal'
        } else {
            . $git clean -d -n -e 'Internal'
        }
    } catch {
        Exit-Error "Unabled to remove untracked files: $_"
    } finally {
        Pop-Location
    }
}

<#
.SYNOPSIS
    Add a copyright header to all C# files missing one.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Repair-Copyright {
    [CmdletBinding(SupportsShouldProcess = $true)] 
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [Alias('p')] [string[]] $PathList
    )
    
    BEGIN {
        $count = 0
    }

    PROCESS {
        $items = $pathList | %{ Find-MissingCopyright -Path $_ }

        $count += ($items | measure).Count

        $items | %{ Add-Copyright $_.FullName }
    }

    END {
        if ($count -eq 0) {
            Write-Output 'No missing copyright header found :-)'
        } else {
            Write-Output "Repaired $count file(s) without a copyright header!"
        }
    }
}

<#
.SYNOPSIS
    Restore packages.
.PARAMETER NuGet
    Specifies the path to the NuGet executable.
.INPUTS
    The path to the NuGet executable.
.OUTPUTS
    None.
#>
function Restore-SolutionPackages {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] 
        [string] $NuGet
    )
    
    Write-Verbose 'Restoring solution packages.'
    
    try {
        Write-Debug 'Call nuget.exe restore.'
        . $nuget restore (Get-ProjectItem '.nuget\packages.config') `
            -PackagesDirectory (Get-ProjectItem 'packages') `
            -ConfigFile (Get-ProjectItem '.nuget\NuGet.Config') `
            -Verbosity quiet 2>&1
    } catch {
        throw "'nuget.exe restore' failed: $_"
    }
}

<#
.SYNOPSIS
    Stop any running MSBuild process.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Stop-AnyMSBuildProcess {
    Write-Debug 'Ensure there is no concurrent MSBuild running.'
    Get-Process -Name 'msbuild' -ErrorAction SilentlyContinue | %{ Stop-Process $_.ID -Force }
}

# ------------------------------------------------------------------------------
# Private functions
# ------------------------------------------------------------------------------

<#
.SYNOPSIS
    Add a copyright header to a file.
.PARAMETER Path
    Specifies the file to repair.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Add-Copyright {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0)] 
        [Alias('p')] [string] $Path
    )

    Write-Verbose "Adding copyright header to $path..."

    $lines = New-Object System.Collections.ArrayList(, (cat -LiteralPath $path))
    $lines.Insert(0, '')
    $lines.Insert(0, $SCRIPT:CopyrightHeader)
    $lines | Set-Content -LiteralPath $path -Encoding UTF8
}

<#
.SYNOPSIS
    Find C# files without copyright header.
.PARAMETER Path
    Specifies the path to the directory to traverse.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Find-MissingCopyright {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)]
        [Alias('p')] [string] $Path
    )

    Write-Verbose 'Find all C# source files, ignoring designer generated files and temporary build directories.'

    ls $path -Recurse -Filter *.cs -Exclude *.Designer.cs |
        ?{ -not ($_.FullName.Contains('bin\') -or $_.FullName.Contains('obj\')) } | 
        ?{ -not (Test-Copyright $_.FullName) } | 
        select FullName
}

<#
.SYNOPSIS
    Install a web resource if it is not already installed.
.PARAMETER Force
    If present, override the previous installed resource if any.
.OUTPUTS
    System.String. Install-WebResource returns a string that contains the path to the installed resource.
#>
function Install-WebResource {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true, ValueFromPipelineByPropertyName = $true)] 
        [System.Uri] $Uri,

        [Parameter(Mandatory = $true, Position = 1, ValueFromPipeline = $true)] 
        [Alias('o')] [string] $OutFile,

        [Parameter(Mandatory = $true, Position = 2)] 
        [string] $Name,

        [switch] $Force
    )
    
    if (!$force -and (Test-Path $outFile -PathType Leaf)) {
        Write-Verbose "$name is already installed."
    } else {
        Write-Verbose "Installing $name."

        try {
            Write-Debug "Download $uri to $outFile."
            Invoke-WebRequest $uri -OutFile $outFile
        } catch {
            throw "Unabled to download $name."
        }
    }

    $outFile
}

<#
.SYNOPSIS
    Return $true if the file contains a copyright header, $false otherwise.
.PARAMETER Path
    Specifies the file to test.
.INPUTS
    None.
.OUTPUTS
    None.
#>
function Test-Copyright {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0)] 
        [Alias('p')] [string] $Path
    )

    Write-Verbose "Processing $path."

    $line = cat -LiteralPath $path -TotalCount 1;

    return $line -and $line.StartsWith('// Copyright')
}

# ------------------------------------------------------------------------------
# Exports
# ------------------------------------------------------------------------------

Export-ModuleMember -Function `
    Exit-Error,
    Get-7Zip,
    Get-Git, 
    Get-GitCommitHash, 
    Get-NuGet, 
    Get-ProjectItem,
    Get-PSakeModulePath,
    Install-7Zip,
    Install-NuGet, 
    Install-PSake,
    Remove-BinAndObj,
    Remove-UntrackedItems,
    Repair-Copyright,
    Restore-SolutionPackages,
    Stop-AnyMSBuildProcess
        
# ------------------------------------------------------------------------------
