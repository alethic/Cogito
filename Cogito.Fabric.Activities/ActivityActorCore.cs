using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Represents a <see cref="Actor"/> that hosts a Windows Workflow Foundation activity.
    /// </summary>
    /// <remarks>
    /// This base contains the main implementation details.
    /// </remarks>
    public abstract class ActivityActorCore :
        Cogito.Fabric.Actor,
        IRemindable,
        IActivityActorInternal,
        IActivityActor
    {

        readonly ActivityWorkflowHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorCore()
        {
            host = new ActivityWorkflowHost(this);
        }

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
        async Task OnActivateAsyncInternal()
        {
            await OnBeforeWorkflowActivate();
            await host.OnActivateAsync();
            await OnAfterWorkflowActivate();
            await OnActivateAsyncHidden();
        }

        /// <summary>
        /// Override this method to initialize the members, initialize state or register timers. This method is called
        /// right after the actor is activated and before any method call or reminders are dispatched on it.
        /// </summary>
        /// <returns></returns>
        protected internal abstract Task OnActivateAsyncHidden();

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
        async Task OnDeactivateAsyncInternal()
        {
            await OnBeforeWorkflowDeactivate();
            await host.OnDeactivateAsync();
            await OnAfterWorkflowDeactivate();
            await OnDeactivateAsyncHidden();
        }

        /// <summary>
        ///  Override this method to release any resources including unregistering the timers. This method is called
        ///  right before the actor is deactivated.
        /// </summary>
        /// <returns></returns>
        protected internal abstract Task OnDeactivateAsyncHidden();

        /// <summary>
        /// Creates a new instance of <see cref="Activity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected abstract Activity CreateActivity();

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
        /// Invoked before the workflow has been activated.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnBeforeWorkflowActivate()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked after the workflow has been activated.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnAfterWorkflowActivate()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked before the workflow has been deactivated.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnBeforeWorkflowDeactivate()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked after the workfly has been deactivated.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnAfterWorkflowDeactivate()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the activity workflow is persisted to the <see cref="IActorStateManager"/>.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnPersisted()
        {
            await SaveStateAsync();
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
        /// Invoked when the <see cref="ActivityActorCore"/> is aborted.
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        protected virtual Task OnAborted(Exception reason)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActorCore"/> is idle and persistable.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnPersistableIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActorCore"/> goes idle.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActorCore"/> is faulted.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnFaulted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActorCore"/> is completed.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCompleted(ActivityInstanceState state, IDictionary<string, object> outputs)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActorCore"/> is unloaded.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnUnloaded()
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
        protected Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName, object value, TimeSpan timeout)
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
        protected Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName, object value)
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
        protected Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, null, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        protected Task<BookmarkResumptionResult> ResumeAsync(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return host.ResumeAsync(bookmarkName, null);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected Task<BookmarkResumptionResult> ResumeAsync(Bookmark bookmark, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return host.ResumeAsync(bookmark, null, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TState}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        protected Task<BookmarkResumptionResult> ResumeAsync(Bookmark bookmark)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return host.ResumeAsync(bookmark, null);
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
        /// Invoked when a reminder is fired.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        async Task ReceiveReminderAsyncInternal(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
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

}
