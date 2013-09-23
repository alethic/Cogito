using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.Composition;

namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// Provides for execution of application lifecycle events.
    /// </summary>
    [Export(typeof(ILifecycleManager<>))]
    public class LifecycleManager<T> : ILifecycleManager<T>
        where T : class
    {

        State state = State.Unknown;
        ICompositionContext composition;
        IEnumerable<IOnInit<T>> init;
        IEnumerable<IOnBeforeStart<T>> beforeStart;
        IEnumerable<IOnStart<T>> start;
        IEnumerable<IOnAfterStart<T>> afterStart;
        IEnumerable<IOnBeforeShutdown<T>> beforeShutdown;
        IEnumerable<IOnShutdown<T>> shutdown;
        IEnumerable<IOnStateChange<T>> stateChange;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public LifecycleManager(
            ICompositionContext composition)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            this.composition = composition;
            this.init = composition.GetExportedValue<IImportCollection<IOnInit<T>>>();
            this.beforeStart = composition.GetExportedValue<IImportCollection<IOnBeforeStart<T>>>();
            this.start = composition.GetExportedValue<IImportCollection<IOnStart<T>>>();
            this.afterStart = composition.GetExportedValue<IImportCollection<IOnAfterStart<T>>>();
            this.beforeShutdown = composition.GetExportedValue<IImportCollection<IOnBeforeShutdown<T>>>();
            this.shutdown = composition.GetExportedValue<IImportCollection<IOnShutdown<T>>>();
            this.stateChange = composition.GetExportedValue<IImportCollection<IOnStateChange<T>>>();
        }

        /// <summary>
        /// Advances to the specified state.
        /// </summary>
        /// <param name="state"></param>
        public void SetState(State state)
        {
            switch (state)
            {
                case State.Init:
                    Init();
                    return;
                case State.BeforeStart:
                    BeforeStart();
                    break;
                case State.Start:
                    Start();
                    break;
                case State.AfterStart:
                    AfterStart();
                    break;
                case State.BeforeShutdown:
                    BeforeShutdown();
                    break;
                case State.Shutdown:
                    Shutdown();
                    break;
            }
        }

        /// <summary>
        /// Raised when the state is changed.
        /// </summary>
        public event EventHandler<StateChangeEventArgs> StateChange;

        /// <summary>
        /// Raises the StateChanged event.
        /// </summary>
        /// <param name="args"></param>
        void OnStateChanged(StateChangeEventArgs args)
        {
            if (StateChange != null)
                StateChange(this, args);
        }

        /// <summary>
        /// Runs the application BeforeStart events.
        /// </summary>
        public virtual void Init()
        {
            if (state >= State.Init)
                return;

            state = State.Init;

            foreach (var i in init)
                i.OnInit();

            OnStateChanged(new StateChangeEventArgs(state));
        }

        /// <summary>
        /// Runs the application BeforeStart events.
        /// </summary>
        public virtual void BeforeStart()
        {
            if (state >= State.BeforeStart)
                return;
            else if (state < State.Init)
                Init();

            state = State.BeforeStart;

            foreach (var i in beforeStart)
                i.OnBeforeStart();

            OnStateChanged(new StateChangeEventArgs(state));
        }

        /// <summary>
        /// Runs the application Start events.
        /// </summary>
        public virtual void Start()
        {
            if (state >= State.Start)
                return;
            else if (state < State.BeforeStart)
                BeforeStart();

            state = State.Start;

            foreach (var i in start)
                i.OnStart();

            OnStateChanged(new StateChangeEventArgs(state));
        }

        /// <summary>
        /// Runs the application AfterStart events.
        /// </summary>
        public virtual void AfterStart()
        {
            if (state >= State.AfterStart)
                return;
            else if (state < State.Start)
                Start();

            state = State.AfterStart;

            foreach (var i in afterStart)
                i.OnAfterStart();

            OnStateChanged(new StateChangeEventArgs(state));
        }

        /// <summary>
        /// Runs the application BeforeShutdown events.
        /// </summary>
        public virtual void BeforeShutdown()
        {
            if (state >= State.BeforeShutdown)
                return;
            else if (state < State.AfterStart)
                AfterStart();

            state = State.BeforeShutdown;

            foreach (var i in beforeShutdown)
                i.OnBeforeShutdown();

            OnStateChanged(new StateChangeEventArgs(state));
        }

        /// <summary>
        /// Runs the application Shutdown events.
        /// </summary>
        public virtual void Shutdown()
        {
            if (state >= State.Shutdown)
                return;
            else if (state < State.BeforeShutdown)
                BeforeShutdown();

            state = State.Shutdown;

            foreach (var i in shutdown)
                i.OnShutdown();

            OnStateChanged(new StateChangeEventArgs(state));
        }

    }

}
