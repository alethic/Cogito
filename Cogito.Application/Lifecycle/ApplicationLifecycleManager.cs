using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Composition;

namespace Cogito.Application
{

    /// <summary>
    /// Provides for execution of the application lifecycle events.
    /// </summary>
    [Export(typeof(IApplicationLifecycleManager))]
    public class ApplicationLifecycleManager : IApplicationLifecycleManager
    {

        enum State
        {

            None,
            BeforeStart,
            Start,
            AfterStart,
            BeforeShutdown,
            Shutdown,

        }

        State state = State.None;
        IEnumerable<IApplicationBeforeStart> beforeStart;
        IEnumerable<IApplicationStart> start;
        IEnumerable<IApplicationAfterStart> afterStart;
        IEnumerable<IApplicationBeforeShutdown> beforeShutdown;
        IEnumerable<IApplicationShutdown> shutdown;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="beforeStart"></param>
        /// <param name="start"></param>
        /// <param name="afterStart"></param>
        /// <param name="shutdown"></param>
        [ImportingConstructor]
        public ApplicationLifecycleManager(
            [Import(typeof(IImportCollection<IApplicationBeforeStart>))] IEnumerable<IApplicationBeforeStart> beforeStart,
            [Import(typeof(IImportCollection<IApplicationStart>))] IEnumerable<IApplicationStart> start,
            [Import(typeof(IImportCollection<IApplicationAfterStart>))] IEnumerable<IApplicationAfterStart> afterStart,
            [Import(typeof(IImportCollection<IApplicationBeforeShutdown>))] IEnumerable<IApplicationBeforeShutdown> beforeShutdown,
            [Import(typeof(IImportCollection<IApplicationShutdown>))] IEnumerable<IApplicationShutdown> shutdown)
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
            if (state < State.BeforeStart)
                foreach (var i in beforeStart)
                    i.OnBeforeStart();

            state = State.BeforeStart;
        }

        /// <summary>
        /// Runs the application Start events.
        /// </summary>
        public void Start()
        {
            if (state < State.BeforeStart)
                BeforeStart();

            if (state < State.Start)
                foreach (var i in start)
                    i.OnStart();

            state = State.Start;
        }

        /// <summary>
        /// Runs the application AfterStart events.
        /// </summary>
        public void AfterStart()
        {
            if (state < State.Start)
                Start();

            if (state < State.AfterStart)
                foreach (var i in afterStart)
                    i.OnAfterStart();

            state = State.AfterStart;
        }

        /// <summary>
        /// Runs the application BeforeShutdown events.
        /// </summary>
        public void BeforeShutdown()
        {
            if (state < State.AfterStart)
                AfterStart();

            if (state < State.BeforeShutdown)
                foreach (var i in beforeShutdown)
                    i.OnBeforeShutdown();

            state = State.BeforeShutdown;
        }

        /// <summary>
        /// Runs the application Shutdown events.
        /// </summary>
        public void Shutdown()
        {
            if (state < State.BeforeShutdown)
                BeforeShutdown();

            if (state < State.Shutdown)
                foreach (var i in shutdown)
                    i.OnShutdown();

            state = State.Shutdown;
        }

    }

}
