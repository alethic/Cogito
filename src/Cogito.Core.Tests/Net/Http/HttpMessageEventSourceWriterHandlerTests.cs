using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Threading.Tasks;
using Cogito.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Core.Tests.Net.Http
{

    [TestClass]
    public class HttpMessageEventSourceWriterHandlerTests
    {

        [TestMethod]
        public async Task Test_request()
        {
            var h = new HttpClient(new HttpMessageEventSourceWriterHandler());
            var r = new HttpRequestMessage(HttpMethod.Get, "http://www.google.com");
            await h.SendAsync(r);
        }

    }
}
