using System.Web.Routing;

namespace Cogito.Web.Mvc
{

    public interface IMvcConfiguration
    {

        /// <summary>
        /// Gets whether or not MVC is available.
        /// </summary>
        bool Available { get; set; }

        RouteCollection Routes { get; }

    }

}
