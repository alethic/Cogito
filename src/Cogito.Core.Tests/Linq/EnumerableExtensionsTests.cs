using System;
using System.Linq;

using Cogito.Linq;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Linq
{

    [TestClass]
    public class EnumerableExtensionsTests
    {

        [TestMethod]
        public void Should_yield_once()
        {
            var l = 1.Yield();
            l.Should().HaveCount(1);
            l.Should().HaveElementAt(0, 1);
        }

        [TestMethod]
        public void Should_yield_twice()
        {
            var l = 1.Yield(2);
            l.Should().HaveCount(2);
            l.Should().HaveElementAt(0, 1);
            l.Should().HaveElementAt(1, 1);
        }

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

        [TestMethod]
        public void Test_GroupAdjacent_Null()
        {
            var l = new[]
            {
                Tuple.Create("Name1", "Value1"),
                Tuple.Create("Name1", "Value1"),
                Tuple.Create("Name2", "Value1"),
                Tuple.Create("Name2", "Value1"),
                Tuple.Create((string)null, "Value2"),
                Tuple.Create("Name1", "Value2"),
            };

            var a = l.GroupAdjacent(i => i.Item1).ToList();

            Assert.AreEqual(4, a.Count);
        }

    }

}
