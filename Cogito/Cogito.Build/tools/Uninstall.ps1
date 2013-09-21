param(
    [Parameter(Mandatory = $true)] [String] $installPath, 
    [Parameter(Mandatory = $true)] [String] $toolsPath, 
    [Parameter(Mandatory = $true)]          $package, 
    [Parameter(Mandatory = $true)]          $project
)
 
# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

# Grab the loaded MSBuild project for the project.
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

# Remove existing elements. Ensures we don't get duplicates.
$itemsToRemove = @()
$itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("\$($package.Id).Fake.targets") }
$itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("\$($package.Id).props") }
$itemsToRemove += $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith("\$($package.Id).targets") }
$itemsToRemove += $msbuild.Xml.Targets | Where-Object { $_.Name -eq 'EnsureCogitoBuildImported' }
  
# Remove the elements and save the project.
if ($itemsToRemove -and $itemsToRemove.length) {
    foreach ($itemToRemove in $itemsToRemove) {
        $msbuild.Xml.RemoveChild($itemToRemove) | out-null
    }
}
