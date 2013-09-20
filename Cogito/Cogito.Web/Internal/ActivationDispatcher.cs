using System;
using System.ComponentModel.Composition;

using Cogito.Application;
using Cogito.Application.Lifecycle;

namespace Cogito.Web.Internal
{

    [Export(typeof(IOnInit<IWebApplication>))]
    public class ActivationDispatcher : IOnInit<IWebApplication>
    {

        ILifecycleManager<IWebApplication> lifecycle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="lifecycle"></param>
        [ImportingConstructor]
        public ActivationDispatcher(
            ILifecycleManager<IWebApplication> lifecycle)
        {
            this.lifecycle = lifecycle;
        }

        /// <summary>
        /// Subscribe to activation events.
        /// </summary>
        public void OnInit()
        {
            ActivationEvents.PreStart += ActivationEvents_PreStart;
            ActivationEvents.PostStart += ActivationEvents_PostStart;
            ActivationEvents.Shutdown += ActivationEvents_Shutdown;
        }

        void ActivationEvents_PreStart(object sender, EventArgs e)
        {
            lifecycle.BeforeStart();
        }

        void ActivationEvents_PostStart(object sender, EventArgs e)
        {
            lifecycle.AfterStart();
        }

        void ActivationEvents_Shutdown(object sender, EventArgs e)
        {
            lifecycle.Shutdown();
        }

    }

}
