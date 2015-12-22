using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cogito.Activities;
using Cogito.Collections;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Supporting middle-ware for <see cref="ActivityActor{TState}"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActorBase<TState> :
        StatefulActor<ActivityActorState<TState>>,
        IActivityActorInternal
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected internal ActivityActorBase()
            : base()
        {

        }

        /// <summary>
        /// Represents the state of the <see cref="StatefulActor"/>.
        /// </summary>
        protected ActivityActorState<TState> ActivityState
        {
            get { return base.State ?? (base.State = CreateActivityState()); }
        }

        /// <summary>
        /// Provides internal access to ActivityState.
        /// </summary>
        internal ActivityActorState ActivityStateInternal
        {
            get { return ActivityState; }
        }

        /// <summary>
        /// Creates an instance of <see cref="ActivityActorState{TState}"/>.
        /// </summary>
        /// <returns></returns>
        ActivityActorState<TState> CreateActivityState()
        {
            return new ActivityActorState<TState>();
        }

        /// <summary>
        /// Represents the user-defined reliable state of the <see cref="StatefulActor"/>.
        /// </summary>
        public new TState State
        {
            get { return ActivityState.State; }
            set { ActivityState.State = value; }
        }

        /// <summary>
        /// Registers a timer for the actor.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <param name="isCallbackReadOnly"></param>
        /// <returns></returns>
        IActorTimer IActivityActorInternal.RegisterTimer(Func<object, Task> callback, object state, TimeSpan dueTime, TimeSpan period, bool isCallbackReadOnly)
        {
            return RegisterTimer(callback, state, dueTime, period, isCallbackReadOnly);
        }

        /// <summary>
        /// Unregisters a timer for the actor.
        /// </summary>
        /// <param name="timer"></param>
        void IActivityActorInternal.UnregisterTimer(IActorTimer timer)
        {
            UnregisterTimer(timer);
        }

        /// <summary>
        /// Gets the actor reminder with the specified actor reminder name, or <c>null</c> if no such reminder exists.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <returns></returns>
        protected IActorReminder TryGetReminder(string reminderName)
        {
            try
            {
                return GetReminder(reminderName);
            }
            catch (FabricException e) when (e.ErrorCode == FabricErrorCode.Unknown)
            {
                // ignore
            }

            return null;
        }

    }

    /// <summary>
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>. The 
    /// <see cref="Activity"/> is specified by overriding the <see cref="CreateActivity"/> method. The <see cref="Activity"/>
    /// begins running as soon as the <see cref="StatefulActor"/> instance is activated.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TState> :
        ActivityActorBase<TState>,
        IRemindable
    {

        static readonly XName ActivityTimerExpirationTimeKey = XName.Get("TimerExpirationTime", "urn:schemas-microsoft-com:System.Activities/4.0/properties");
        static readonly string ActivityTimerExpirationReminderName = "Cogito.Fabric.Activities.TimerExpirationReminder";

        WorkflowApplication workflow;

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <returns></returns>
        WorkflowApplication CreateWorkflow(Activity activity)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Ensures(Contract.Result<WorkflowApplication>() != null);

            // generate new instance
            var workflow = new WorkflowApplication(activity)
            {
                SynchronizationContext = new ActivityActorSynchronizationContext(this),
                InstanceStore = new ActivityActorInstanceStore<TState>(this),

                OnUnhandledException = args =>
                {
                    return UnhandledExceptionAction.Abort;
                },

                Aborted = args =>
                {

                },

                Idle = args =>
                {

                },

                PersistableIdle = args =>
                {
                    return PersistableIdleAction.Persist;
                },

                Completed = args =>
                {
                    ActivityState.Status = ToActivityStatus(args.CompletionState);
                },
            };

            workflow.Extensions.Add(() => new ActivityActorExtension(this));
            workflow.Extensions.Add(() => new AsyncActivityExtension(workflow.SynchronizationContext));

            return workflow;
        }

        /// <summary>
        /// Transforms a <see cref="ActivityInstanceState"/> into a <see cref="ActivityActorStatus"/>.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        ActivityActorStatus ToActivityStatus(ActivityInstanceState state)
        {
            switch (state)
            {
                case ActivityInstanceState.Executing:
                    return ActivityActorStatus.Executing;
                case ActivityInstanceState.Canceled:
                    return ActivityActorStatus.Canceled;
                case ActivityInstanceState.Faulted:
                    return ActivityActorStatus.Faulted;
                case ActivityInstanceState.Closed:
                    return ActivityActorStatus.Closed;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="Activity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected abstract Activity CreateActivity();

        /// <summary>
        /// Invokes the specified function against the workflow instance.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        async Task InvokeWithWorkflow(Func<WorkflowApplication, Task> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            // save existing status
            var status = ActivityState.Status;

            // execute user function, workflow will schedule timers
            await func(workflow);

            // notify about status changes
            await OnStatusChanged(status, ActivityState.Status);
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnActivateAsync()
        {
            Contract.Ensures(workflow != null);
            Contract.Assert(workflow == null);

            // create new workflow and activity
            workflow = CreateWorkflow(CreateActivity());
            Contract.Assert(workflow != null);

            // generate new owner ID
            if (ActivityState.InstanceOwnerId == Guid.Empty)
                ActivityState.InstanceOwnerId = Guid.NewGuid();

            // load workflow if instance ID present
            if (ActivityState.InstanceId != Guid.Empty)
                await InvokeWithWorkflow(a => a.LoadAsync(ActivityState.InstanceId));

            // store instance ID
            ActivityState.InstanceId = workflow.Id;
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnDeactivateAsync()
        {
            Contract.Ensures(workflow == null);
            Contract.Assert(workflow != null);

            await workflow.UnloadAsync();
            workflow = null;
        }

        /// <summary>
        /// Ensures a reminder is scheduled to signal a wake up based on the workflow's timers.
        /// </summary>
        /// <returns></returns>
        async Task SaveRemindersAsync()
        {
            Contract.Requires(workflow != null);
            Contract.Requires(ActivityState != null);
            Contract.Requires(ActivityState.InstanceId != Guid.Empty);

            // get existing reminder if possible
            var reminder = TryGetReminder(ActivityTimerExpirationReminderName);

            // next time at which the reminder should be invoked
            var time = (DateTime?)ActivityState.InstanceData?
                .GetOrDefault(ActivityState.InstanceId)?
                .GetOrDefault(ActivityTimerExpirationTimeKey);

            // a time is present
            if (time != null)
            {
                // time at which the reminder should be fired, minimum 1 second from now
                var dueTime = new TimeSpan(Math.Max(((DateTime)time - DateTime.UtcNow).Ticks, TimeSpan.FromSeconds(1).Ticks));

                // unregister reminder if it the time has changed
                if (reminder != null)
                {
                    // allow a skew of 5 seconds
                    if (Math.Abs((dueTime - reminder.DueTime).TotalSeconds) > 5)
                    {
                        // timer is out of range, will reschedule below
                        await UnregisterReminderAsync(reminder);
                        reminder = null;
                    }
                }

                // schedule new reminder
                if (reminder == null)
                    await RegisterReminderAsync(
                        ActivityTimerExpirationReminderName,
                        null,
                        dueTime,
                        TimeSpan.FromMilliseconds(-1),
                        ActorReminderAttributes.None);

                return;
            }
            else
            {
                // no reminder required, unregister existing reminder
                if (reminder != null)
                    await UnregisterReminderAsync(reminder);
            }
        }

        /// <summary>
        /// Gets the current <see cref="ActivityActorStatus"/> of the <see cref="ActivityActor{TActivity, TState}"/>.
        /// </summary>
        protected ActivityActorStatus ActivityStatus
        {
            get { return ActivityState.Status; }
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        protected async Task RunAsync()
        {
            await InvokeWithWorkflow(_ => _.RunAsync());
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity, TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected async Task ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(bookmarkName));
            Contract.Assert(workflow != null);

            await InvokeWithWorkflow(_ => _.ResumeBookmarkAsync(bookmarkName, value));
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity, TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        protected Task ResumeAsync(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(bookmarkName));
            Contract.Assert(workflow != null);

            return ResumeAsync(bookmarkName, null);
        }

        /// <summary>
        /// Invoked when a reminder is fired.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName == ActivityTimerExpirationReminderName)
                await InvokeWithWorkflow(_ => _.RunAsync());
        }

        /// <summary>
        /// Invoked when the status has changed.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected virtual Task OnStatusChanged(ActivityActorStatus from, ActivityActorStatus to)
        {
            if (from == to)
                return Task.FromResult(true);

            switch (to)
            {
                case ActivityActorStatus.Canceled:
                    return OnCanceled();
                case ActivityActorStatus.Faulted:
                    return OnFaulted();
                case ActivityActorStatus.Closed:
                    return OnClosed();
            }

            // unimportant status
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
        /// Invoked when the <see cref="ActivityActor{TActivity, TState}"/> goes idle.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnIdle()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor{TActivity, TState}"/> is faulted.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnFaulted()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor{TActivity, TState}"/> is canceled.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnCanceled()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the <see cref="ActivityActor{TActivity, TState}"/> is closed.
        /// </summary>
        /// <returns></returns>
        protected virtual Task OnClosed()
        {
            return Task.FromResult(true);
        }

    }

    /// <summary>
    /// A <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/> of type
    /// <typeparamref name="TActivity"/>. The <see cref="Activity"/> begins running as soon as the <see
    /// cref="StatefulActor"/> instance is activated.
    /// </summary>
    /// <typeparam name="TActivity"></typeparam>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TActivity, TState> :
        ActivityActor<TState>
        where TActivity : Activity, new()
    {

        protected override Activity CreateActivity()
        {
            return new TActivity();
        }

    }

    /// <summary>
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>. The 
    /// <see cref="Activity"/> is specified by overriding the <see cref="CreateActivity"/> method. The <see cref="Activity"/>
    /// begins running as soon as the <see cref="StatefulActor"/> instance is activated.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor :
        ActivityActor<object>
    {



    }

}
