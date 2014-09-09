using System;
using System.ComponentModel.Composition;

using MassTransit;
using MassTransit.BusConfigurators;

namespace Cogito.ServiceBus.MassTransit
{

    /// <summary>
    /// Creates service bus instances.
    /// </summary>
    [Export(typeof(ServiceBusFactory))]
    public class ServiceBusFactory
    {

        static readonly string VHOST = "";
        static readonly string BASE_URI = @"rabbitmq://localhost/";

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
        public global::MassTransit.IServiceBus CreateBus()
        {
            return global::MassTransit.ServiceBusFactory.New(sbc =>
            {
                Configure(sbc, Guid.NewGuid().ToString("N"));
            });
        }

        /// <summary>
        /// Gets a generic <see cref="IServiceBus"/> instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public global::MassTransit.IServiceBus CreateBus<T>()
        {
            return global::MassTransit.ServiceBusFactory.New(sbc =>
            {
                Configure(sbc, typeof(T).FullName, false);
            });
        }

    }

}
