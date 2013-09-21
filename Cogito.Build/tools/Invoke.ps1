param(
    [Parameter(Mandatory = $false)] [String] $installPath, 
    [Parameter(Mandatory = $false)] [String] $toolsPath, 
    [Parameter(Mandatory = $false)]          $package, 
    [Parameter(Mandatory = $false)]          $project
)

[System.AppDomain]::CurrentDomain.SetShadowCopyFiles();

Get-Module Cogito.Build      | Remove-Module
Get-Module Cogito.PowerShell | Remove-Module

Import-Module (Join-Path $PSScriptRoot Cogito.PowerShell.psd1)
Import-Module (Join-Path $PSScriptRoot Cogito.Build.psd1)

Invoke-CogitoActions `
	-Dte $dte `
	-Project $project `
    -Package $package
