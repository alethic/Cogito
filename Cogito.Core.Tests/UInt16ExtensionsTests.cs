using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class UInt16ExtensionsTests
    {

        [TestMethod]
        public void Can_lzcnt_ushort()
        {
            ((ushort)0).CountLeadingZeros().Should().Be(16);
            ((ushort)1).CountLeadingZeros().Should().Be(15);
            ((ushort)2).CountLeadingZeros().Should().Be(14);
        }

    }

}
