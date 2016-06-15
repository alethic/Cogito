using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cogito.Activities;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Manages the <see cref="WorkflowApplication"/> associated with a <see cref="Activity"/> actor.
    /// </summary>
    class ActivityWorkflowHost
    {

        internal static readonly XNamespace WorkflowNamespace = "urn:schemas-microsoft-com:System.Activities/4.0/properties";
        internal static readonly XName ActivityTimerExpirationTimeKey = WorkflowNamespace + "TimerExpirationTime";
        internal static readonly string ActivityTimerExpirationReminderName = "Cogito.Fabric.Activities::TimerExpirationReminder";

        readonly IActivityActorInternal actor;
        readonly ActivityActorStateManager state;
        WorkflowApplication workflow;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actor"></param>
        public ActivityWorkflowHost(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;

            // provides access to workflow state stored in the actor
            this.state = new ActivityActorStateManager(() => actor.StateManager);
            this.state.Persisted = OnPersisted;
        }

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="inputs"></param>
        /// <returns></returns>
        WorkflowApplication CreateWorkflow(Activity activity, IDictionary<string, object> inputs = null)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Ensures(Contract.Result<WorkflowApplication>() != null);

            var workflow = inputs != null ? new WorkflowApplication(activity, inputs) : new WorkflowApplication(activity);
            workflow.SynchronizationContext = new ActivityActorSynchronizationContext(actor);
            workflow.InstanceStore = new ActivityActorInstanceStore(state);

            workflow.OnUnhandledException = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnException(args.UnhandledException);
                }, null);

                return UnhandledExceptionAction.Abort;
            };

            workflow.Aborted = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnAborted(args.Reason);
                }, null);
            };

            workflow.PersistableIdle = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnPersistableIdle();
                }, null);

                // workflow should save state but not unload until actor deactivated
                // workflow timers invoke themselves as long as it's loaded
                return PersistableIdleAction.Persist;
            };

            workflow.Idle = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnIdle();
                }, null);
            };

            workflow.Completed = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnCompleted(args.CompletionState, args.Outputs);
                }, null);
            };

            workflow.Unloaded = args =>
            {
                this.workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnUnloaded();
                }, null);
            };

            workflow.Extensions.Add(() => new ActivityActorTrackingParticipant(actor));
            workflow.Extensions.Add(() => new ActivityActorExtension(actor));
            workflow.Extensions.Add(() => new AsyncActivityExtension(workflow.SynchronizationContext));

            // add user extensions
            foreach (var ext in actor.GetWorkflowExtensions())
                workflow.Extensions.Add(ext);

            return workflow;
        }

        /// <summary>
        /// Invoked by the instance store after the workflow instance has been persisted.
        /// </summary>
        /// <returns></returns>
        async Task OnPersisted()
        {
            await SaveReminderAsync();
            await actor.OnPersisted();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnActivateAsync()
        {
            // might already be loaded somehow
            if (workflow == null)
            {
                // generate owner ID
                if (await state.GetInstanceOwnerId() == Guid.Empty)
                    await state.SetInstanceOwnerId(Guid.NewGuid());

                if (await state.GetInstanceId() == Guid.Empty)
                {
                    // create workflow
                    workflow = CreateWorkflow(actor.CreateActivity(), actor.CreateActivityInputs() ?? new Dictionary<string, object>());
                    await state.SetInstanceId(workflow.Id);
                    await workflow.RunAsync();
                }
                else
                {
                    // load workflow
                    workflow = CreateWorkflow(actor.CreateActivity());
                    await workflow.LoadAsync(await state.GetInstanceId());
                    await workflow.RunAsync();
                }
            }
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnDeactivateAsync()
        {
            if (workflow != null)
            {
                try
                {
                    await workflow.UnloadAsync();
                }
                catch (TimeoutException e)
                {

                }
                finally
                {
                    workflow = null;
                }
            }
        }

        /// <summary>
        /// Ensures workflow timers are registered for waking the instance up.
        /// </summary>
        /// <returns></returns>
        async Task SaveReminderAsync()
        {
            Contract.Requires(workflow != null);

            // next date at which the reminder should be invoked
            var date = (DateTime?)await state.GetInstanceData(ActivityTimerExpirationTimeKey);
            if (date != null)
            {
                // time at which the reminder should be fired, minimum 1 second from now, advance ahead by 1 second
                var dueTime = new TimeSpan(Math.Max(((DateTime)date - DateTime.UtcNow).Ticks, TimeSpan.FromSeconds(1).Ticks))
                    .Add(TimeSpan.FromSeconds(1));

                // unregister reminder if it the time has changed
                var reminder = actor.TryGetReminder(ActivityTimerExpirationReminderName);
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
                        TimeSpan.FromMilliseconds(-1));
            }
            else
            {
                // no reminder required, unregister existing reminder
                var reminder = actor.TryGetReminder(ActivityTimerExpirationReminderName);
                if (reminder != null)
                    await actor.UnregisterReminderAsync(reminder);
            }
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

                // reset state
                await state.SetInstanceId(Guid.Empty);
                await state.ClearInstanceData();
                await state.ClearInstanceMetadata();
            }

            // generate owner ID
            if (await state.GetInstanceOwnerId() == Guid.Empty)
                await state.SetInstanceOwnerId(Guid.NewGuid());

            // create new workflow
            workflow = CreateWorkflow(actor.CreateActivity(), actor.CreateActivityInputs());
            if (workflow == null)
                throw new ActivityActorException("CreateWorkflow returned null.");

            // initialize state
            await state.SetInstanceId(workflow.Id);

            // run instance
            await workflow.RunAsync();
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task RunAsync()
        {
            await workflow.RunAsync();
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal async Task ResumeAsync(Bookmark bookmark, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmark.Name))
                await workflow.ResumeBookmarkAsync(bookmark, value, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task ResumeAsync(Bookmark bookmark, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmark.Name))
                await workflow.ResumeBookmarkAsync(bookmark, value);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal Task ResumeAsync(Bookmark bookmark, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return ResumeAsync(bookmark, null, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/>.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        internal Task ResumeAsync(Bookmark bookmark)
        {
            Contract.Requires<ArgumentNullException>(bookmark != null);

            return ResumeAsync(bookmark, null);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal async Task ResumeAsync(string bookmarkName, object value, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmarkName))
                await workflow.ResumeBookmarkAsync(bookmarkName, value, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/> with the given <paramref name="value"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task ResumeAsync(string bookmarkName, object value)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmarkName))
                await workflow.ResumeBookmarkAsync(bookmarkName, value);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        internal Task ResumeAsync(string bookmarkName, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

            return ResumeAsync(bookmarkName, null, timeout);
        }

        /// <summary>
        /// Resumes the <see cref="ActivityActor{TActivity}"/>.
        /// </summary>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        internal Task ResumeAsync(string bookmarkName)
        {
            Contract.Requires<ArgumentNullException>(bookmarkName != null);
            Contract.Requires<ArgumentException>(bookmarkName.Length > 0);

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
        internal Task ReceiveReminderAsync(string reminderName, byte[] context, TimeSpan dueTime, TimeSpan period)
        {
            if (reminderName == ActivityTimerExpirationReminderName)
            {
                // just used to wake the workflow up
                // once activated it should handle the events on its own
            }

            return Task.FromResult(true);
        }

    }

}
