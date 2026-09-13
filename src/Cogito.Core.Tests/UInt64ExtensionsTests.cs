using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class UInt64ExtensionsTests
    {

        [TestMethod]
        public void Can_lzcnt_ulong()
        {
            ((ulong)0).CountLeadingZeros().Should().Be(64);
            ((ulong)1).CountLeadingZeros().Should().Be(63);
            ((ulong)2).CountLeadingZeros().Should().Be(62);
        }

    }

}
