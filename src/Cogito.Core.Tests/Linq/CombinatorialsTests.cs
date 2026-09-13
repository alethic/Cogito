using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cogito.Linq;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class CombanatorialsTests
    {

        [TestMethod]
        public void Test_combinations_equal_size()
        {
            var c = new[] { 1, 2, 3, 4 }.Combinations(4).ToArray();
            Assert.AreEqual(1, c.Length);
            Assert.AreEqual(4, c[0].Length);
            Assert.AreEqual(1, c[0][0]);
            Assert.AreEqual(2, c[0][1]);
            Assert.AreEqual(3, c[0][2]);
            Assert.AreEqual(4, c[0][3]);
        }

        [TestMethod]
        public void Test_combinations_unequal_size()
        {
            var c = new[] { 1, 2, 3, }.Combinations(2).ToArray();
            Assert.AreEqual(3, c.Length);
            Assert.IsTrue(c.All(i => i.Length == 2));
            Assert.IsTrue(c[0][0] == 1 && c[0][1] == 2);
            Assert.IsTrue(c[1][0] == 1 && c[1][1] == 3);
            Assert.IsTrue(c[2][0] == 2 && c[2][1] == 3);
        }

        [TestMethod]
        public void Test_permutations()
        {
            var c = new[] { 1, 2, 3 }.Permutations().ToArray();
            Assert.AreEqual(6, c.Length);
            Assert.IsTrue(c[0][0] == 1 && c[0][1] == 2 && c[0][2] == 3);
            Assert.IsTrue(c[1][0] == 1 && c[1][1] == 3 && c[1][2] == 2);
            Assert.IsTrue(c[2][0] == 2 && c[2][1] == 1 && c[2][2] == 3);
            Assert.IsTrue(c[3][0] == 2 && c[3][1] == 3 && c[3][2] == 1);
            Assert.IsTrue(c[4][0] == 3 && c[4][1] == 1 && c[4][2] == 2);
            Assert.IsTrue(c[5][0] == 3 && c[5][1] == 2 && c[5][2] == 1);
        }

        [TestMethod]
        public void Test_variations()
        {
            var c = new[] { 1, 2, 3 }.Variations(3).ToArray();
        }

    }

}
