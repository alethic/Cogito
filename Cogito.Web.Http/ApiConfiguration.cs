using System.ComponentModel.Composition;
using System.Web.Http;

namespace Cogito.Web.Http
{

    [Export(typeof(IApiConfiguration))]
    public class ApiConfiguration : IApiConfiguration
    {

        /// <summary>
        /// Gets whether or not WebApi is available.
        /// </summary>
        public bool Available { get; set; }

        [Export]
        public HttpConfiguration Configuration { get; set; }

    }

}
