using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Internal base implementation of <see cref="ActivityActor"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ActivityActor :
        Cogito.Fabric.Actor,
        IRemindable
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActor()
        {

        }

        /// <summary>
        /// Implements the <see cref="IRemindable.ReceiveReminderAsync(string, byte[], TimeSpan, TimeSpan)"/> method so it can be reimplemented above.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task IRemindable.ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            return ReceiveReminderAsyncInternal(reminderName, context, dueTime, period);
        }

        /// <summary>
        /// New implementation of <see cref="ReceiveReminderAsyncInternal(string, byte[], TimeSpan, TimeSpan)"/>.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected internal abstract Task ReceiveReminderAsyncInternal(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        /// Overrides the <see cref="OnActivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            await OnActivateAsyncInternal();
        }

        /// <summary>
        /// New implementation of <see cref="OnActivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected internal abstract Task OnActivateAsyncInternal();

        /// <summary>
        /// Overrides the <see cref="OnDeactivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override async Task OnDeactivateAsync()
        {
            await base.OnDeactivateAsync();
            await OnDeactivateAsyncInternal();
        }

        /// <summary>
        /// New implementation of <see cref="OnDeactivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected internal abstract Task OnDeactivateAsyncInternal();

    }

    /// <summary>
    /// Represents a <see cref="Actor"/> that hosts a Windows Workflow Foundation activity.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TActivity> :
        ActivityActor,
        IActivityActorInternal,
        IActivityActor
        where TActivity : Activity
    {

        readonly ActivityWorkflowHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected ActivityActor()
            : base()
        {
            host = new ActivityWorkflowHost(this);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Activity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected virtual TActivity CreateActivity()
        {
            return (TActivity)Activator.CreateInstance(typeof(TActivity));
        }

        /// <summary>
        /// Creates the set of activity parameters to be passed to the workflow.
        /// </summary>
        /// <returns></returns>
        protected virtual IDictionary<string, object> CreateActivityInputs()
        {
            return new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the set of custom extensions to add to the workflow.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<object> GetWorkflowExtensions()
        {
            return Enumerable.Empty<object>();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected internal sealed override async Task OnActivateAsyncInternal()
        {
            await host.OnActivateAsync();
            await OnActivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnActivateAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected internal sealed override async Task OnDeactivateAsyncInternal()
        {
            await host.OnDeactivateAsync();
            await OnDeactivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnDeactivateAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Resets the workflow.
        /// </summary>
        /// <returns></returns>
        protected Task ResetAsync()
        {
            return host.ResetAsync();
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        protected Task RunAsync()
        {
            return host.RunAsync();
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, value, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, value);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected Task ResumeAsync(Bookmark bookmark, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return host.ResumeAsync(bookmark, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        protected Task ResumeAsync(Bookmark bookmark)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return host.ResumeAsync(bookmark);
        }

        /// <summary>
        /// Invoked when a reminder is fired.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected internal sealed override async Task ReceiveReminderAsyncInternal(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            await host.ReceiveReminderAsync(reminderName, context, dueTime, period);
            await ReceiveReminderAsync(reminderName, context, dueTime, period);
        }

        /// <summary>
        /// Reminder call back invoked when an actor reminder is triggered.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        protected virtual Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the activity workflow is persisted to the <see cref="IActorStateManager"/>.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnPersisted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when an <see cref="Exception"/> is thrown during the workflow operation.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected virtual Task OnException(Exception exception)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> is aborted.
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        protected virtual Task OnAborted(Exception reason)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> is idle and persistable.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnPersistableIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> goes idle.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> is faulted.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnFaulted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> is completed.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCompleted(ActivityInstanceState state, IDictionary<string, object> outputs)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor"/> is unloaded.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnUnloaded()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// This method is invoked by actor runtime an actor method has finished execution. Override this method for
        /// performing any actions after an actor method has finished execution.
        /// </summary>
        /// <param name="actorMethodContext"></param>
        /// <returns></returns>
        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await SaveStateAsync();
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

        #region IActivityActorInternal

        Activity IActivityActorInternal.CreateActivity()
        {
            return CreateActivity();
        }

        IDictionary<string, object> IActivityActorInternal.CreateActivityInputs()
        {
            return CreateActivityInputs() ?? new Dictionary<string, object>();
        }

        IEnumerable<object> IActivityActorInternal.GetWorkflowExtensions()
        {
            return GetWorkflowExtensions();
        }

        IActorStateManager IActivityActorInternal.StateManager
        {
            get { return StateManager; }
        }

        IActorTimer IActivityActorInternal.RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period)
        {
            return RegisterTimer(callback, state, dueTime, period);
        }

        void IActivityActorInternal.UnregisterTimer(IActorTimer timer)
        {
            UnregisterTimer(timer);
        }

        IActorReminder IActivityActorInternal.GetReminder(string reminderName)
        {
            return GetReminder(reminderName);
        }

        Task<IActorReminder> IActivityActorInternal.RegisterReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
        {
            return RegisterReminderAsync(reminderName, state, dueTime, period);
        }

        Task IActivityActorInternal.UnregisterReminderAsync(IActorReminder reminder)
        {
            return UnregisterReminderAsync(reminder);
        }

        async Task IActivityActorInternal.OnPersisted()
        {
            await OnPersisted();
        }

        Task IActivityActorInternal.OnException(Exception exception)
        {
            return OnException(exception);
        }

        Task IActivityActorInternal.OnAborted(Exception reason)
        {
            return OnAborted(reason);
        }

        Task IActivityActorInternal.OnPersistableIdle()
        {
            return OnPersistableIdle();
        }

        Task IActivityActorInternal.OnIdle()
        {
            return OnIdle();
        }

        Task IActivityActorInternal.OnFaulted()
        {
            return OnFaulted();
        }

        Task IActivityActorInternal.OnCompleted(ActivityInstanceState state, IDictionary<string, object> outputs)
        {
            return OnCompleted(state, outputs);
        }

        Task IActivityActorInternal.OnUnloaded()
        {
            return OnUnloaded();
        }

        Task IActivityActor.ResumeAsync(string bookmarkName, object value)
        {
            return ResumeAsync(bookmarkName, value);
        }

        #endregion

    }

    /// <summary>
    /// Represents a <see cref="Actor"/> that hosts a Windows Workflow Foundation activity and has a local state object.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TActivity, TState> :
        ActivityActor<TActivity>
        where TActivity : Activity
    {

        const string DEFAULT_STATE_KEY = "__ActorState__";

        /// <summary>
        /// Gets or sets the state name in which the state object is stored.
        /// </summary>
        protected virtual string StateObjectKey { get; set; } = DEFAULT_STATE_KEY;

        /// <summary>
        /// Gets the actor state object.
        /// </summary>
        protected virtual TState State { get; set; }

        /// <summary>
        /// Creates the default state object.
        /// </summary>
        /// <returns></returns>
        protected virtual Task<TState> CreateDefaultState()
        {
            return Task.FromResult(Activator.CreateInstance<TState>());
        }

        /// <summary>
        /// Override this method to initialize the members.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnActivateAsync()
        {
            await LoadStateObject();
            await base.OnActivateAsync();
        }

        /// <summary>
        /// Loads the state object. This method is invoked as part of the actor activation.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task LoadStateObject()
        {
            var o = await StateManager.TryGetStateAsync<TState>(StateObjectKey);
            State = o.HasValue ? o.Value : await CreateDefaultState();
        }

        /// <summary>
        /// Saves the state object. Invoke this after modifications to the state.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task SaveStateObject()
        {
            if (typeof(TState).IsValueType)
                await StateManager.SetStateAsync(StateObjectKey, State);
            else if (State != null)
                await StateManager.SetStateAsync(StateObjectKey, State);
            else if (await StateManager.ContainsStateAsync(StateObjectKey))
                await StateManager.TryRemoveStateAsync(StateObjectKey);
        }

        /// <summary>
        /// This method is invoked by actor runtime an actor method has finished execution. Override this method for
        /// performing any actions after an actor method has finished execution.
        /// </summary>
        /// <param name="actorMethodContext"></param>
        /// <returns></returns>
        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await SaveStateObject();
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

    }

}
