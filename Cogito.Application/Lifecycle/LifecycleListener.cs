namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Base lifecycle component implementation that is invoked on all lifecycle events. Override the On methods to
    /// implement responses to lifecycle changes.
    /// </summary>
    public abstract class LifecycleListener<T> :
        IOnInit<T>,
        IOnBeforeStart<T>,
        IOnStart<T>,
        IOnAfterStart<T>,
        IOnBeforeShutdown<T>,
        IOnShutdown<T>
        where T : class
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public LifecycleListener()
        {

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
            OnBeforeStart();
        }

        void IOnStart<T>.OnStart()
        {
            OnStart();
        }

        void IOnAfterStart<T>.OnAfterStart()
        {
            OnAfterStart();
        }

        void IOnBeforeShutdown<T>.OnBeforeShutdown()
        {
            OnBeforeShutdown();
        }

        void IOnShutdown<T>.OnShutdown()
        {
            OnShutdown();
        }

    }

}
