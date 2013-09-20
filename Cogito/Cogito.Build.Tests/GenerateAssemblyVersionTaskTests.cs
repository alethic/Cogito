using Cogito.Build.Tasks;
using Cogito.Build.Tasks.Fakes;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Build.Tests
{

    [TestClass]
    public class GenerateAssemblyVersionTaskTests
    {

        [TestMethod]
        public void GenerateAssemblyVersionTaskTests1()
        {
            using (var s = ShimsContext.Create())
            {
                var t = new ShimGenerateAssemblyVersionTask(new GenerateAssemblyVersionTask());

                t.OutputFileGet = () => "AssemblyVersion.g.cs";

                t.Instance.Execute();
            }
        }

    }

}
