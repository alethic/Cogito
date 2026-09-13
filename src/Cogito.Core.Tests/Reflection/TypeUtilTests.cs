using System.Linq;
using Cogito.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Reflection
{

    [TestClass]
    public class TypeUtilTests
    {
         
        class A
        {

        }

        class AB : A
        {

        }

        class AC : A
        {

        }

        class ABA : AB
        {

        }

        class ABC : AC
        {

        }


        [TestMethod]
        public void Test_GetMostCompatibleTypes()
        {
            var t = new[] { typeof(int), typeof(string), typeof(long) };
            var l = TypeUtil.GetMostCompatibleTypes(t);
            Assert.AreEqual(typeof(object), l.First());
        }

        [TestMethod]
        public void Test_GetMostCompatibleTypes_Complex()
        {
            var t = new[] { typeof(ABC), typeof(ABC), typeof(ABA) };
            var l = TypeUtil.GetMostCompatibleTypes(t);
            Assert.AreEqual(typeof(A), l.First());
        }

        [TestMethod]
        public void Test_GetMostCompatibleTypes_EarlyRoot()
        {
            var t = new[] { typeof(ABC), typeof(ABC), typeof(ABA), typeof(object) };
            var l = TypeUtil.GetMostCompatibleTypes(t);
            Assert.AreEqual(typeof(object), l.First());
        }

    }

}
