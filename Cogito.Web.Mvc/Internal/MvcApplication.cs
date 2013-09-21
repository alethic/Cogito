using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Routing;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc.Internal
{

    [Export(typeof(IMvcApplication))]
    public class MvcApplication : IMvcApplication
    {

        ILifecycleManager<IMvcApplication> lifecycle;
        bool activated;
        RouteCollection routes;
        IWebApplication web;
        ILifecycleManager<IWebApplication> webLifecycle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public MvcApplication(
            ILifecycleManager<IMvcApplication> lifecycle,
            IWebApplication web,
            ILifecycleManager<IWebApplication> webLifecycle)
        {
            Contract.Requires<ArgumentNullException>(lifecycle != null);
            Contract.Requires<ArgumentNullException>(web != null);
            Contract.Requires<ArgumentNullException>(webLifecycle != null);

            this.lifecycle = lifecycle;
            this.web = web;
            this.webLifecycle = webLifecycle;

            // hook states together
            this.webLifecycle.StateChanged += (s, a) => lifecycle.EnsureState(a.State);
            this.lifecycle.StateChanged += (s, a) => webLifecycle.EnsureState(a.State);
        }

        public void Activate(HttpApplication http, RouteCollection routes)
        {
            if (activated)
                return;

            this.web.Activate(http);
            this.activated = true;
            this.routes = routes;
            this.lifecycle.Init();
        }

        public bool Activated
        {
            get { return activated; }
        }

        public RouteCollection Routes
        {
            get { return routes; ; }
        }

    }

}

