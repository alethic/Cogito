﻿using System;
using System.Activities;
using System.Activities.Tracking;
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
    /// Manages the <see cref="WorkflowApplication"/> associated with a <see cref="Activity"/> actor.
    /// </summary>
    public class ActivityWorkflowHost
    {

        static readonly XName ActivityTimerExpirationTimeKey = XName.Get("TimerExpirationTime", "urn:schemas-microsoft-com:System.Activities/4.0/properties");
        static readonly string ActivityTimerExpirationReminderName = "Cogito.Fabric.Activities.TimerExpirationReminder";

        readonly IActivityActorInternal actor;
        WorkflowApplication workflow;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityWorkflowHost(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

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
                SynchronizationContext = new ActivityActorSynchronizationContext(actor),
                InstanceStore = actor.HasState ? new ActivityActorInstanceStore(actor) : null,

                OnUnhandledException = args =>
                {
                    actor.RegisterTimer(o => actor.OnException(args.UnhandledException), null, TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(-1), false);
                    return UnhandledExceptionAction.Abort;
                },

                Aborted = args =>
                {

                },

                Idle = args =>
                {
                    actor.RegisterTimer(o => actor.OnIdle(), null, TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(-1), false);
                },

                PersistableIdle = args =>
                {
                    return actor.HasState ? PersistableIdleAction.Persist : PersistableIdleAction.None;
                },

                Completed = args =>
                {
                    actor.State.Status = ToActivityStatus(args.CompletionState);
                },

                Unloaded = args =>
                {

                }
            };

            workflow.Extensions.Add(() => new ActivityActorTrackingParticipant(actor));
            workflow.Extensions.Add(() => new ActivityActorExtension(actor));
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
        /// Invokes the specified function against the workflow instance.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        async Task InvokeWithWorkflow(Func<WorkflowApplication, Task> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            // check existing status
            var status = actor.State.Status;
            if (status == ActivityActorStatus.Closed)
                throw new ActivityActorClosedException();

            // execute user function, workflow will schedule timers
            await func(workflow);

            // notify about status changes
            await OnStatusChanged(status, actor.State.Status);

            // save reminder to resume bookmarks
            await SaveRemindersAsync();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnActivateAsync()
        {
            // might already be loaded
            if (workflow != null)
                return;

            // workflow has been closed, cannot be loaded anymore
            if (actor.State.Status == ActivityActorStatus.Closed)
                return;

            // create new workflow and activity
            workflow = CreateWorkflow(actor.CreateActivity());
            Contract.Assert(workflow != null);

            // generate new owner ID
            if (actor.State.InstanceOwnerId == Guid.Empty)
                actor.State.InstanceOwnerId = Guid.NewGuid();

            // load workflow if instance ID present
            if (actor.State.InstanceId != Guid.Empty)
                await InvokeWithWorkflow(a => a.LoadAsync(actor.State.InstanceId));

            // store instance ID
            actor.State.InstanceId = workflow.Id;
            }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnDeactivateAsync()
        {
            Contract.Ensures(workflow == null);

            if (workflow != null)
            {
            await workflow.UnloadAsync();
            workflow = null;
        }
        }

        /// <summary>
        /// Ensures a reminder is scheduled to signal a wake up based on the workflow's timers.
        /// </summary>
        /// <returns></returns>
        async Task SaveRemindersAsync()
        {
            Contract.Requires(workflow != null);
            Contract.Requires(actor.State.InstanceId != Guid.Empty);

            // next time at which the reminder should be invoked
            var time = (DateTime?)actor.State.InstanceData?
                .GetOrDefault(actor.State.InstanceId)?
                .GetOrDefault(ActivityTimerExpirationTimeKey);

            // check that this is supported
            if (time != null && !actor.CanRegisterReminder)
                throw new ActivityActorException($"Cannot persist reminder for {nameof(StatelessActor)}.");

            // get existing reminder if possible
            var reminder = TryGetReminder(ActivityTimerExpirationReminderName);

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
                        await actor.UnregisterReminderAsync(reminder);
                        reminder = null;
                    }
                }

                // schedule new reminder
                if (reminder == null)
                    await actor.RegisterReminderAsync(
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
                    await actor.UnregisterReminderAsync(reminder);
            }
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
                return actor.GetReminder(reminderName);
            }
            catch (FabricException e) when (e.ErrorCode == FabricErrorCode.Unknown)
            {
                // ignore
            }

            return null;
        }

        /// <summary>
        /// Resets the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task ResetAsync()
        {
            // unload existing workflow
            if (workflow != null)
        {
                await workflow.UnloadAsync();
                workflow = null;
            }

            // create new workflow and activity
            workflow = CreateWorkflow(actor.CreateActivity());
            Contract.Assert(workflow != null);

            // generate new owner ID
            if (actor.State.InstanceOwnerId == Guid.Empty)
                actor.State.InstanceOwnerId = Guid.NewGuid();

            // store instance ID
            actor.State.InstanceId = workflow.Id;
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task RunAsync()
        {
            await InvokeWithWorkflow(_ => _.RunAsync());
        }

        /// <summary>
        /// Resumes the <see cref="StatefulActivityActor{TActivity, TState}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(bookmarkName));

            await InvokeWithWorkflow(_ => _.ResumeBookmarkAsync(bookmarkName, value));
        }

        /// <summary>
        /// Resumes the <see cref="StatefulActivityActor{TActivity, TState}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        internal Task ResumeAsync(string bookmarkName)
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
            if (reminderName == ActivityTimerExpirationReminderName)
            {
                // workflow not yet loaded, or has been closed
                if (workflow == null)
                    return;

                await InvokeWithWorkflow(_ => _.RunAsync());
            }
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
                    return actor.OnCanceled();
                case ActivityActorStatus.Faulted:
                    return actor.OnFaulted();
                case ActivityActorStatus.Closed:
                    return actor.OnClosed();
            }

            // unimportant status
            return Task.FromResult(true);
        }

    }

}