using System;
using System.ComponentModel.Composition;

using MassTransit;
using MassTransit.BusConfigurators;

namespace Cogito.ServiceBus.MassTransit
{

    /// <summary>
    /// Creates shared service bus instances.
    /// </summary>
    [Export(typeof(IServiceBusFactory))]
    public class ServiceBusFactory :
        ServiceBusFactoryBase,
        IServiceBusFactory
    {

        public IServiceBus CreateBus()
        {
            // each global bus obtains it's own unique ID
            return new ServiceBus(base.CreateBus(Guid.NewGuid().ToString("N"), true));
        }

    }

    /// <summary>
    /// Creates scoped service bus instances.
    /// </summary>
    /// <typeparam name="TScope"></typeparam>
    [Export(typeof(IServiceBusFactory<>))]
    public class ServiceBusFactory<TScope> :
        ServiceBusFactoryBase,
        IServiceBusFactory<TScope>
    {

        public IServiceBus<TScope> CreateBus()
        {
            return new ServiceBus<TScope>(base.CreateBus(typeof(TScope).FullName, false));
        }

    }

    /// <summary>
    /// Common MassTransit service bus factory.
    /// </summary>
    public abstract class ServiceBusFactoryBase
    {

        static readonly string VHOST = "";
        static readonly string BASE_URI = @"rabbitmq://localhost/";

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ServiceBusFactoryBase()
        {

        }

        /// <summary>
        /// Builds a service bus queue URI.
        /// </summary>
        /// <param name="vhost"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Uri BuildQueueUri(string vhost, string queue, bool temporary)
        {
            var b = new UriBuilder(new Uri(new Uri(new Uri(BASE_URI, UriKind.Absolute), vhost), queue));
            if (temporary) b.Query = "temporary=true";
            return b.Uri;
        }

        /// <summary>
        /// Applies default configuration.
        /// </summary>
        /// <param name="configurator"></param>
        void Configure(ServiceBusConfigurator configurator, string queue, bool temporary = true)
        {
            configurator.UseRabbitMq();
            configurator.DisablePerformanceCounters();
            configurator.UseBinarySerializer();
            configurator.ReceiveFrom(BuildQueueUri(VHOST, queue, temporary));
            configurator.SetConcurrentConsumerLimit(1);
        }

        /// <summary>
        /// Gets a <see cref="IServiceBus"/> instance.
        /// </summary>
        /// <returns></returns>
        protected global::MassTransit.IServiceBus CreateBus(string queue, bool temporary)
        {
            return global::MassTransit.ServiceBusFactory.New(sbc =>
            {
                Configure(sbc, queue, temporary);
            });
        }

    }

}
