using System.ComponentModel.Composition;

using Cogito.Composition;

namespace Cogito.Application
{

    /// <summary>
    /// Provides for execution of the application lifecycle events.
    /// </summary>
    [Export(typeof(IApplicationLifecycleManager))]
    public class ApplicationLifecycleService : IApplicationLifecycleManager
    {

        RecomposableCollection<IApplicationBeforeStart> beforeStart;
        RecomposableCollection<IApplicationStart> start;
        RecomposableCollection<IApplicationAfterStart> afterStart;
        RecomposableCollection<IApplicationBeforeShutdown> beforeShutdown;
        RecomposableCollection<IApplicationShutdown> shutdown;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="beforeStart"></param>
        /// <param name="start"></param>
        /// <param name="afterStart"></param>
        /// <param name="shutdown"></param>
        [ImportingConstructor]
        public ApplicationLifecycleService(
            RecomposableCollection<IApplicationBeforeStart> beforeStart,
            RecomposableCollection<IApplicationStart> start,
            RecomposableCollection<IApplicationAfterStart> afterStart,
            RecomposableCollection<IApplicationBeforeShutdown> beforeShutdown,
            RecomposableCollection<IApplicationShutdown> shutdown)
        {
            this.beforeStart = beforeStart;
            this.start = start;
            this.afterStart = afterStart;
            this.beforeShutdown = beforeShutdown;
            this.shutdown = shutdown;
        }

        /// <summary>
        /// Runs the application BeforeStart events.
        /// </summary>
        public void BeforeStart()
        {
            foreach (var i in beforeStart)
                i.Value.OnBeforeStart();
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
        /// Runs the application AfterStart events.
        /// </summary>
        public void AfterStart()
        {
            foreach (var i in afterStart)
                i.Value.OnAfterStart();
        }

        /// <summary>
        /// Runs the application BeforeShutdown events.
        /// </summary>
        public void BeforeShutdown()
        {
            foreach (var i in beforeShutdown)
                i.Value.OnBeforeShutdown();
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
