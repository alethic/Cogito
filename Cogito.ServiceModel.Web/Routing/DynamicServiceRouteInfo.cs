using System;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Description of an available dynamic service route.
    /// </summary>
    class DynamicServiceRouteInfo
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="route"></param>
        /// <param name="type"></param>
        public DynamicServiceRouteInfo(string route, Type type)
        {
            Route = route;
            Type = type;
        }

        /// <summary>
        /// Value of the route.
        /// </summary>
        public string Route { get; }

        /// <summary>
        /// Service type to expose at the route.
        /// </summary>
        public Type Type { get; }

    }

}