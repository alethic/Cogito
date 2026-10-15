using System.Numerics;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class BitOperationsTests
    {

        [TestMethod]
        public void Can_lzcnt_uint()
        {
            BitOperations.LeadingZeroCount(0u).Should().Be(32);
            BitOperations.LeadingZeroCount(1u).Should().Be(31);
            BitOperations.LeadingZeroCount(2u).Should().Be(30);
            BitOperations.LeadingZeroCount(uint.MaxValue).Should().Be(0);
        }

        [TestMethod]
        public void Can_lzcnt_ulong()
        {
            BitOperations.LeadingZeroCount(0ul).Should().Be(64);
            BitOperations.LeadingZeroCount(1ul).Should().Be(63);
            BitOperations.LeadingZeroCount(2ul).Should().Be(62);
            BitOperations.LeadingZeroCount(1ul << 32).Should().Be(31);
            BitOperations.LeadingZeroCount(ulong.MaxValue).Should().Be(0);
        }

    }

}
