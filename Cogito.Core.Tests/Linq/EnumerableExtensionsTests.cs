using System;
using System.Linq;

using Cogito.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Linq
{

    [TestClass]
    public class EnumerableExtensionsTests
    {

        [TestMethod]
        public void Test_GroupAdjacent()
        {
            var l = new[]
            {
                Tuple.Create("Name1", "Value1"),
                Tuple.Create("Name1", "Value1"),
                Tuple.Create("Name2", "Value1"),
                Tuple.Create("Name2", "Value1"),
                Tuple.Create("Name1", "Value2"),
                Tuple.Create("Name1", "Value2"),
            };

            var a = l.GroupAdjacent(i => i.Item1).ToList();

            Assert.AreEqual(3, a.Count);
        }

    }

}
