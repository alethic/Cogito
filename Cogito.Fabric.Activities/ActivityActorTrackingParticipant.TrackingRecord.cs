using System.Activities.Tracking;

namespace Cogito.Fabric.Activities
{

	public partial class ActivityActorTrackingParticipant
	{

		void TrackRecord(TrackingRecord record)
		{
			if (record is CustomTrackingRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.CustomTracking(actor, (CustomTrackingRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceUpdatedRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUpdated(actor, (WorkflowInstanceUpdatedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceUnhandledExceptionRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUnhandledException(actor, (WorkflowInstanceUnhandledExceptionRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceTerminatedRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstanceTerminated(actor, (WorkflowInstanceTerminatedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceSuspendedRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstanceSuspended(actor, (WorkflowInstanceSuspendedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceAbortedRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstanceAborted(actor, (WorkflowInstanceAbortedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.WorkflowInstance(actor, (WorkflowInstanceRecord)record);
					return;
				}
			}

			if (record is FaultPropagationRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.FaultPropagation(actor, (FaultPropagationRecord)record);
					return;
				}
			}

			if (record is CancelRequestedRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.CancelRequested(actor, (CancelRequestedRecord)record);
					return;
				}
			}

			if (record is BookmarkResumptionRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.BookmarkResumption(actor, (BookmarkResumptionRecord)record);
					return;
				}
			}

			if (record is ActivityStateRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.ActivityState(actor, (ActivityStateRecord)record);
					return;
				}
			}

			if (record is ActivityScheduledRecord)
			{
				if (actor is IActivityActor)
				{
					ActivityActorEventSource.Current.ActivityScheduled(actor, (ActivityScheduledRecord)record);
					return;
				}
			}

		}

	}

}