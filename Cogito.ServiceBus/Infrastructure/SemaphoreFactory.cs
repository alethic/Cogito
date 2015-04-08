using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

namespace Cogito.ServiceBus.Infrastructure
{

    [Export(typeof(ISemaphoreFactory<>))]
    public class SemaphoreFactory<TIdentity> :
        ISemaphoreFactory<TIdentity>
    {

        readonly IServiceBus bus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        [ImportingConstructor]
        public SemaphoreFactory(IServiceBus bus)
        {
            Contract.Requires<ArgumentNullException>(bus != null);

            this.bus = bus;
        }

        public Semaphore<TIdentity> Create()
        {
            return new Semaphore<TIdentity>(bus, 1);
        }

    }

}
