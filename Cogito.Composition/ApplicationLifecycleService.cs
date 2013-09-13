using System.ComponentModel.Composition;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Provides for execution of the application lifecycle events.
    /// </summary>
    [Export(typeof(IApplicationLifecycleManager))]
    public class ApplicationLifecycleService : IApplicationLifecycleManager
    {

        ComposableCollection<IApplicationPreStart> preStart;
        ComposableCollection<IApplicationStart> start;
        ComposableCollection<IApplicationPostStart> postStart;
        ComposableCollection<IApplicationShutdown> shutdown;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="preStart"></param>
        /// <param name="start"></param>
        /// <param name="postStart"></param>
        /// <param name="shutdown"></param>
        [ImportingConstructor]
        public ApplicationLifecycleService(
            ComposableCollection<IApplicationPreStart> preStart,
            ComposableCollection<IApplicationStart> start,
            ComposableCollection<IApplicationPostStart> postStart,
            ComposableCollection<IApplicationShutdown> shutdown)
        {
            this.preStart = preStart;
            this.start = start;
            this.postStart = postStart;
            this.shutdown = shutdown;
        }

        /// <summary>
        /// Runs the application PreStart events.
        /// </summary>
        public void PreStart()
        {
            foreach (var i in preStart)
                i.Value.OnPreStart();
        }

        /// <summary>
        /// Runs the application Start events.
        /// </summary>
        public void Start()
        {
            foreach (var i in start)
                i.Value.OnStart();
        }

        /// <summary>
        /// Runs the application PostStart events.
        /// </summary>
        public void PostStart()
        {
            foreach (var i in postStart)
                i.Value.OnPostStart();
        }

        /// <summary>
        /// Runs the application Shutdown events.
        /// </summary>
        public void Shutdown()
        {
            foreach (var i in shutdown)
                i.Value.OnShutdown();
        }

    }

}
