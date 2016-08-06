using System.Activities.Tracking;

namespace Cogito.Activities.ApplicationInsights
{

	public partial class ApplicationInsightsTrackingParticipant
	{

        /// <summary>
        /// Tracks an incoming <see cref="TrackingRecord"/> by dispatching it to the appropriate implementation.
        /// </summary>
        /// <param name="record"></param>
		void TrackRecord(TrackingRecord record)
		{
			if (record is CustomTrackingRecord)
			{
				CustomTracking((CustomTrackingRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceUpdatedRecord)
			{
				WorkflowInstanceUpdated((WorkflowInstanceUpdatedRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceUnhandledExceptionRecord)
			{
				WorkflowInstanceUnhandledException((WorkflowInstanceUnhandledExceptionRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceTerminatedRecord)
			{
				WorkflowInstanceTerminated((WorkflowInstanceTerminatedRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceSuspendedRecord)
			{
				WorkflowInstanceSuspended((WorkflowInstanceSuspendedRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceAbortedRecord)
			{
				WorkflowInstanceAborted((WorkflowInstanceAbortedRecord)record);
				return;
			}
			
			if (record is WorkflowInstanceRecord)
			{
				WorkflowInstance((WorkflowInstanceRecord)record);
				return;
			}
			
			if (record is FaultPropagationRecord)
			{
				FaultPropagation((FaultPropagationRecord)record);
				return;
			}
			
			if (record is CancelRequestedRecord)
			{
				CancelRequested((CancelRequestedRecord)record);
				return;
			}
			
			if (record is BookmarkResumptionRecord)
			{
				BookmarkResumption((BookmarkResumptionRecord)record);
				return;
			}
			
			if (record is ActivityStateRecord)
			{
				ActivityState((ActivityStateRecord)record);
				return;
			}
			
			if (record is ActivityScheduledRecord)
			{
				ActivityScheduled((ActivityScheduledRecord)record);
				return;
			}
			
		}

	}

}