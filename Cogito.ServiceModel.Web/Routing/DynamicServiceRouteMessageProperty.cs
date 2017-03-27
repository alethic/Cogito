using System.Web.Routing;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Describes the data associated with the dynamic service route.
    /// </summary>
    public class DynamicServiceRouteMessageProperty
    {

        /// <summary>
        /// Key of the property in message property dictionaries.
        /// </summary>
        public const string Key = nameof(DynamicServiceRouteMessageProperty);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="routeData"></param>
        public DynamicServiceRouteMessageProperty(RouteData routeData)
        {
            RouteData = routeData;
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        public RouteData RouteData { get; }

    }

}