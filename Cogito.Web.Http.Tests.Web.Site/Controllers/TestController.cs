using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cogito.Web.Http.Tests.Web.Site.Controllers
{

    public class TestController :
        ApiController
    {

        [HttpGet]
        [Route("api/Test/TestString")]
        public HttpResponseMessage TestString([FromHeader("X-Value")] string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Test/TestInt")]
        public HttpResponseMessage TestGuid([FromHeader("X-Value")] int value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Test/TestGuid")]
        public HttpResponseMessage TestGuid([FromHeader("X-Value")] Guid? value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        
        [HttpGet]
        [Route("api/Test/TestGuid2")]
        public HttpResponseMessage TestGuid2([FromUri(Name = "value")] Guid value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }

}
