using System;
using System.ComponentModel.Composition;

namespace Cogito.ServiceBus.MassTransit
{

    [Export(typeof(ServiceBusProvider))]
    public class ServiceBusProvider
    {

        readonly ServiceBusFactory factory;
        readonly Lazy<IServiceBus> bus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="factory"></param>
        [ImportingConstructor]
        public ServiceBusProvider(ServiceBusFactory factory)
        {
            this.factory = factory;
            this.bus = new Lazy<IServiceBus>(() => new ServiceBus(factory.CreateBus()));
        }

        [Export(typeof(IServiceBus))]
        IServiceBus Bus
        {
            get { return bus.Value; }
        }

    }

    [Export(typeof(ServiceBusProvider<>))]
    public class ServiceBusProvider<T>
    {

        readonly ServiceBusFactory factory;
        readonly Lazy<IServiceBus<T>> bus;
        readonly IServiceBus sharedBus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="factory"></param>
        [ImportingConstructor]
        public ServiceBusProvider(ServiceBusFactory factory, IServiceBus sharedBus)
        {
            this.factory = factory;
            this.sharedBus = sharedBus;
            this.bus = new Lazy<IServiceBus<T>>(() => new ServiceBus<T>(factory.CreateBus<T>(), sharedBus));
        }

        [Export(typeof(IServiceBus<>))]
        IServiceBus<T> Bus
        {
            get { return bus.Value; }
        }

    }

}
