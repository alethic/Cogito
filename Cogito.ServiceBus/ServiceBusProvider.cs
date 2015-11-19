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
    public class ServiceBusProvider :
        IDisposable
    {

        readonly IEnumerable<IServiceBusFactory> factories;
        Lazy<IServiceBus> bus;
        bool disposed;

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
            this.bus = new Lazy<IServiceBus>(() => factories.Select(i => i.CreateBus()).FirstOrDefault(i => i != null), true);
        }

        [Export(typeof(IServiceBus))]
        public IServiceBus Bus
        {
            get { return bus.Value; }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (bus != null)
                {
                    if (bus.IsValueCreated)
                        bus.Value.Dispose();

                    bus = null;
                }
            }

            disposed = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceBusProvider()
        {
            Dispose(false);
        }

    }

    /// <summary>
    /// Provides instances of scoped buses.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    public class ServiceBusProvider<TScope> :
        IDisposable
    {

        readonly IEnumerable<IServiceBusFactory<TScope>> factories;
        Lazy<IServiceBus<TScope>> bus;
        bool disposed;

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
            this.bus = new Lazy<IServiceBus<TScope>>(() => factories.Select(i => i.CreateBus()).FirstOrDefault(i => i != null), true);
        }

        [Export(typeof(IServiceBus<>))]
        public IServiceBus<TScope> Bus
        {
            get { return bus.Value; }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (bus != null)
                {
                    if (bus.IsValueCreated)
                        bus.Value.Dispose();

                    bus = null;
                }
            }

            disposed = true;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceBusProvider()
        {
            Dispose(false);
        }

    }

}
