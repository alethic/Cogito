using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class UriExtensionsTest
    {

        [TestMethod]
        public void Test_Combine()
        {
            var uri = new Uri("http://www.google.com/foo");
            uri = uri.Combine("bar").Combine("blah");
            Assert.AreEqual("http://www.google.com/foo/bar/blah", uri.ToString());
        }

        [TestMethod]
        public void Test_Combine_Query()
        {
            var uri = new Uri("http://www.google.com/foo?arg1=value1&arg2=value2");
            uri = uri.Combine("bar").Combine("blah");
            Assert.AreEqual("http://www.google.com/foo/bar/blah?arg1=value1&arg2=value2", uri.ToString());
        }

    }

}
