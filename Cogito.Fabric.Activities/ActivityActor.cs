using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cogito.Collections;

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
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <typeparamref name="TActivity"/>.
    /// </summary>
    /// <typeparam name="TActivity"></typeparam>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TActivity, TState> :
        ActivityActorBase<TState>,
        IRemindable
        where TActivity : Activity, new()
    {

        static readonly XName TimerExpirationTimeKey = XName.Get("TimerExpirationTime", "urn:schemas-microsoft-com:System.Activities/4.0/properties");
        static readonly string TimerExpirationReminderName = "Cogito.Fabric.Activities.TimerExpirationReminder";

        TActivity activity;

        /// <summary>
        /// Gets a reference to the instance of <typeparamref name="TActivity"/>.
        /// </summary>
        protected TActivity Activity
        {
            get { return activity ?? (activity = CreateActivity()); }
        }

        /// <summary>
        /// Creates a new instance of <see cref="TActivity"/>. Override this method to customize the instance.
        /// </summary>
        /// <returns></returns>
        protected virtual TActivity CreateActivity()
        {
            return new TActivity();
        }

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <param name="taskCompletionSource"></param>
        /// <returns></returns>
        WorkflowApplication CreateWorkflow(TaskCompletionSource<bool> taskCompletionSource)
        {
            Contract.Requires<ArgumentNullException>(taskCompletionSource != null);

            var workflow = ActivityState.Inputs != null ? new WorkflowApplication(Activity, ActivityState.Inputs) : new WorkflowApplication(Activity);
            workflow.SynchronizationContext = SynchronizationContext.Current;
            workflow.InstanceStore = new ActivityActorInstanceStore<TState>(this);
            workflow.Extensions.Add(new DurableTimerExtension());

            // to store exception that occurs during invoation
            Exception exception = null;

            workflow.OnUnhandledException = args =>
            {
                return UnhandledExceptionAction.Abort;
            };

            workflow.Idle = args =>
            {
                ActivityState.InstanceId = args.InstanceId;
            };

            workflow.PersistableIdle = args =>
            {
                ActivityState.InstanceId = args.InstanceId;
                return PersistableIdleAction.Unload;
            };

            workflow.Aborted = args =>
            {
                ActivityState.InstanceId = args.InstanceId;
                if (args.Reason != null)
                    exception = args.Reason;
            };

            workflow.Completed = args =>
            {
                ActivityState.InstanceId = args.InstanceId;
                ActivityState.Status = ToActivityStatus(args.CompletionState);
                ActivityState.Outputs = args.Outputs.ToDictionary(i => i.Key, i => i.Value);
                if (args.TerminationException != null)
                    exception = args.TerminationException;
            };

            workflow.Unloaded = args =>
            {
                ActivityState.InstanceId = args.InstanceId;
                if (exception == null)
                    taskCompletionSource.SetResult(true);
                else
                    taskCompletionSource.SetException(exception);
            };

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
        /// Gets or creates and loads a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <param name="taskCompletionSource"></param>
        /// <returns></returns>
        async Task<WorkflowApplication> CreateAndLoadWorkflow(TaskCompletionSource<bool> taskCompletionSource)
        {
            Contract.Requires<ArgumentNullException>(taskCompletionSource != null);

            // create new workflow instance
            var workflow = CreateWorkflow(taskCompletionSource);
            if (workflow == null)
                throw new NullReferenceException();

            // ensure instance owner ID is generated
            if (ActivityState.InstanceOwnerId == null)
                ActivityState.InstanceOwnerId = Guid.NewGuid();

            // load the workflow if available
            if (ActivityState.InstanceId != null)
                await workflow.LoadAsync((Guid)ActivityState.InstanceId);

            return workflow;
        }

        /// <summary>
        /// Invokes the specified function against the workflow instance.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        async Task InvokeWithWorkflow(Func<WorkflowApplication, Task> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            // store away initial status
            var status = ActivityState.Status;

            // run workflow instance and wait for completion
            try
            {
                var tcs = new TaskCompletionSource<bool>();
                await func(await CreateAndLoadWorkflow(tcs));
                await tcs.Task;
            }
            catch (Exception e)
            {
                // allow the user to clean up or trap any exceptions
                await OnException(e);
            }
            finally
            {
                // ensure reminders are set and state is saved
                await SaveRemindersAsync();
                await SaveStateAsync();
                await OnStatusChanged(status, ActivityState.Status);
            }
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
                .GetOrDefault((Guid)ActivityState.InstanceId)?
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
        /// Initializes the <see cref="ActivityActor{TActivity, TState}"/> with input parameters.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        protected Task InitializeAsync(IDictionary<string, object> inputs = null)
        {
            ActivityState.Reset();
            ActivityState.Inputs = inputs?.ToDictionary(i => i.Key, i => i.Value);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Begins the <see cref="ActivityActor{TActivity, TState}"/> with the given <paramref name="inputs"/> as input.
        /// </summary>
        /// <returns></returns>
        protected async Task RunAsync()
        {
            await InvokeWithWorkflow(async _ => await _.RunAsync());
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity, TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected async Task ResumeBookmarkAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);

            await InvokeWithWorkflow(async _ => await _.ResumeBookmarkAsync(bookmarkName, value));
        }

        /// <summary>
        /// Invoked when a reminder is fired.
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="context"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public virtual async Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName == TimerExpirationReminderName)
                await InvokeWithWorkflow(async _ => await _.RunAsync());
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
    /// Represents a <see cref="StatefulActor"/> that hosts a Windows Workflow Foundation <typeparamref name="TActivity"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class ActivityActor<TActivity> :
        ActivityActor<TActivity, object>
        where TActivity : Activity, new()
    {



    }

}
