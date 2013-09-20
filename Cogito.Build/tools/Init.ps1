param(
    [Parameter(Mandatory = $false)] [String] $installPath, 
    [Parameter(Mandatory = $false)] [String] $toolsPath, 
    [Parameter(Mandatory = $false)]          $package, 
    [Parameter(Mandatory = $false)]          $project
)

Invoke.ps1 `
	-installPath $installPath `
	-toolsPath $toolsPath `
	-package $package `
	-project $project
