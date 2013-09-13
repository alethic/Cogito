using System.Web.Http;

namespace Cogito.Web.Http
{

    public interface IApiConfiguration
    {

        bool Configured { get; set; }

        HttpConfiguration Configuration { get; set; }

    }

}
