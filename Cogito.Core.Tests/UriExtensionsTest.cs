using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests
{

    [TestClass]
    public class UriExtensionsTest
    {

        [TestMethod]
        public void Can_combine_absolute_uri()
        {
            var uri = new Uri("http://www.google.com/foo");
            uri = uri.Combine("bar", "blah");
            Assert.AreEqual("http://www.google.com/foo/bar/blah", uri.ToString());
        }

        [TestMethod]
        public void Can_combine_absolute_uri_with_query()
        {
            var uri = new Uri("http://www.google.com/foo?arg1=value1&arg2=value2");
            uri = uri.Combine("bar", "blah");
            Assert.AreEqual("http://www.google.com/foo/bar/blah?arg1=value1&arg2=value2", uri.ToString());
        }

        [TestMethod]
        public void Can_combine_relative_uris()
        {
            var uri = new Uri("foo/bar", UriKind.Relative);
            uri = uri.Combine("bar", "blah");
            Assert.AreEqual("foo/bar/bar/blah", uri.ToString());
        }

        [TestMethod]
        public void Can_combine_relative_uris_rooted()
        {
            var uri = new Uri("/foo/bar", UriKind.Relative);
            uri = uri.Combine("bar", "blah");
            Assert.AreEqual("/foo/bar/bar/blah", uri.ToString());
        }

        [TestMethod]
        public void Can_combine_relative_uris_with_query()
        {
            var uri = new Uri("foo/bar?arg1=value1&arg2=value2", UriKind.Relative);
            uri = uri.Combine("bar", "blah");
            Assert.AreEqual("foo/bar/bar/blah?arg1=value1&arg2=value2", uri.ToString());
        }

    }

}
