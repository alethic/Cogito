using System.Web.Routing;

namespace Cogito.Web.Mvc
{

    public interface IMvcConfiguration
    {

        bool Configured { get; set; }

        RouteCollection Routes { get; }

    }

}
