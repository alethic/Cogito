using System;

namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Base lifecycle component implementation that is invoked on all lifecycle events and determines their
    /// applicability through a boolean.
    /// </summary>
    public abstract class LifecycleComponent :
        IApplicationBeforeStart,
        IApplicationStart,
        IApplicationAfterStart,
        IApplicationBeforeShutdown,
        IApplicationShutdown
    {

        Func<bool> enabled;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="enabled"></param>
        public LifecycleComponent(Func<bool> enabled)
        {
            this.enabled = enabled;
        }

        public virtual void OnBeforeStart()
        {

        }

        public virtual void OnStart()
        {

        }

        public virtual void OnAfterStart()
        {

        }

        public virtual void OnBeforeShutdown()
        {

        }

        public virtual void OnShutdown()
        {

        }

        void IApplicationBeforeStart.OnBeforeStart()
        {
            if (enabled())
                OnBeforeStart();
        }

        void IApplicationStart.OnStart()
        {
            if (enabled())
                OnStart();
        }

        void IApplicationAfterStart.OnAfterStart()
        {
            if (enabled())
                OnAfterStart();
        }

        void IApplicationBeforeShutdown.OnBeforeShutdown()
        {
            if (enabled())
                OnBeforeShutdown();
        }

        void IApplicationShutdown.OnShutdown()
        {
            if (enabled())
                OnShutdown();
        }

    }

}
