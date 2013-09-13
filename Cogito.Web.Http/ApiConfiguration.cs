using System.ComponentModel.Composition;
using System.Web.Http;

namespace Cogito.Web.Http
{

    [Export(typeof(IApiConfiguration))]
    public class ApiConfiguration : IApiConfiguration
    {

        public bool Configured { get; set; }

        [Export]
        public HttpConfiguration Configuration { get; set; }

    }

}
