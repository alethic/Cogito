using System.ServiceModel;
using System.Web.Routing;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Describes the data associated with the dynamic service route.
    /// </summary>
    public class DynamicServiceRouteMessageProperty
    {

        /// <summary>
        /// Gets the value of this property for the current <see cref="OperationContext"/>.
        /// </summary>
        public static DynamicServiceRouteMessageProperty Current
        {
            get { return (DynamicServiceRouteMessageProperty)OperationContext.Current.IncomingMessageProperties[Key]; }
        }

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