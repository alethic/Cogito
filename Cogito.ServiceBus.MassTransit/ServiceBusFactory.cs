using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
            return new ServiceBus(new Lazy<global::MassTransit.IServiceBus>(() => base.CreateBus(Guid.NewGuid().ToString("N"), true)));
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
            return new ServiceBus<TScope>(new Lazy<global::MassTransit.IServiceBus>(() => base.CreateBus(typeof(TScope).FullName, false), true));
        }

    }

    /// <summary>
    /// Common MassTransit service bus factory.
    /// </summary>
    public abstract class ServiceBusFactoryBase
    {

        static readonly ConfigurationSection cfg = ConfigurationSection.GetDefaultSection();
        static readonly string VHOST = cfg.VHost ?? "";
        static readonly string USERNAME = cfg.Username ?? "guest";
        static readonly string PASSWORD = cfg.Password ?? "guest";
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
            Contract.Requires<ArgumentNullException>(vhost != null);
            Contract.Requires<ArgumentNullException>(queue != null);

            var b = new UriBuilder(new Uri(new Uri(new Uri(BASE_URI, UriKind.Absolute), vhost + "/"), queue));
            if (temporary) b.Query = "temporary=true";
            return b.Uri;
        }

        /// <summary>
        /// Applies default configuration.
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="queue"></param>
        /// <param name="temporary"></param>
        void Configure(ServiceBusConfigurator configurator, string queue, bool temporary = true)
        {
            Contract.Requires<ArgumentNullException>(configurator != null);
            Contract.Requires<ArgumentNullException>(queue != null);

            var uri = BuildQueueUri(VHOST, queue, temporary);
            Trace.TraceInformation("ServiceBusFactory: Uri=\"{0}\"", uri);

            configurator.UseRabbitMq(x => x.ConfigureHost(uri, c => { c.SetUsername(USERNAME); c.SetPassword(PASSWORD); }));
            configurator.SetCreateMissingQueues(true);
            configurator.DisablePerformanceCounters();
            configurator.UseBinarySerializer();
            configurator.ReceiveFrom(uri);
            configurator.SetConcurrentConsumerLimit(1);
        }

        /// <summary>
        /// Gets a <see cref="IServiceBus"/> instance.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="temporary"></param>
        /// <returns></returns>
        protected global::MassTransit.IServiceBus CreateBus(string queue, bool temporary)
        {
            Contract.Requires<ArgumentNullException>(queue != null);

            return global::MassTransit.ServiceBusFactory.New(sbc =>
            {
                Configure(sbc, queue, temporary);
            });
        }

    }

}
