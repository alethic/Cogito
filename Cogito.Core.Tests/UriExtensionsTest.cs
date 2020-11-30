using System;

using FluentAssertions;

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

        [TestMethod]
        public void Can_combine_relative_uri_with_query()
        {
            var uri = new Uri("foo/bar?arg1=value1&arg2=value2", UriKind.Relative);
            uri = uri.Combine(new Uri("bar/blah", UriKind.Relative));
            Assert.AreEqual("foo/bar/bar/blah?arg1=value1&arg2=value2", uri.ToString());
        }

        [TestMethod]
        public void Can_append_query_arg_to_empty()
        {
            var u = new Uri("http://www.google.com").AppendQuery("name", "value");
            u.Should().Be(new Uri("http://www.google.com?name=value"));
        }

        [TestMethod]
        public void Can_append_query_arg_to_existing()
        {
            var u = new Uri("http://www.google.com?a=v").AppendQuery("name", "value");
            u.Should().Be(new Uri("http://www.google.com?a=v&name=value"));
        }

        [TestMethod]
        public void Can_append_query_arg_to_relative()
        {
            var u = new Uri("foo/bar", UriKind.Relative).AppendQuery("name", "value");
            u.Should().Be(new Uri("foo/bar?name=value", UriKind.Relative));
        }

        [TestMethod]
        public void Can_append_query_arg_to_relative_existing()
        {
            var u = new Uri("foo/bar?a=v", UriKind.Relative).AppendQuery("name", "value");
            u.Should().Be(new Uri("foo/bar?a=v&name=value", UriKind.Relative));
        }

    }

}
