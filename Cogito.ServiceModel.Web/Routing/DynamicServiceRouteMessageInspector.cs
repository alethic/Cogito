using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Inspects messages destined to dynamically routed services.
    /// </summary>
    class DynamicServiceRouteMessageInspector :
        IDispatchMessageInspector
    {

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // append routing information to the message.
            request.Properties.Add(DynamicServiceRouteMessageProperty.Key, new DynamicServiceRouteMessageProperty(DynamicServiceRoute.GetCurrentRouteData()));
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }

    }

}