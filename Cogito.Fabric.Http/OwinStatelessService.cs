using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Microsoft.Owin;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

using Owin;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Describes a service that exposes an OWIN endpoint.
    /// </summary>
    public abstract class OwinStatelessService :
        StatelessService
    {

        readonly string appRoot;
        readonly string endpointName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="appRoot"></param>
        /// <param name="endpointName"></param>
        public OwinStatelessService(string appRoot, string endpointName = "HttpServiceEndpoint")
        {
            Contract.Requires<ArgumentNullException>(appRoot != null);
            Contract.Requires<ArgumentNullException>(endpointName != null);

            this.appRoot = appRoot;
            this.endpointName = endpointName;
        }

        /// <summary>
        /// Creates the communication listener to expose this service over HTTP.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(p =>
                new OwinCommunicationListener(
                    endpointName,
                    appRoot,
                    Configure,
                    p));
        }

        /// <summary>
        /// Configures the <see cref="IAppBuilder"/>.
        /// </summary>
        /// <param name="appBuilder"></param>
        protected virtual void Configure(IAppBuilder appBuilder)
        {
            appBuilder.Run(Run);
        }

        /// <summary>
        /// Invoked when an incoming request is received.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual Task Run(IOwinContext context)
        {
            return Task.FromResult(true);
        }

    }

}
