using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace ISIS.HigherGround.Web.Site.Controllers
{

    [Export(typeof(IController))]
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
