$nuget = "$($env:AGENT_HOMEDIRECTORY)\Worker\tools\NuGet.exe"
if (!(Test-Path $nuget))
{
    throw [System.IO.FileNotFoundException] "NuGet.exe not found at $nuget"
}

foreach ($i in Get-Item **\*.nuspec)
{
    $f = [System.IO.Path]::ChangeExtension($i.FullName, ".csproj")
    if (Test-Path $f)
    {
	    & $nuget pack $f
    }
}
