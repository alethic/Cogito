using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http.Internal
{

    [Module(typeof(IWebApiModule))]
    public class WebApiModule : IWebApiModule
    {

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(lifecycle != null);
        }

        ILifecycleManager<IWebApiModule> lifecycle;
        HttpConfiguration http;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public WebApiModule(
            ILifecycleManager<IWebApiModule> lifecycle)
        {
            Contract.Requires<ArgumentNullException>(lifecycle != null);
            
            this.lifecycle = lifecycle;
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }

        public void Configure(HttpConfiguration http)
        {
            if (http != null)
                throw new WebApiException(this, "Module already configured.");

            this.http = http;
            this.lifecycle.Init();
        }

        public bool IsConfigured
        {
            get { return http != null; }
        }

        public HttpConfiguration Http
        {
            get { return http; }
        }

    }

}

