using System.Web.Mvc;

using Cogito.Web.Mvc;

namespace ISIS.HigherGround.Web.Site.Controllers
{

    [Controller]
    [RoutePrefix("test")]
    public class ValuesController : Controller
    {

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }

}
