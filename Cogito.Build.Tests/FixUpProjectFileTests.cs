using System.IO;
using Cogito.Build.Tasks;
using Cogito.Build.Tasks.Fakes;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Build.Tests
{

    [TestClass]
    public class FixUpProjectFileTests
    {

        [TestMethod]
        public void FixUpProjectFileTest1()
        {
            using (var s = ShimsContext.Create())
            {
                var t = new ShimFixUpProjectFile(new FixUpProjectFile());


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

                t.GetSolutionDir = () => solutionDir;
                t.GetPackagesDir = () => packagesDir;
                t.GetProjectFile = () => "Test.csproj";
                t.GetTargetFile = () => targetFile;

                t.Instance.Execute();
            }
        }

    }

}
