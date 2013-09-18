using System.IO;
using Cogito.Build.Tasks;
using Cogito.Build.Tasks.Fakes;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Build.Tests
{

    [TestClass]
    public class InstallBuildPropsTaskTests
    {

        [TestMethod]
        public void InstallBuildPropsTaskTest1()
        {
            using (var s = ShimsContext.Create())
            {
                var t = new ShimInstallBuildPropsTask(new InstallBuildPropsTask());

                var solutionDir =
                    new DirectoryInfo(Directory.GetCurrentDirectory())
                        .Parent.Parent.Parent
                        .FullName;

                var packagesDir =
                    new DirectoryInfo(solutionDir)
                        .GetDirectories("packages")[0]
                        .FullName;

                var sourceDir =
                    new DirectoryInfo(solutionDir)
                        .GetDirectories("Cogito.Build")[0]
                        .GetDirectories("build")[0]
                        .FullName;

                var targetFile =
                    new DirectoryInfo(sourceDir)
                        .GetFiles("Cogito.Build.targets")[0]
                        .FullName;

                t.SolutionDirGet = () => solutionDir;
                t.PackagesDirGet = () => packagesDir;
                t.ProjectFileGet = () => "Test.csproj";
                t.GetTargetFile = () => targetFile;

                t.Instance.Execute();
            }
        }

    }

}
