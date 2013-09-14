using System.Web.Http;

namespace Cogito.Web.Http
{

    public interface IApiConfiguration
    {

        bool Available { get; set; }

        HttpConfiguration Configuration { get; set; }

    }

}
