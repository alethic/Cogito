using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cogito.Build;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using Microsoft.Build.Framework.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Cogito.Build.Fakes;
using System.IO;

namespace Cogito.Build.Tests
{

    [TestClass]
    public class UpdatePackagesDirPathsTests
    {

        [TestMethod]
        public void UpdatePackagesDirPathsTest1()
        {
            using (var s = ShimsContext.Create())
            {
                var t = new ShimUpdatePackagesDirPaths(new UpdatePackagesDirPaths());

                // resolve targets file
                t.GetTargetFile = () =>
                    new DirectoryInfo(Directory.GetCurrentDirectory())
                        .Parent.Parent.Parent
                        .GetDirectories("packages")[0]
                        .GetDirectories("Cogito.Build.*")[0]
                        .GetDirectories("build")[0]
                        .GetFiles("Cogito.Build.targets")[0]
                        .FullName;
                
                // sample project file
                t.MSBuildProjectFileGet = () =>
                    new ITaskItem[] { new TaskItem("Test.csproj") };

                t.Instance.Execute();
            }
        }

    }

}
