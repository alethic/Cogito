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
    public class FixUpNuGetPropsTests
    {

        [TestMethod]
        public void FixUpNuGetPropsTest1()
        {
            using (var s = ShimsContext.Create())
            {
                var t = new ShimFixUpNuGetProps(new FixUpNuGetProps());

                var solutionDir =
                    new DirectoryInfo(Directory.GetCurrentDirectory())
                        .Parent.Parent.Parent
                        .FullName;

                var sourceDir =
                    new DirectoryInfo(solutionDir)
                        .GetDirectories("Cogito.Build")[0]
                        .GetDirectories("build")[0]
                        .FullName;

                t.GetSolutionDir = () => solutionDir;
                t.GetProjectFile = () => "Test.csproj";
                t.GetSourceDir = () => sourceDir;

                t.Instance.Execute();
            }
        }

    }

}
