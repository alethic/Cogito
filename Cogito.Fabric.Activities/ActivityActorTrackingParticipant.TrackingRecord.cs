using System.Activities.Tracking;

namespace Cogito.Fabric.Activities
{

	public partial class ActivityActorTrackingParticipant
	{

		void TrackRecord(TrackingRecord record)
		{
			if (record is CustomTrackingRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.CustomTracking((IStatelessActivityActorInternal)actor, (CustomTrackingRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.CustomTracking((IStatefulActivityActorInternal)actor, (CustomTrackingRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceUpdatedRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUpdated((IStatelessActivityActorInternal)actor, (WorkflowInstanceUpdatedRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUpdated((IStatefulActivityActorInternal)actor, (WorkflowInstanceUpdatedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceUnhandledExceptionRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUnhandledException((IStatelessActivityActorInternal)actor, (WorkflowInstanceUnhandledExceptionRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceUnhandledException((IStatefulActivityActorInternal)actor, (WorkflowInstanceUnhandledExceptionRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceTerminatedRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceTerminated((IStatelessActivityActorInternal)actor, (WorkflowInstanceTerminatedRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceTerminated((IStatefulActivityActorInternal)actor, (WorkflowInstanceTerminatedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceSuspendedRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceSuspended((IStatelessActivityActorInternal)actor, (WorkflowInstanceSuspendedRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceSuspended((IStatefulActivityActorInternal)actor, (WorkflowInstanceSuspendedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceAbortedRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceAborted((IStatelessActivityActorInternal)actor, (WorkflowInstanceAbortedRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstanceAborted((IStatefulActivityActorInternal)actor, (WorkflowInstanceAbortedRecord)record);
					return;
				}
			}

			if (record is WorkflowInstanceRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstance((IStatelessActivityActorInternal)actor, (WorkflowInstanceRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.WorkflowInstance((IStatefulActivityActorInternal)actor, (WorkflowInstanceRecord)record);
					return;
				}
			}

			if (record is FaultPropagationRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.FaultPropagation((IStatelessActivityActorInternal)actor, (FaultPropagationRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.FaultPropagation((IStatefulActivityActorInternal)actor, (FaultPropagationRecord)record);
					return;
				}
			}

			if (record is CancelRequestedRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.CancelRequested((IStatelessActivityActorInternal)actor, (CancelRequestedRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.CancelRequested((IStatefulActivityActorInternal)actor, (CancelRequestedRecord)record);
					return;
				}
			}

			if (record is BookmarkResumptionRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.BookmarkResumption((IStatelessActivityActorInternal)actor, (BookmarkResumptionRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.BookmarkResumption((IStatefulActivityActorInternal)actor, (BookmarkResumptionRecord)record);
					return;
				}
			}

			if (record is ActivityStateRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.ActivityState((IStatelessActivityActorInternal)actor, (ActivityStateRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.ActivityState((IStatefulActivityActorInternal)actor, (ActivityStateRecord)record);
					return;
				}
			}

			if (record is ActivityScheduledRecord)
			{
				if (actor is IStatelessActivityActorInternal)
				{
					ActivityActorEventSource.Current.ActivityScheduled((IStatelessActivityActorInternal)actor, (ActivityScheduledRecord)record);
					return;
				}

				if (actor is IStatefulActivityActorInternal)
				{
					ActivityActorEventSource.Current.ActivityScheduled((IStatefulActivityActorInternal)actor, (ActivityScheduledRecord)record);
					return;
				}
			}

		}

	}

}