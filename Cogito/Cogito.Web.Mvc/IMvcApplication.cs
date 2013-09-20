using System.Web;
using System.Web.Routing;

using Cogito.Application;

namespace Cogito.Web.Mvc
{

    public interface IMvcApplication : IApplication
    {

        /// <summary>
        /// Activates the MVC application components.
        /// </summary>
        /// <param name="application"></param>
        /// <param name="routes"></param>
        void Activate(HttpApplication application, RouteCollection routes);

        /// <summary>
        /// Gets whether or not the application is activated.
        /// </summary>
        bool Activated { get; }

        /// <summary>
        /// Routing table.
        /// </summary>
        RouteCollection Routes { get; }

    }

}
