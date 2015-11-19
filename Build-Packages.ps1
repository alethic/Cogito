foreach ($i in Get-Item *.nupkg)
{
    Remove-Item $i
}

foreach ($i in Get-Item *\*.nuspec)
{
	.\.nuget\NuGet.exe pack $i
}
