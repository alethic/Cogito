using Cogito.Collections;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Collections
{

    [TestClass]
    public class IntervalTreeTests
    {

        [TestMethod]
        public void Test_basic()
        {
            var t = new IntervalTree<Interval<int>, int>();
            t.Add(Interval.Create(1, 2));
            t.Add(Interval.Create(4, 5));
            t.Add(Interval.Create(7, 8));

            Assert.IsTrue(t.FindAt(0).Length == 0);
            Assert.IsTrue(t.FindAt(1).Length == 1);
            Assert.IsTrue(t.FindAt(2).Length == 1);
            Assert.IsTrue(t.FindAt(3).Length == 0);
            Assert.IsTrue(t.FindAt(4).Length == 1);
            Assert.IsTrue(t.FindAt(5).Length == 1);
            Assert.IsTrue(t.FindAt(6).Length == 0);
            Assert.IsTrue(t.FindAt(7).Length == 1);
            Assert.IsTrue(t.FindAt(8).Length == 1);
            Assert.IsTrue(t.FindAt(9).Length == 0);
        }

        [TestMethod]
        public void Test_generic_interval()
        {
            var t = new IntervalTree<int>();
            t.Add(0, 1);
            var a = t.FindAt(0);
            Assert.IsTrue(a.Length == 1);
        }

        [TestMethod]
        public void Test_with_overlaps()
        {
            var t = new IntervalTree<Interval<int>, int>();
            t.Add(Interval.Create(1, 10));
            t.Add(Interval.Create(3, 7));
            t.Add(Interval.Create(5, 5));

            Assert.IsTrue(t.FindAt(0).Length == 0);
            Assert.IsTrue(t.FindAt(1).Length == 1);
            Assert.IsTrue(t.FindAt(2).Length == 1);
            Assert.IsTrue(t.FindAt(3).Length == 2);
            Assert.IsTrue(t.FindAt(4).Length == 2);
            Assert.IsTrue(t.FindAt(5).Length == 3);
            Assert.IsTrue(t.FindAt(6).Length == 2);
            Assert.IsTrue(t.FindAt(7).Length == 2);
            Assert.IsTrue(t.FindAt(8).Length == 1);
            Assert.IsTrue(t.FindAt(9).Length == 1);
            Assert.IsTrue(t.FindAt(10).Length == 1);
            Assert.IsTrue(t.FindAt(11).Length == 0);
        }

        [TestMethod]
        public void Test_find_overlapping()
        {
            var t = new IntervalTree<int>();
            t.Add(5, 10);
            Assert.IsTrue(t.ContainsOverlappingInterval(Interval.Create(0, 5)));
            Assert.IsTrue(t.ContainsOverlappingInterval(Interval.Create(6, 7)));
            Assert.IsTrue(t.ContainsOverlappingInterval(Interval.Create(8, 15)));
            Assert.IsTrue(t.ContainsOverlappingInterval(Interval.Create(0, 20)));
            Assert.IsFalse(t.ContainsOverlappingInterval(Interval.Create(1, 4)));
        }

    }

}
