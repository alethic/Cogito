using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Cogito.ServiceModel.Web.Routing
{

    /// <summary>
    /// <see cref="ServiceHostFactoryBase"/> wrapper to inject custom behaviors.
    /// </summary>
    class DynamicServiceRouteServiceHostFactory :
        ServiceHostFactoryBase
    {

        readonly ServiceHostFactoryBase primary;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="primary"></param>
        public DynamicServiceRouteServiceHostFactory(ServiceHostFactoryBase primary) :
            base()
        {
            this.primary = primary ?? throw new ArgumentNullException(nameof(primary));
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var h = primary.CreateServiceHost(constructorString, baseAddresses);
            h.Description.Behaviors.Add(new DynamicServiceRouteEndpointBehavior());
            return h;
        }

    }

}