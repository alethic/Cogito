using System;
using System.ComponentModel.Composition;

namespace Cogito.ServiceBus
{

    [Export(typeof(IServiceObservable<,>))]
    [Export(typeof(IServiceContextObservable<,>))]
    public class ServiceObservable<TService, TMessage> :
        IServiceObservable<TService, TMessage>,
        IServiceContextObservable<TService, TMessage>
        where TMessage : class
    {

        readonly IServiceBus<TService> bus;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bus"></param>
        [ImportingConstructor]
        public ServiceObservable(IServiceBus<TService> bus)
        {
            this.bus = bus;
        }

        /// <summary>
        /// Gets the service bus.
        /// </summary>
        public IServiceBus<TService> Bus
        {
            get { return bus; }
        }

        /// <summary>
        /// Subscribes to the subscription.
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<TMessage> observer)
        {
            return bus.Subscribe<TMessage>(i => observer.OnNext(i));
        }

        /// <summary>
        /// Subscribes to the subscription.
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<IConsumeContext<TMessage>> observer)
        {
            return bus.Subscribe<TMessage>(i => observer.OnNext(i));
        }

    }

}
