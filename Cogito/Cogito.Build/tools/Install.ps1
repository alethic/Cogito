param(
    [Parameter(Mandatory = $true)] [String] $installPath, 
    [Parameter(Mandatory = $true)] [String] $toolsPath, 
    [Parameter(Mandatory = $true)]          $package, 
    [Parameter(Mandatory = $true)]          $project
)

[System.AppDomain]::CurrentDomain.SetShadowCopyFiles();

# Files to be imported.
$propsFile = [System.IO.Path]::Combine($toolsPath, "$($package.Id).props")
$targetsFile = [System.IO.Path]::Combine($toolsPath, "$($package.Id).targets")
 
# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

# Grab the loaded MSBuild project for the project
$msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1
 
# Make the path to the targets and props files relative.
$projectUri = New-Object Uri($project.FullName, [System.UriKind]::Absolute)
$propUri = New-Object Uri($propsFile, [System.UriKind]::Absolute)
$propPath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($propUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
$targetUri = New-Object Uri($targetsFile, [System.UriKind]::Absolute)
$targetPath = [System.Uri]::UnescapeDataString($projectUri.MakeRelativeUri($targetUri).ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)

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

# Add the import with a condition, to allow the project to load without the file present.
$import = $msbuild.Xml.CreateImportElement($propPath)
$import.Condition = "Exists('$propPath')"
$msbuild.Xml.PrependChild($import)

# Add the import with a condition, to allow the project to load without the file present.
$import = $msbuild.Xml.CreateImportElement($targetPath)
$import.Condition = "Exists('$targetPath')"
$msbuild.Xml.AppendChild($import)

# Add a target to fail the build when our files are not imported.
$target = $msbuild.Xml.AddTarget("EnsureCogitoBuildImported")
$target.BeforeTargets = "BeforeBuild"
$target.Condition = "'$`(CogitoBuildPropsImported)' == '' Or '$`(CogitoBuildTargetsImported)' == ''"

# If the files don't exist at the time the target runs, package restore didn't run.
$errorTask = $target.AddTask('Error')
$errorTask.Condition = "!Exists('$propPath') Or !Exists('$targetPath')"
$errorTask.SetParameter('Text', "This project references the package $($package.Id) that is missing on this computer. Enable NuGet Package Restore to download it.");
$errorTask.SetParameter('HelpKeyword', 'COGITOBUILD2001');

# If the files exist at the time the target runs, package restore ran but the build didn't import the files.
$errorTask = $target.AddTask('Error')
$errorTask.Condition = "Exists('$propPath') And Exists('$targetPath')"
$errorTask.SetParameter('Text', "The build restored the $($package.Id) package. Build the project again to include this package.");
$errorTask.SetParameter('HelpKeyword', 'COGITOBUILD2002');
