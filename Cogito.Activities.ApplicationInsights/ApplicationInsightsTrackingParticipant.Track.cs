using System;
using System.Activities.Tracking;
using System.Diagnostics;
using System.Diagnostics.Contracts;

using Microsoft.ApplicationInsights.DataContracts;

namespace Cogito.Activities.ApplicationInsights
{

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void ActivityScheduled(ActivityScheduledRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					ActivityScheduledTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					ActivityScheduledTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					ActivityScheduledTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					ActivityScheduledTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void ActivityScheduledTrack(ActivityScheduledRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "ActivityScheduled";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["activityName"] = record.Activity?.Name;
            telemetry.Properties["activityId"] = record.Activity?.Id;
            telemetry.Properties["activityInstanceId"] = record.Activity?.InstanceId;
            telemetry.Properties["activityTypeName"] = record.Activity?.TypeName;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void ActivityState(ActivityStateRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					ActivityStateTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					ActivityStateTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					ActivityStateTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					ActivityStateTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void ActivityStateTrack(ActivityStateRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "ActivityState";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["activityName"] = record.Activity?.Name;
            telemetry.Properties["activityId"] = record.Activity?.Id;
            telemetry.Properties["activityInstanceId"] = record.Activity?.InstanceId;
            telemetry.Properties["activityTypeName"] = record.Activity?.TypeName;
            telemetry.Properties["arguments"] = PrepareDictionary(record.Arguments);
            telemetry.Properties["variables"] = PrepareDictionary(record.Variables);
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void BookmarkResumption(BookmarkResumptionRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					BookmarkResumptionTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					BookmarkResumptionTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					BookmarkResumptionTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					BookmarkResumptionTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void BookmarkResumptionTrack(BookmarkResumptionRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "BookmarkResumption";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["bookmarkName"] = record.BookmarkName;
            telemetry.Properties["bookmarkScope"] = record.BookmarkScope.ToString();
            telemetry.Properties["payload"] = null;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void CancelRequested(CancelRequestedRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					CancelRequestedTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					CancelRequestedTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					CancelRequestedTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					CancelRequestedTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void CancelRequestedTrack(CancelRequestedRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "CancelRequested";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["activityName"] = record.Activity?.Name;
            telemetry.Properties["activityId"] = record.Activity?.Id;
            telemetry.Properties["activityInstanceId"] = record.Activity?.InstanceId;
            telemetry.Properties["activityTypeName"] = record.Activity?.TypeName;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void FaultPropagation(FaultPropagationRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					FaultPropagationTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					FaultPropagationTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					FaultPropagationTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					FaultPropagationTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void FaultPropagationTrack(FaultPropagationRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "FaultPropagation";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["fault"] = record.Fault?.ToString();
            telemetry.Properties["faultMessage"] = record.Fault?.Message;
            telemetry.Properties["faultSourceName"] = record.FaultSource?.Name;
            telemetry.Properties["faultSourceId"] = record.FaultSource?.Id;
            telemetry.Properties["faultSourceInstanceId"] = record.FaultSource?.InstanceId;
            telemetry.Properties["faultSourceTypeName"] = record.FaultSource?.TypeName;
            telemetry.Properties["faultHandlerName"] = record.FaultHandler?.Name;
            telemetry.Properties["faultHandlerId"] = record.FaultHandler?.Id;
            telemetry.Properties["faultHandlerInstanceId"] = record.FaultHandler?.InstanceId;
            telemetry.Properties["faultHandlerTypeName"] = record.FaultHandler?.TypeName;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstance(WorkflowInstanceRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceTrack(WorkflowInstanceRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstance";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstanceAborted(WorkflowInstanceAbortedRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceAbortedTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceAbortedTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceAbortedTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceAbortedTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceAbortedTrack(WorkflowInstanceAbortedRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstanceAborted";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            telemetry.Properties["reason"] = record.Reason;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstanceSuspended(WorkflowInstanceSuspendedRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceSuspendedTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceSuspendedTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceSuspendedTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceSuspendedTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceSuspendedTrack(WorkflowInstanceSuspendedRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstanceSuspended";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            telemetry.Properties["reason"] = record.Reason;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstanceTerminated(WorkflowInstanceTerminatedRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceTerminatedTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceTerminatedTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceTerminatedTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceTerminatedTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceTerminatedTrack(WorkflowInstanceTerminatedRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstanceTerminated";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            telemetry.Properties["reason"] = record.Reason;
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstanceUnhandledException(WorkflowInstanceUnhandledExceptionRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceUnhandledExceptionTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceUnhandledExceptionTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceUnhandledExceptionTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceUnhandledExceptionTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceUnhandledExceptionTrack(WorkflowInstanceUnhandledExceptionRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstanceUnhandledException";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            telemetry.Properties["faultSourceName"] = record.FaultSource?.Name;
            telemetry.Properties["faultSourceId"] = record.FaultSource?.Id;
            telemetry.Properties["faultSourceInstanceId"] = record.FaultSource?.InstanceId;
            telemetry.Properties["faultSourceTypeName"] = record.FaultSource?.TypeName;
            telemetry.Properties["unhandledException"] = record.UnhandledException?.ToString();
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void WorkflowInstanceUpdated(WorkflowInstanceUpdatedRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					WorkflowInstanceUpdatedTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					WorkflowInstanceUpdatedTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					WorkflowInstanceUpdatedTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					WorkflowInstanceUpdatedTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void WorkflowInstanceUpdatedTrack(WorkflowInstanceUpdatedRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "WorkflowInstanceUpdated";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["state"] = record.State;
            telemetry.Properties["workflowDefinitionIdentityName"] = record.WorkflowDefinitionIdentity?.Name;
            telemetry.Properties["activityDefinitionId"] = record.ActivityDefinitionId;
            telemetry.Properties["isSuccessful"] = record.IsSuccessful ? "true" : "false";
            TrackTelemetry(telemetry);
        }

    }

    sealed partial class ApplicationInsightsTrackingParticipant
    {
        
        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        internal void CustomTracking(CustomTrackingRecord record)
        {
            Contract.Requires<ArgumentNullException>(record != null);

			switch (record.Level)
			{
				case TraceLevel.Verbose:
					CustomTrackingTrack(record, SeverityLevel.Verbose);
					break;
				case TraceLevel.Info:
					CustomTrackingTrack(record, SeverityLevel.Information);
					break;
				case TraceLevel.Warning:
					CustomTrackingTrack(record, SeverityLevel.Warning);
					break;
				case TraceLevel.Error:
					CustomTrackingTrack(record, SeverityLevel.Error);
					break;
			}
        }

        /// <summary>
        /// Records an event.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="severityLevel"></param>
        internal void CustomTrackingTrack(CustomTrackingRecord record, SeverityLevel severityLevel)
        {
            Contract.Requires<ArgumentNullException>(record != null);

            var telemetry = new TraceTelemetry();
            telemetry.Context.Operation.Id = record.InstanceId.ToString();
            telemetry.Timestamp = record.EventTime;
            telemetry.Sequence = record.RecordNumber.ToString();
            telemetry.Message = "CustomTracking";
            telemetry.SeverityLevel = severityLevel;
            telemetry.Properties["annotations"] = PrepareAnnotations(record.Annotations);
            telemetry.Properties["name"] = record.Name;
            telemetry.Properties["activityName"] = record.Activity?.Name;
            telemetry.Properties["activityId"] = record.Activity?.Id;
            telemetry.Properties["activityInstanceId"] = record.Activity?.InstanceId;
            telemetry.Properties["activityTypeName"] = record.Activity?.TypeName;
            telemetry.Properties["data"] = PrepareDictionary(record.Data);
            TrackTelemetry(telemetry);
        }

    }
}
