using System;
using System.ComponentModel.Composition;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Internal
{

    /// <summary>
    /// Dispatches events from the <see cref="ActivationEvents"/> class into the container.
    /// </summary>
    [OnInit(typeof(IWebModule))]
    public class ActivationDispatcher : IOnInit<IWebModule>, IDisposable
    {

        ILifecycleManager<IWebModule> lifecycle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="lifecycle"></param>
        [ImportingConstructor]
        public ActivationDispatcher(
            ILifecycleManager<IWebModule> lifecycle)
        {
            this.lifecycle = lifecycle;
        }

        /// <summary>
        /// Subscribe to activation events at the earliest point after configuration.
        /// </summary>
        public void OnInit()
        {
            ActivationEvents.PreStart += ActivationEvents_PreStart;
            ActivationEvents.PostStart += ActivationEvents_PostStart;
            ActivationEvents.Shutdown += ActivationEvents_Shutdown;

            if (ActivationEvents.HasRunPreStart)
                lifecycle.BeforeStart();
            if (ActivationEvents.HasRunPostStart)
                lifecycle.AfterStart();
            if (ActivationEvents.HasRunShutdown)
                lifecycle.Shutdown();
        }

        void ActivationEvents_PreStart(object sender, EventArgs args)
        {
            lifecycle.BeforeStart();
        }

        void ActivationEvents_PostStart(object sender, EventArgs args)
        {
            lifecycle.AfterStart();
        }

        void ActivationEvents_Shutdown(object sender, EventArgs args)
        {
            lifecycle.Shutdown();
        }

        void IDisposable.Dispose()
        {
            ActivationEvents.PreStart -= ActivationEvents_PreStart;
            ActivationEvents.PostStart -= ActivationEvents_PostStart;
            ActivationEvents.Shutdown -= ActivationEvents_Shutdown;
        }

    }

}
