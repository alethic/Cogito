using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.ServiceBus.MassTransit
{

    /// <summary>
    /// Provides instances of the global bus.
    /// </summary>
    public class ServiceBusProvider
    {

        readonly IEnumerable<IServiceBusFactory> factories;
        readonly Lazy<IServiceBus> bus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="factories"></param>
        [ImportingConstructor]
        public ServiceBusProvider(
            [ImportMany] IServiceBusFactory[] factories)
        {
            Contract.Requires<ArgumentNullException>(factories != null);
            Contract.Requires<ArgumentNullException>(factories.Length > 0);

            this.factories = factories;
            this.bus = new Lazy<IServiceBus>(() => factories.Select(i => i.CreateBus()).FirstOrDefault(i => i != null));
        }

        [Export(typeof(IServiceBus))]
        public IServiceBus Bus
        {
            get { return bus.Value; }
        }

    }

    /// <summary>
    /// Provides instances of scoped buses.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public class ServiceBusProvider<TScope>
    {

        readonly IEnumerable<IServiceBusFactory<TScope>> factories;
        readonly Lazy<IServiceBus<TScope>> bus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="factory"></param>
        [ImportingConstructor]
        public ServiceBusProvider(
            [ImportMany] IEnumerable<IServiceBusFactory<TScope>> factories)
        {
            Contract.Requires<ArgumentNullException>(factories != null);

            this.factories = factories;
            this.bus = new Lazy<IServiceBus<TScope>>(() => factories.Select(i => i.CreateBus()).FirstOrDefault(i => i != null));
        }

        [Export(typeof(IServiceBus<>))]
        public IServiceBus<TScope> Bus
        {
            get { return bus.Value; }
        }

    }

}
