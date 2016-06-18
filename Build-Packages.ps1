param(

    [Parameter(Mandatory=$true)]
    [string]$OutputDirectory,
    
    [Parameter(Mandatory=$true)]
    [string]$BuildSourceDirectory,
    
    [Parameter(Mandatory=$true)]
    [string]$BuildConfiguration,

    [Parameter(Mandatory=$true)]
    [string]$Version,

    [string]$NuGetExe

)

# output version
Write-Host "Version: $Version"

if ($OutputDirectory -and !(Test-Path $OutputDirectory))
{
    Write-Host "Output directory used but doesn't exists, creating it"
    New-Item $OutputDirectory -type directory
}

# search for nuspec files
$NuSpecFiles = Get-Item **\*.nuspec

# display found files
Write-Host "Found nuspec files: $($NuSpecFiles.Count)"
foreach ($NuSpecFile in $NuSpecFiles)
{
    Write-Host "--File: `"$NuSpecFile`""
}

# discover location of NuGet.exe from agent if not specified
if ([string]::IsNullOrWhiteSpace($NuGetExe))
{
    $NuGetExe = "$($env:AGENT_HOMEDIRECTORY)\agent\Worker\tools\NuGet.exe"
}

# test nuget
if (!(Test-Path $NuGetExe))
{
    Write-Error "Could not locate NuGet.exe"
    exit 1
}

# run packaging
foreach ($i in $NuSpecFiles)
{
    $f = [System.IO.Path]::ChangeExtension($i.FullName, ".csproj")
    if (Test-Path $f)
    {
    	& $NuGetExe pack -OutputDirectory `"$OutputDirectory`" -Symbols -Version `"$Version`" -Properties Configuration=$BuildConfiguration `"$f`"
    }
}
