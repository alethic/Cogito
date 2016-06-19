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
            this.state.Persisted = OnPersistedFromStore;
            this.state.Completed = OnCompletedFromStore;
        }

        /// <summary>
        /// Throws if the workflow is in an invalid state.
        /// </summary>
        void ThrowIfInvalidState()
        {
            if (workflow == null)
                throw new ActivityStateException();
        }

        /// <summary>
        /// Create a new <see cref="WorkflowApplication"/> instance.
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="inputs"></param>
        /// <returns></returns>
        Task CreateWorkflow(Activity activity, IDictionary<string, object> inputs = null)
        {
            Contract.Requires<ArgumentNullException>(activity != null);

            workflow = inputs != null ? new WorkflowApplication(activity, inputs) : new WorkflowApplication(activity);
            workflow.SynchronizationContext = new ActivityActorSynchronizationContext(actor);
            workflow.InstanceStore = new ActivityActorInstanceStore(state);

            workflow.OnUnhandledException = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnException(args.UnhandledException);
                }, null);

                return UnhandledExceptionAction.Abort;
            };

            workflow.Aborted = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnAborted(args.Reason);
                }, null);
            };

            workflow.PersistableIdle = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnPersistableIdle();
                }, null);

                // workflow should save state but not unload until actor deactivated
                // workflow timers invoke themselves as long as it's loaded
                return PersistableIdleAction.Persist;
            };

            workflow.Idle = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnIdle();
                }, null);
            };

            workflow.Completed = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
                {
                    await actor.OnCompleted(args.CompletionState, args.Outputs);
                }, null);
            };

            workflow.Unloaded = args =>
            {
                workflow.SynchronizationContext.Post(async o =>
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

            return Task.FromResult(true);
        }

        /// <summary>
        /// Attempts to load the workflow if possible.
        /// </summary>
        /// <returns></returns>
        async Task LoadWorkflow()
        {
            // might already be loaded somehow
            if (workflow == null)
            {
                // only continue if not already completed
                if (await state.GetInstanceState() != InstanceState.Completed)
                {
                    // generate owner ID
                    if (await state.GetInstanceOwnerId() == Guid.Empty)
                        await state.SetInstanceOwnerId(Guid.NewGuid());

                    if (await state.GetInstanceId() == Guid.Empty)
                    {
                        // create workflow
                        await CreateWorkflow(actor.CreateActivity(), actor.CreateActivityInputs() ?? new Dictionary<string, object>());
                        await state.SetInstanceId(workflow.Id);
                        await workflow.RunAsync();
                        await workflow.PersistAsync();
                        DeferExecuteSynchronizationContext();
                    }
                    else
                    {
                        // load workflow
                        await CreateWorkflow(actor.CreateActivity());
                        await workflow.LoadAsync(await state.GetInstanceId());
                        await workflow.RunAsync();
                        await workflow.PersistAsync();
                        DeferExecuteSynchronizationContext();
                    }
                }
            }
        }

        /// <summary>
        /// Executes any outstanding tasks put onto the synchronization context.
        /// </summary>
        void DeferExecuteSynchronizationContext()
        {
            ThrowIfInvalidState();
            var s = (ActivityActorSynchronizationContext)workflow.SynchronizationContext;
            s.DeferExecute();
        }

        /// <summary>
        /// Attempts to unload the workflow if possible.
        /// </summary>
        /// <returns></returns>
        async Task UnloadWorkflow()
        {
            if (workflow != null)
            {
                try
                {
                    // schedule unload
                    var t = workflow.UnloadAsync(TimeSpan.FromMinutes(1));

                    // drain outstanding executions; this is very imprecise
                    DeferExecuteSynchronizationContext();
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    DeferExecuteSynchronizationContext();
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    DeferExecuteSynchronizationContext();

                    // await unload method
                    await t;

                    // just in case
                    DeferExecuteSynchronizationContext();
                }
                catch (TimeoutException)
                {

                }
                finally
                {
                    workflow = null;
                }
            }
        }

        /// <summary>
        /// Invoked by the instance store after the workflow instance has been persisted.
        /// </summary>
        /// <returns></returns>
        async Task OnPersistedFromStore()
        {
            await SaveReminderAsync();
            await actor.OnPersisted();
        }

        /// <summary>
        /// Invoked by the instance store after the workflow instance has been completed.
        /// </summary>
        /// <returns></returns>
        async Task OnCompletedFromStore()
        {
            await SaveReminderAsync();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnActivateAsync()
        {
            await LoadWorkflow();
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        internal async Task OnDeactivateAsync()
        {
            await UnloadWorkflow();
        }

        /// <summary>
        /// Ensures workflow timers are registered for waking the instance up.
        /// </summary>
        /// <returns></returns>
        async Task SaveReminderAsync()
        {
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
            await UnloadWorkflow();
            await state.SetInstanceId(Guid.Empty);
            await state.SetInstanceState(InstanceState.Unknown);
            await state.ClearInstanceData();
            await state.ClearInstanceMetadata();
            await LoadWorkflow();
        }

        /// <summary>
        /// Runs the workflow.
        /// </summary>
        /// <returns></returns>
        internal async Task RunAsync()
        {
            ThrowIfInvalidState();
            await workflow.RunAsync();
            DeferExecuteSynchronizationContext();
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
            ThrowIfInvalidState();

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmark.Name))
            {
                await workflow.ResumeBookmarkAsync(bookmark, value, timeout);
                DeferExecuteSynchronizationContext();
            }
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
            ThrowIfInvalidState();

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmark.Name))
            {
                await workflow.ResumeBookmarkAsync(bookmark, value);
                DeferExecuteSynchronizationContext();
            }
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
            ThrowIfInvalidState();

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
            ThrowIfInvalidState();

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
            ThrowIfInvalidState();

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmarkName))
            {
                await workflow.ResumeBookmarkAsync(bookmarkName, value, timeout);
                DeferExecuteSynchronizationContext();
            }
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
            ThrowIfInvalidState();

            if (workflow.GetBookmarks().Any(i => i.BookmarkName == bookmarkName))
            {
                await workflow.ResumeBookmarkAsync(bookmarkName, value);
                DeferExecuteSynchronizationContext();
            }
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
            ThrowIfInvalidState();

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
            ThrowIfInvalidState();

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
                // execute any remaining tasks
                DeferExecuteSynchronizationContext();
            }

            return Task.FromResult(true);
        }

    }

}
