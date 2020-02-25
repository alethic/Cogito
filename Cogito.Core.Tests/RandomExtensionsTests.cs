using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class RandomExtensionsTests
    {

        [TestMethod]
        public void Should_generate_random_int64()
        {
            var r = new Random();
            var l = r.NextInt64(long.MinValue, long.MaxValue);
        }

    }

}
