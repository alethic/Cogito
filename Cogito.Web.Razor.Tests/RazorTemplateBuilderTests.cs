using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Web.Razor.Tests
{

    [TestClass]
    public class RazorTemplateBuilderTests
    {

        TextReader LoadTemplateText(string name)
        {
            return new StreamReader(typeof(RazorTemplateBuilderTests).Assembly
                .GetManifestResourceStream(typeof(RazorTemplateBuilderTests).Namespace + ".Templates." + name));
        }

        [TestMethod]
        public void Test_simple_code_generation()
        {
            var t = RazorTemplateBuilder.ToCode(LoadTemplateText("Simple.cshtml").ReadToEnd());
            Assert.IsTrue(t.Contains(@"@__CompiledTemplate"));
        }

        [TestMethod]
        public void Test_simple_helper_code_generation()
        {
            var t = RazorTemplateBuilder.ToCode(LoadTemplateText("SimpleWithHelper.cshtml").ReadToEnd());
            Assert.IsTrue(t.Contains(@"@__CompiledTemplate"));
        }

    }

}
