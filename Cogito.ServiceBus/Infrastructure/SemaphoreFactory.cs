using System.ComponentModel.Composition;

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
            this.bus = bus;
        }

        public Semaphore<TIdentity> Create()
        {
            return new Semaphore<TIdentity>(bus, 1);
        }

    }

}
