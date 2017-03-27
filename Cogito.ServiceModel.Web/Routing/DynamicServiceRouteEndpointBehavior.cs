using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// Attaches the <see cref="DynamicServiceRouteMessageInspector"/> to the service.
    /// </summary>
    public class DynamicServiceRouteEndpointBehavior :
        IServiceBehavior
    {

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var a in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
                foreach (var b in a.Endpoints)
                    b.DispatchRuntime.MessageInspectors.Add(new DynamicServiceRouteMessageInspector());
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

    }

}