using System;

namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Base lifecycle component implementation that is invoked on all lifecycle events and determines their
    /// applicability through a boolean.
    /// </summary>
    public abstract class LifecycleComponent<T> :
        IOnInit<T>,
        IOnBeforeStart<T>,
        IOnStart<T>,
        IOnAfterStart<T>,
        IOnBeforeShutdown<T>,
        IOnShutdown<T>
        where T : IApplication
    {

        Func<bool> enabled;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="enabled"></param>
        public LifecycleComponent(
            Func<bool> enabled)
        {
            this.enabled = enabled;
        }

        public virtual void OnInit()
        {

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

        void IOnBeforeStart<T>.OnBeforeStart()
        {
            if (enabled())
                OnBeforeStart();
        }

        void IOnStart<T>.OnStart()
        {
            if (enabled())
                OnStart();
        }

        void IOnAfterStart<T>.OnAfterStart()
        {
            if (enabled())
                OnAfterStart();
        }

        void IOnBeforeShutdown<T>.OnBeforeShutdown()
        {
            if (enabled())
                OnBeforeShutdown();
        }

        void IOnShutdown<T>.OnShutdown()
        {
            if (enabled())
                OnShutdown();
        }

    }

}
