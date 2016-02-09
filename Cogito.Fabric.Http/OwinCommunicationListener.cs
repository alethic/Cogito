using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Description;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;

using Owin;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Implements a Service Fabric <see cref="ICommunicationListener"/> that handles incoming OWIN requests.
    /// </summary>
    public class OwinCommunicationListener :
        ICommunicationListener
    {

        readonly string endpointName;
        readonly string appRoot;
        readonly Action<IAppBuilder> configure;
        readonly ServiceInitializationParameters serviceInitializationParameters;

        string listeningAddress;
        string publishAddress;
        IDisposable serverHandle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configure"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            Action<IAppBuilder> configure,
            ServiceInitializationParameters serviceInitializationParameters)
            : this(null, configure, serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(configure != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="appRoot"></param>
        /// <param name="configure"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            string appRoot,
            Action<IAppBuilder> configure,
            ServiceInitializationParameters serviceInitializationParameters)
            : this("HttpServiceEndpoint", appRoot, configure, serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(configure != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="endpointName"></param>
        /// <param name="appRoot"></param>
        /// <param name="configure"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            string endpointName,
            string appRoot,
            Action<IAppBuilder> configure,
            ServiceInitializationParameters serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(endpointName != null);
            Contract.Requires<ArgumentNullException>(configure != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);

            this.endpointName = endpointName;
            this.appRoot = appRoot;
            this.configure = configure;
            this.serviceInitializationParameters = serviceInitializationParameters;
        }

        /// <summary>
        /// Opens the communication channel.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            // obtain node context
            var nodeContext = await FabricRuntime.GetNodeContextAsync(TimeSpan.FromSeconds(15), cancellationToken);
            if (nodeContext == null)
                throw new FabricServiceNotFoundException("Could not obtain node context.");

            // listen address is that which we directly listen to
            listeningAddress = BuildListeningAddress();

            // publish address is that which we are accessible to by other nodes
            publishAddress = listeningAddress.Replace("+", nodeContext.IPAddressOrFQDN);

            try
            {
                // start listening
                serverHandle = WebApp.Start(listeningAddress, configure);

                // allow clients to contact us
                return publishAddress;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                StopWebServer();

                throw;
            }
        }

        /// <summary>
        /// Builds the listening address.
        /// </summary>
        /// <returns></returns>
        string BuildListeningAddress()
        {
            var serviceEndpoint = serviceInitializationParameters.CodePackageActivationContext.GetEndpoint(endpointName);

            if (serviceInitializationParameters is StatefulServiceInitializationParameters)
            {
                var p = (StatefulServiceInitializationParameters)serviceInitializationParameters;
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}://+:{1}/{2}/{3}/{4}",
                    GetSchema(serviceEndpoint),
                    serviceEndpoint.Port,
                    p.PartitionId,
                    p.ReplicaId,
                    Guid.NewGuid());
            }

            if (serviceInitializationParameters is StatelessServiceInitializationParameters)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}://+:{1}/{2}",
                    GetSchema(serviceEndpoint),
                    serviceEndpoint.Port,
                    string.IsNullOrWhiteSpace(appRoot) ? string.Empty : appRoot.TrimEnd('/') + '/');
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Gets the schema for the given <see cref="EndpointResourceDescription"/>.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        string GetSchema(EndpointResourceDescription endpoint)
        {
            Contract.Requires<ArgumentNullException>(endpoint != null);

            switch (endpoint.Protocol)
            {
                case EndpointProtocol.Http:
                    return "http";
                case EndpointProtocol.Https:
                    return "https";
                default:
                    throw new FabricEndpointNotFoundException("Unsupported endpoint protocol.");
            }
        }

        /// <summary>
        /// Closes the communication channel.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task CloseAsync(CancellationToken cancellationToken)
        {
            StopWebServer();

            return Task.FromResult(true);
        }

        /// <summary>
        /// Aborts the communication channel.
        /// </summary>
        public void Abort()
        {
            StopWebServer();
        }

        /// <summary>
        /// Stops the running web server.
        /// </summary>
        void StopWebServer()
        {
            if (serverHandle != null)
            {
                try
                {
                    serverHandle.Dispose();
                }
                catch (ObjectDisposedException)
                {
                    // no-op
                }
            }
        }

    }

}