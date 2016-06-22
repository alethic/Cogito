using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Cogito.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Net.Http
{

    [TestClass]
    public class HttpMessageEventSourceTests
    {

        [TestMethod]
        public void Test_event()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.temp.com");
            request.Content = new StringContent("hi");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("hello");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            response.RequestMessage = request;

            HttpMessageEventSource.Current.HttpRequestStart(request);
            HttpMessageEventSource.Current.HttpRequestStop(response);
        }

    }

}
