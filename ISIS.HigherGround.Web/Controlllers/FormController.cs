using System.Web.Mvc;

using Cogito.Web.Mvc;

using ISIS.HigherGround.Web.Models;

namespace ISIS.HigherGround.Web.Controlllers
{

    [Controller]
    public class FormController : Controller
    {

        [HttpGet()]
        public FormModel Get()
        {
            return new FormModel();
        }

    }

}
