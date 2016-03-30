using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class StatefulActivityActor<TState> :
        StatefulActivityActorBase<TState>,
        IStatefulActivityActorInternal
        where TState : class, new()
    {

        readonly ActivityWorkflowHost host;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected StatefulActivityActor()
            : base()
        {
            host = new ActivityWorkflowHost(this);
        }

        /// <summary>
        /// Creates the default activity state. Invokes <see cref="CreateDefaultState"/> to populate <see cref="ActivityActorState{TState}.State"/>.
        /// </summary>
        /// <returns></returns>
        protected override async Task<ActivityActorState<TState>> CreateDefaultActivityState()
        {
            return new ActivityActorState<TState>()
            {
                State = await CreateDefaultState(),
            };
        }

        /// <summary>
        /// Initializes a new <typeparamref name="TState"/> instance.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task<TState> CreateDefaultState()
        {
            return Task.FromResult(new TState());
        }

        /// <summary>
        /// Represents the internal state of the <see cref="StatefulActivityActor{TState}"/>.
        /// </summary>
        protected ActivityActorState<TState> ActivityState
        {
            get { return base.State; }
            set { base.State = value; }
        }

        /// <summary>
        /// Represents the user-defined reliable state of the <see cref="StatefulActor"/>.
        /// </summary>
        protected new TState State
        {
            get { return ActivityState?.State; }
            set { ActivityState.State = value; }
        }

        /// <summary>
        /// Creates a new instance of <see cref="Activity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected abstract Activity CreateActivity();

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override async Task OnActivateAsyncHidden()
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override async Task OnDeactivateAsyncHidden()
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/> with the given <paramref name="value"/>.
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/> with the given <paramref name="value"/>.
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/>.
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/>.
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/>.
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
        /// Resumes the <see cref="StatefulActivityActor{TState}"/>.
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override async Task ReceiveReminderAsyncHidden(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
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
        /// Invoked when an <see cref="Exception"/> is thrown during the workflow operation.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected virtual Task OnException(Exception exception)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> goes idle.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is faulted.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnFaulted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is canceled.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCanceled()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="StatefulActivityActor{TState}"/> is closed.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnClosed()
        {
            return Task.FromResult(true);
        }

        #region IActivityActorInternal

        Activity IActivityActorInternal.CreateActivity()
        {
            return CreateActivity();
        }

        bool IActivityActorInternal.CanPersist
        {
            get { return true; }
        }

        ActivityActorState IActivityActorInternal.State
        {
            get { return base.State; }
        }

        IActorTimer IActivityActorInternal.RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period, bool isCallbackReadOnly)
        {
            return RegisterTimer(callback, state, dueTime, period, isCallbackReadOnly);
        }

        void IActivityActorInternal.UnregisterTimer(IActorTimer timer)
        {
            UnregisterTimer(timer);
        }

        bool IActivityActorInternal.CanRegisterReminder
        {
            get { return true; }
        }

        IActorReminder IActivityActorInternal.GetReminder(string reminderName)
        {
            return GetReminder(reminderName);
        }

        Task<IActorReminder> IActivityActorInternal.RegisterReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period, ActorReminderAttributes attribute)
        {
            return RegisterReminderAsync(reminderName, state, dueTime, period, attribute);
        }

        Task IActivityActorInternal.UnregisterReminderAsync(IActorReminder reminder)
        {
            return UnregisterReminderAsync(reminder);
        }

        Task IActivityActorInternal.OnException(Exception exception)
        {
            return OnException(exception);
        }

        Task IActivityActorInternal.OnIdle()
        {
            return OnIdle();
        }

        Task IActivityActorInternal.OnFaulted()
        {
            return OnFaulted();
        }

        Task IActivityActorInternal.OnCanceled()
        {
            return OnCanceled();
        }

        Task IActivityActorInternal.OnClosed()
        {
            return OnClosed();
        }

        #endregion

    }

    /// <summary>
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>.
    /// </summary>
    /// <typeparam name="TActivity"></typeparam>
    /// <typeparam name="TState"></typeparam>
    public abstract class StatefulActivityActor<TActivity, TState> :
        StatefulActivityActor<TState>
        where TActivity : Activity, new()
        where TState : class, new()
    {

        /// <summary>
        /// Creates a new instance of the <see cref="Activity"/> type.
        /// </summary>
        /// <returns></returns>
        protected override Activity CreateActivity()
        {
            return new TActivity();
        }

    }

    /// <summary>
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>.
    /// </summary>
    public abstract class StatefulActivityActor :
        StatefulActivityActor<object>
    {



    }

}
