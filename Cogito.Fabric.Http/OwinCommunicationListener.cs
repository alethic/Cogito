using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Fabric;
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
        readonly Action<IAppBuilder> startup;
        readonly ServiceInitializationParameters serviceInitializationParameters;
        string listeningAddress;
        string publishAddress;
        IDisposable serverHandle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="startup"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            Action<IAppBuilder> startup,
            ServiceInitializationParameters serviceInitializationParameters)
            : this(null, startup, serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(startup != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="appRoot"></param>
        /// <param name="startup"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            string appRoot,
            Action<IAppBuilder> startup,
            ServiceInitializationParameters serviceInitializationParameters)
            : this("ServiceEndpoint", appRoot, startup, serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(startup != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="endpointName"></param>
        /// <param name="appRoot"></param>
        /// <param name="startup"></param>
        /// <param name="serviceInitializationParameters"></param>
        public OwinCommunicationListener(
            string endpointName,
            string appRoot,
            Action<IAppBuilder> startup,
            ServiceInitializationParameters serviceInitializationParameters)
        {
            Contract.Requires<ArgumentNullException>(endpointName != null);
            Contract.Requires<ArgumentNullException>(startup != null);
            Contract.Requires<ArgumentNullException>(serviceInitializationParameters != null);

            this.endpointName = endpointName;
            this.startup = startup;
            this.appRoot = appRoot;
            this.serviceInitializationParameters = serviceInitializationParameters;
        }

        /// <summary>
        /// Opens the communication channel.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {
            var serviceEndpoint = serviceInitializationParameters.CodePackageActivationContext.GetEndpoint(endpointName);
            int port = serviceEndpoint.Port;

            if (serviceInitializationParameters is StatefulServiceInitializationParameters)
            {
                var statefulInitParams = (StatefulServiceInitializationParameters)serviceInitializationParameters;

                listeningAddress = string.Format(
                    CultureInfo.InvariantCulture,
                    "http://+:{0}/{1}/{2}/{3}",
                    port,
                    statefulInitParams.PartitionId,
                    statefulInitParams.ReplicaId,
                    Guid.NewGuid());
            }
            else if (serviceInitializationParameters is StatelessServiceInitializationParameters)
            {
                listeningAddress = string.Format(
                    CultureInfo.InvariantCulture,
                    "http://+:{0}/{1}",
                    port,
                    string.IsNullOrWhiteSpace(appRoot) ? string.Empty : appRoot.TrimEnd('/') + '/');
            }
            else
            {
                throw new InvalidOperationException();
            }

            publishAddress = listeningAddress.Replace("+", FabricRuntime.GetNodeContext().IPAddressOrFQDN);

            try
            {
                serverHandle = WebApp.Start(listeningAddress, startup);

                return Task.FromResult(publishAddress);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                StopWebServer();

                throw;
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