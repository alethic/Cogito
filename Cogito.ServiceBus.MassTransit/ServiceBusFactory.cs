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
            var uri = base.BuildQueueUri(Guid.NewGuid().ToString("N"), true);

            // each global bus obtains it's own unique ID
            return new ServiceBus(new Lazy<global::MassTransit.IServiceBus>(() => base.CreateBus(uri), true), uri);
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
            var uri = base.BuildQueueUri(typeof(TScope).FullName, false);

            return new ServiceBus<TScope>(new Lazy<global::MassTransit.IServiceBus>(() => base.CreateBus(uri), true), uri);
        }

    }

    /// <summary>
    /// Common MassTransit service bus factory.
    /// </summary>
    public abstract class ServiceBusFactoryBase
    {

        static readonly ConfigurationSection cfg = ConfigurationSection.GetDefaultSection();
        static readonly string HOST = cfg.Host.TrimOrNull() ?? "localhost";
        static readonly string VHOST = cfg.VHost.TrimOrNull() ?? "";
        static readonly string USERNAME = cfg.Username.TrimOrNull() ?? "guest";
        static readonly string PASSWORD = cfg.Password.TrimOrNull() ?? "guest";
        static readonly int PREFETCH = cfg.Prefetch;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ServiceBusFactoryBase()
        {

        }

        /// <summary>
        /// Builds a service bus queue URI.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="temporary"></param>
        /// <returns></returns>
        protected Uri BuildQueueUri(string queue, bool temporary)
        {
            return BuildQueueUri(HOST, VHOST, queue, temporary, PREFETCH);
        }

        /// <summary>
        /// Builds a service bus queue URI.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="vhost"></param>
        /// <param name="queue"></param>
        /// <param name="temporary"></param>
        /// <param name="prefetch"></param>
        /// <returns></returns>
        protected Uri BuildQueueUri(string host, string vhost, string queue, bool temporary, int prefetch = 0)
        {
            Contract.Requires<ArgumentNullException>(host != null);
            Contract.Requires<ArgumentNullException>(vhost != null);
            Contract.Requires<ArgumentNullException>(queue != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(host));
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(queue));
            Contract.Requires<ArgumentOutOfRangeException>(prefetch >= 0);

            var b = new UriBuilder(new Uri(new Uri(new Uri(string.Format(@"rabbitmq://{0}/", host), UriKind.Absolute), vhost + "/"), queue));
            if (temporary) b.AppendQuery("temporary", "true");
            if (prefetch > 0) b.AppendQuery("prefetch", prefetch.ToString());
            return b.Uri;
        }

        /// <summary>
        /// Applies default configuration.
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="uri"></param>
        protected void Configure(ServiceBusConfigurator configurator, Uri uri)
        {
            Contract.Requires<ArgumentNullException>(configurator != null);
            Contract.Requires<ArgumentNullException>(uri != null);
            Trace.TraceInformation(@"{0}: [Uri=""{1}""]", GetType().FullName, uri);

            configurator.UseRabbitMq(x => x.ConfigureHost(uri, c => { c.SetUsername(USERNAME); c.SetPassword(PASSWORD); }));
            configurator.SetCreateMissingQueues(true);
            configurator.DisablePerformanceCounters();
            configurator.UseBinarySerializer();
            configurator.ReceiveFrom(uri);
        }

        /// <summary>
        /// Gets a <see cref="IServiceBus"/> instance.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected global::MassTransit.IServiceBus CreateBus(Uri uri)
        {
            Contract.Requires<ArgumentNullException>(uri != null);

            return global::MassTransit.ServiceBusFactory.New(sbc => Configure(sbc, uri));
        }

    }

}
