using Cogito.Web.Razor.Generator;
using Irony.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Web.Razor.Tests.Generator
{

    [TestClass]
    public class CSharpAttributeDeclaractionGrammarTests
    {

        ParseTree Parse(string code)
        {
            var p = new Irony.Parsing.Parser(new CSharpAttributeDeclarationGrammar());
            var v = p.Parse(code);
            return v;
        }

        [TestMethod]
        public void Test_parse_unqualified_no_args()
        {
            var v = Parse("Attribute()");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_unqualified_one_arg()
        {
            var v = Parse("Attribute(arg1)");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_unqualified_two_args()
        {
            var v = Parse("Attribute(arg1, arg2)");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_qualified_no_args()
        {
            var v = Parse("System.Attribute()");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_qualified_one_arg()
        {
            var v = Parse("System.Attribute(arg1)");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_qualified_two_args()
        {
            var v = Parse("System.Attribute(arg1, arg2)");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_qualified_one_arg_nested_paren()
        {
            var v = Parse("System.Attribute(arg1(arg1item1))");
            Assert.IsFalse(v.HasErrors());
        }

        [TestMethod]
        public void Test_parse_qualified_two_args_nested_paren()
        {
            var v = Parse("System.Attribute(arg1(arg1item1), arg2(arg2item1))");
            Assert.IsFalse(v.HasErrors());
        }

    }

}
