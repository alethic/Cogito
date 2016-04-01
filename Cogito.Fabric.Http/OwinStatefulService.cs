using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Threading.Tasks;

using Microsoft.Owin;
using Microsoft.ServiceFabric.Services.Communication.Runtime;

using Owin;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Describes a service that exposes an OWIN endpoint.
    /// </summary>
    public abstract class OwinStatefulService :
        Cogito.Fabric.StatefulService
    {

        readonly string appRoot;
        readonly string endpointName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="appRoot"></param>
        /// <param name="endpointName"></param>
        public OwinStatefulService(StatefulServiceContext context, string appRoot, string endpointName = "HttpServiceEndpoint")
            : base(context)
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
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            yield return new ServiceReplicaListener(p => new OwinCommunicationListener(endpointName, appRoot, ConfigureInternal, p));
        }

        /// <summary>
        /// Configures the <see cref="IAppBuilder"/>.
        /// </summary>
        /// <param name="app"></param>
        void ConfigureInternal(IAppBuilder app)
        {
            Contract.Requires<ArgumentNullException>(app != null);

            // attach service to context
            app.Use(async (context, func) =>
            {
                context.SetService(this);
                await func();
            });

            // begin user configuration
            Configure(app);
        }

        /// <summary>
        /// Configures the <see cref="IAppBuilder"/>.
        /// </summary>
        /// <param name="app"></param>
        protected virtual void Configure(IAppBuilder app)
        {
            Contract.Requires<ArgumentNullException>(app != null);

            app.Run(RunRequest);
        }

        /// <summary>
        /// Invoked when an incoming request is received unless the user has overridden the <see cref="Configure(IAppBuilder)"/> method.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual Task RunRequest(IOwinContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null);

            return Task.FromResult(true);
        }

    }

}
