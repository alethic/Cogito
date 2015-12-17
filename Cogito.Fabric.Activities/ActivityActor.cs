using System;
using System.Activities;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cogito.Activities;
using Cogito.Collections;
using Cogito.Threading;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    public abstract class ActivityActorBase<TState> :
        StatefulActor<ActivityActorState<TState>>
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
        /// Gets the actor reminder with the specified actor reminder name, or <c>null</c> if no such reminder exists.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
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
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TState> :
        ActivityActorBase<TState>,
        IRemindable
    {

        static readonly XName TimerExpirationTimeKey = XName.Get("TimerExpirationTime", "urn:schemas-microsoft-com:System.Activities/4.0/properties");
        static readonly string TimerExpirationReminderName = "Cogito.Fabric.Activities.TimerExpirationReminder";

        Activity activity;
        WorkflowApplication workflow;

        /// <summary>
        /// Gets a reference to the instance of <typeparamref name="TActivity"/>.
        /// </summary>
        protected Activity Activity
        {
            get { return activity ?? (activity = CreateActivity()); }
        }

        /// <summary>
        /// Creates a new instance of <see cref="TActivity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected abstract Activity CreateActivity();

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <returns></returns>
        WorkflowApplication CreateWorkflow()
        {
            // generate new instance
            var workflow = new WorkflowApplication(Activity)
            {
                SynchronizationContext = new SynchronizedSynchronizationContext(),
                InstanceStore = new ActivityActorInstanceStore<TState>(this),

                OnUnhandledException = args =>
                {
                    return UnhandledExceptionAction.Abort;
                },

                Idle = args =>
                {

                },

                PersistableIdle = args =>
                {
                    return PersistableIdleAction.Persist;
                },

                Aborted = args =>
                {

                },

                Completed = args =>
                {
                    ActivityState.Status = ToActivityStatus(args.CompletionState);
                },

                Unloaded = args =>
                {

                },
            };

            workflow.Extensions.Add(new ActivityActorExtension(this));

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
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnActivateAsync()
        {
            // create new workflow
            workflow = CreateWorkflow();

            // generate new owner ID
            if (ActivityState.InstanceOwnerId == Guid.Empty)
                ActivityState.InstanceOwnerId = Guid.NewGuid();

            if (ActivityState.InstanceId != Guid.Empty)
            {
                // load existing workflow state
                await workflow.LoadAsync(ActivityState.InstanceId);
                await SaveRemindersAsync();
            }
            else
            {
                // store new instance ID and initiate workflow
                ActivityState.InstanceId = workflow.Id;
                await workflow.RunAsync();
                await SaveRemindersAsync();
            }
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnDeactivateAsync()
        {
            await workflow.UnloadAsync();
        }

        /// <summary>
        /// Invokes the specified function against the workflow instance.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        async Task WrapWorkflowInvoke(Func<WorkflowApplication, Task> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            // execute function with workflow
            var status = ActivityState.Status;
            await func(workflow);
            await OnStatusChanged(status, ActivityState.Status);
            await SaveRemindersAsync();
        }

        /// <summary>
        /// Ensures a reminder is scheduled to signal a wake up based on the workflow's timers.
        /// </summary>
        /// <returns></returns>
        async Task SaveRemindersAsync()
        {
            // no instance yet set
            if (ActivityState.InstanceId == null)
                return;

            // get existing reminder if possible
            var reminder = TryGetReminder(TimerExpirationReminderName);

            var timerExpirationTime = (DateTime?)ActivityState.InstanceData?
                .GetOrDefault(ActivityState.InstanceId)?
                .GetOrDefault(TimerExpirationTimeKey);
            if (timerExpirationTime != null)
            {
                // time at which the reminder should be fired, minimum 1 second from now
                var dueTime = new TimeSpan(Math.Max(((DateTime)timerExpirationTime - DateTime.UtcNow).Ticks, TimeSpan.FromSeconds(1).Ticks));

                // unregister reminder if it the time has changed
                if (reminder != null &&
                    reminder.DueTime != dueTime)
                {
                    await UnregisterReminderAsync(reminder);
                    reminder = null;
                }

                // schedule new reminder
                if (reminder == null)
                    await RegisterReminderAsync(
                        TimerExpirationReminderName,
                        null,
                        dueTime,
                        TimeSpan.FromMilliseconds(-1),
                        ActorReminderAttributes.None);

                return;
            }
            else
            {
                // unregister existing reminder
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
            await WrapWorkflowInvoke(async _ => await _.RunAsync());
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

            await WrapWorkflowInvoke(async _ => await _.ResumeBookmarkAsync(bookmarkName, value));
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
            if (reminderName == TimerExpirationReminderName)
                await WrapWorkflowInvoke(async _ => await _.RunAsync());
        }

        /// <summary>
        /// Invoked when the status has changed.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected virtual async Task OnStatusChanged(ActivityActorStatus from, ActivityActorStatus to)
        {
            if (from == to)
                return;

            switch (to)
            {
                case ActivityActorStatus.Canceled:
                    await OnCanceled();
                    return;
                case ActivityActorStatus.Faulted:
                    await OnFaulted();
                    return;
                case ActivityActorStatus.Closed:
                    await OnClosed();
                    return;
                default:
                    return;
            }
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
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <see cref="Activity"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor :
        ActivityActor<object>
    {



    }

}
