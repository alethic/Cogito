using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Internal
{

    [Export(typeof(IWebApplication))]
    public class WebApplication : IWebApplication
    {

        ILifecycleManager<IWebApplication> lifecycle;
        bool activated;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public WebApplication(
            ILifecycleManager<IWebApplication> lifecycle)
        {
            this.lifecycle = lifecycle;
        }

        public void Activate(HttpApplication http)
        {
            if (activated)
                return;

            lifecycle.Init();
            activated = true;
        }

        public bool Activated
        {
            get { return activated; }
        }

    }

}

