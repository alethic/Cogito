using Cogito.Composition.Internal;
using Irony.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Composition.Tests.Internal
{

    [TestClass]
    public class ContractTypeNameGrammarTests
    {

        [TestMethod]
        public void TestGrammar()
        {
            var g = new ContractTypeNameGrammar();
            var p = new Parser(g);
            Assert.IsTrue(p.Language.Errors.Count == 0);
        }

        [TestMethod]
        public void TestParser()
        {
            var g = new ContractTypeNameGrammar();
            var p = new Parser(g);
            var t = p.Parse("test1.test2(sub1,sub2(sub3))");
            Assert.IsFalse(t.HasErrors());

            var x = t.ToXml();
        }

    }

}
