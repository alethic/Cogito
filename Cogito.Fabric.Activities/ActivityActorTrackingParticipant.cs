using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml;

namespace Cogito.Fabric.Activities
{

    public class ActivityActorTrackingParticipant :
        TrackingParticipant
    {

        readonly IActivityActorInternal actor;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorTrackingParticipant(IActivityActorInternal actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            if (ActivityActorEventSource.Current.IsEnabled())
            {
                try
                {
                    TrackRecord(record);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        void TrackRecord(TrackingRecord record)
        {
            if (record is ActivityStateRecord)
                TrackActivityStateRecord((ActivityStateRecord)record);
            else if (record is WorkflowInstanceRecord)
                TrackWorkflowInstanceRecord((WorkflowInstanceRecord)record);
            else if (record is BookmarkResumptionRecord)
                TrackBookmarkResumptionRecord((BookmarkResumptionRecord)record);
            else if (record is ActivityScheduledRecord)
                TrackActivityScheduledRecord((ActivityScheduledRecord)record);
            else if (record is CancelRequestedRecord)
                TrackCancelRequestedRecord((CancelRequestedRecord)record);
            else if (record is FaultPropagationRecord)
                TrackFaultPropagationRecord((FaultPropagationRecord)record);
            else if (record is CustomTrackingRecord)
                TrackCustomTrackingRecord((CustomTrackingRecord)record);
            else
                throw new InvalidOperationException();
        }

        void TrackActivityStateRecord(ActivityStateRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.ActivityStateRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.ActivityStateRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackWorkflowInstanceRecord(WorkflowInstanceRecord record)
        {
            if (record is WorkflowInstanceAbortedRecord)
            {
                TrackWorkflowInstanceAbortedRecord((WorkflowInstanceAbortedRecord)record);
            }
            else if (record is WorkflowInstanceSuspendedRecord)
            {
                TrackWorkflowInstanceSuspendedRecord((WorkflowInstanceSuspendedRecord)record);
            }
            else if (record is WorkflowInstanceTerminatedRecord)
            {
                TrackWorkflowInstanceTerminatedRecord((WorkflowInstanceTerminatedRecord)record);
            }
            else if (record is WorkflowInstanceUnhandledExceptionRecord)
            {
                TrackWorkflowInstanceUnhandledExceptionRecord((WorkflowInstanceUnhandledExceptionRecord)record);
            }
            else if (record is WorkflowInstanceUpdatedRecord)
            {
                TrackWorkflowInstanceUpdatedRecord((WorkflowInstanceUpdatedRecord)record);
            }
            else
            {
                if (actor is IStatelessActivityActorInternal)
                {
                    ActivityActorEventSource.Current.WorkflowInstanceRecord((IStatelessActivityActorInternal)actor, record);
                }
                else if (actor is IStatefulActivityActorInternal)
                {
                    ActivityActorEventSource.Current.WorkflowInstanceRecord((IStatefulActivityActorInternal)actor, record);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        void TrackWorkflowInstanceAbortedRecord(WorkflowInstanceAbortedRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceAbortedRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceAbortedRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackWorkflowInstanceSuspendedRecord(WorkflowInstanceSuspendedRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceSuspendedRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceSuspendedRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackWorkflowInstanceTerminatedRecord(WorkflowInstanceTerminatedRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceTerminatedRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceTerminatedRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackWorkflowInstanceUnhandledExceptionRecord(WorkflowInstanceUnhandledExceptionRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceUnhandledExceptionRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceUnhandledExceptionRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackWorkflowInstanceUpdatedRecord(WorkflowInstanceUpdatedRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceUpdatedRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.WorkflowInstanceUpdatedRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackBookmarkResumptionRecord(BookmarkResumptionRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.BookmarkResumptionRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.BookmarkResumptionRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackActivityScheduledRecord(ActivityScheduledRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.ActivityScheduledRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.ActivityScheduledRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackCancelRequestedRecord(CancelRequestedRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.CancelRequestedRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.CancelRequestedRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackFaultPropagationRecord(FaultPropagationRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.FaultPropagationRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.FaultPropagationRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

        void TrackCustomTrackingRecord(CustomTrackingRecord record)
        {
            if (actor is IStatelessActivityActorInternal)
                ActivityActorEventSource.Current.CustomTrackingRecord((IStatelessActivityActorInternal)actor, record);
            else if (actor is IStatefulActivityActorInternal)
                ActivityActorEventSource.Current.CustomTrackingRecord((IStatefulActivityActorInternal)actor, record);
            else
                throw new InvalidOperationException();
        }

    }

}
