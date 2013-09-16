using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Web.Http;
using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http.Internal
{

    [Export(typeof(IApiApplication))]
    public class ApiApplication : IApiApplication
    {

        ILifecycleManager<IApiApplication> lifecycle;
        bool activated;
        HttpConfiguration http;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public ApiApplication(
            ILifecycleManager<IApiApplication> lifecycle)
        {
            this.lifecycle = lifecycle;
        }

        public void Activate(HttpConfiguration http)
        {
            Contract.Requires<ArgumentNullException>(http != null);

            if (activated)
                return;

            this.activated = true;
            this.http = http;
            this.lifecycle.Init();
        }

        public bool Activated
        {
            get { return activated; }
        }

        public HttpConfiguration Http
        {
            get { return http; }
        }

    }

}

