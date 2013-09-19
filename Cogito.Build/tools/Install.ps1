param(
    [Parameter(Mandatory = $false)] [String] $installPath, 
    [Parameter(Mandatory = $false)] [String] $toolsPath, 
    [Parameter(Mandatory = $false)]          $package, 
    [Parameter(Mandatory = $false)]          $project
)

Import-Module (Join-Path $PSScriptRoot Cogito.PowerShell.psd1)
Import-Module (Join-Path $PSScriptRoot Cogito.Build.psd1)

Invoke-CogitoProject `
    -Package $package `
	-Project $project `
	-Dte $dte `
    -Debug -Verbose