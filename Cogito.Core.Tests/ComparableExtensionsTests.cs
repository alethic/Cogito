using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class ComparableExtensionsTests
    {

        [TestMethod]
        public void Test_between()
        {
            // test open
            Assert.IsFalse(0.Between(1, 10, IntervalMode.Open));
            Assert.IsTrue(1.Between(1, 10, IntervalMode.Open));
            Assert.IsTrue(5.Between(1, 10, IntervalMode.Open));
            Assert.IsTrue(10.Between(1, 10, IntervalMode.Open));
            Assert.IsFalse(11.Between(1, 10, IntervalMode.Open));

            // full closed
            Assert.IsFalse(0.Between(1, 10, IntervalMode.Closed));
            Assert.IsFalse(1.Between(1, 10, IntervalMode.Closed));
            Assert.IsTrue(5.Between(1, 10, IntervalMode.Closed));
            Assert.IsFalse(10.Between(1, 10, IntervalMode.Closed));
            Assert.IsFalse(11.Between(1, 10, IntervalMode.Closed));

            // left open
            Assert.IsFalse(0.Between(1, 10, IntervalMode.HalfOpenLeft));
            Assert.IsTrue(1.Between(1, 10, IntervalMode.HalfOpenLeft));
            Assert.IsTrue(5.Between(1, 10, IntervalMode.HalfOpenLeft));
            Assert.IsFalse(10.Between(1, 10, IntervalMode.HalfOpenLeft));
            Assert.IsFalse(11.Between(1, 10, IntervalMode.HalfOpenLeft));

            // right open
            Assert.IsFalse(0.Between(1, 10, IntervalMode.HalfOpenRight));
            Assert.IsFalse(1.Between(1, 10, IntervalMode.HalfOpenRight));
            Assert.IsTrue(5.Between(1, 10, IntervalMode.HalfOpenRight));
            Assert.IsTrue(10.Between(1, 10, IntervalMode.HalfOpenRight));
            Assert.IsFalse(11.Between(1, 10, IntervalMode.HalfOpenRight));
        }

    }
}
