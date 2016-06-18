using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class ExceptionExtensionsTests
    {

        [TestMethod]
        public void Test_expand()
        {
            var l = new List<Exception>();
            var ae = new AggregateException(new AggregateException(new AggregateException(new FormatException()), new AggregateException(new FormatException())));
            foreach (var e in ae.Expand())
            {
                Assert.IsTrue(e is Exception);
                l.Add(e);
            }
            Assert.AreEqual(2, l.Count);
        }

    }

}
