using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class UInt32ExtensionsTests
    {

        [TestMethod]
        public void Can_lzcnt_uint()
        {
            ((uint)0).CountLeadingZeros().Should().Be(32);
            ((uint)1).CountLeadingZeros().Should().Be(31);
            ((uint)2).CountLeadingZeros().Should().Be(30);
        }

    }

}
