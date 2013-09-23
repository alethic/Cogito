using System.Web;
using System.Web.Routing;

using Cogito.Application;

namespace Cogito.Web.Mvc
{

    public interface IMvcModule : IModule
    {

        /// <summary>
        /// Activates the MVC application components.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="routes"></param>
        void Configure(RouteCollection routes);

        /// <summary>
        /// Activates the MVC application components.
        /// </summary>
        void Configure();

        /// <summary>
        /// Gets whether or not the application is activated.
        /// </summary>
        bool IsConfigured { get; }

        /// <summary>
        /// Routing table.
        /// </summary>
        RouteCollection Routes { get; }

    }

}
