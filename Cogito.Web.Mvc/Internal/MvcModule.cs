using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Routing;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc.Internal
{

    [Module(typeof(IMvcModule))]
    public class MvcModule : IMvcModule
    {

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(web != null);
            Contract.Invariant(lifecycle != null);
        }

        IWebModule web;
        ILifecycleManager<IMvcModule> lifecycle;
        RouteCollection routes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public MvcModule(
            IWebModule web,
            ILifecycleManager<IMvcModule> lifecycle)
        {
            Contract.Requires<ArgumentNullException>(web != null);
            Contract.Requires<ArgumentNullException>(lifecycle != null);

            this.web = web;
            this.lifecycle = lifecycle;
        }

        public void Configure()
        {
            Contract.Requires<WebException>(RouteTable.Routes != null);
            Contract.Requires<WebException>(!IsConfigured, "Module already configured.");

            Configure(RouteTable.Routes);
        }

        public void Configure(RouteCollection routes)
        {
            Contract.Requires<ArgumentNullException>(routes != null);
            Contract.Requires<MvcException>(!IsConfigured, "Module already configured");

            this.routes = routes;
            this.web.Configure();
            this.lifecycle.Init();
        }

        public bool IsConfigured
        {
            get { return routes != null; }
        }

        public RouteCollection Routes
        {
            get { return routes; }
        }

        void IMvcModule.Configure()
        {
            Configure();
        }

        void IMvcModule.Configure(RouteCollection routes)
        {
            Configure(routes);
        }

    }

}

