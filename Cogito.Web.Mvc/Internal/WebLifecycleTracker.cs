using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc.Internal
{

    /// <summary>
    /// Watches the state of the <see cref="IWebModule"/> and ensures the <see cref="IMvcModule"/> state matches.
    /// </summary>
    [OnStateChange(typeof(IWebModule))]
    public class WebLifecycleTracker : IOnStateChange<IWebModule>
    {

        ILifecycleManager<IMvcModule> lifecycle;

        [ImportingConstructor]
        public WebLifecycleTracker(
            ILifecycleManager<IMvcModule> lifecycle)
            : base()
        {
            Contract.Requires<ArgumentNullException>(lifecycle != null);

            this.lifecycle = lifecycle;
        }

        public void OnStateChange(State state)
        {
            lifecycle.SetState(state);
        }

    }

}
