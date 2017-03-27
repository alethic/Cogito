using System;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Describes the routing of a given WCF service.
    /// </summary>
    public class DynamicServiceRouteAttribute :
        Attribute
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="route"></param>
        public DynamicServiceRouteAttribute(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentException(nameof(route));

            Route = route;
        }

        /// <summary>
        /// Gets the route of the service.
        /// </summary>
        public string Route { get; }

    }

}