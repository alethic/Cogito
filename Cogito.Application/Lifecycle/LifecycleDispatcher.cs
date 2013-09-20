namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Accepts a collection of <see cref="ILifecycleManager"/>s and provides methods to initiate lifecycle stages.
    /// </summary>
    public abstract class LifecycleDispatcher
    {

        ILifecycleManager<IApplication>[] managers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="managers"></param>
        public LifecycleDispatcher(
            params ILifecycleManager<IApplication>[] managers)
        {
            this.managers = managers;
        }

        public void BeforeStart()
        {
            foreach (var l in managers)
                l.BeforeStart();
        }

        public void Start()
        {
            foreach (var l in managers)
                l.Start();
        }

        public void AfterStart()
        {
            foreach (var l in managers)
                l.AfterStart();
        }

        public void Shutdown()
        {
            foreach (var l in managers)
                l.Shutdown();
        }

    }

}
