using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cogito.Web.Http.Tests.Web.Site.Controllers
{

    public class TestController : ApiController
    {

        [HttpGet]
        public IHttpActionResult TestFromHeader([FromHeader("X-Value")] string value)
        {
            if (value == null)
                throw new Exception();

            return Ok();
        }

    }

}
