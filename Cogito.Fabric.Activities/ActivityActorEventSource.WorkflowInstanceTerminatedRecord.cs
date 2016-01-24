using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void WorkflowInstanceTerminatedRecord(IStatefulActivityActorInternal actor, WorkflowInstanceTerminatedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceTerminatedRecord(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationTypeName,
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationName,
                    actor.ActorService.ServiceInitializationParameters.ServiceTypeName,
                    actor.ActorService.ServiceInitializationParameters.ServiceName.ToString(),
                    actor.ActorService.ServiceInitializationParameters.PartitionId,
                    actor.ActorService.ServiceInitializationParameters.ReplicaId,
                    FabricRuntime.GetNodeContext().NodeName,
                    record.InstanceId,
                    record.RecordNumber,
                    record.EventTime.ToFileTimeUtc(),
                    record.Annotations != null ? PrepareAnnotations(record.Annotations) : null,
                    record.State,
                    record.WorkflowDefinitionIdentity.Name,
                    record.ActivityDefinitionId,
                    record.Reason,
                    string.Format(message, args));
        }

        [NonEvent]
        public void WorkflowInstanceTerminatedRecord(IStatelessActivityActorInternal actor, WorkflowInstanceTerminatedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceTerminatedRecord(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationTypeName,
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationName,
                    actor.ActorService.ServiceInitializationParameters.ServiceTypeName,
                    actor.ActorService.ServiceInitializationParameters.ServiceName.ToString(),
                    actor.ActorService.ServiceInitializationParameters.PartitionId,
                    actor.ActorService.ServiceInitializationParameters.InstanceId,
                    FabricRuntime.GetNodeContext().NodeName,
                    record.InstanceId,
                    record.RecordNumber,
                    record.EventTime.ToFileTimeUtc(),
                    record.Annotations != null ? PrepareAnnotations(record.Annotations) : null,
                    record.State,
                    record.WorkflowDefinitionIdentity.Name,
                    record.ActivityDefinitionId,
                    record.Reason,
                    string.Format(message, args));
        }

        [Event(WorkflowInstanceTerminatedRecordEventId, Level = EventLevel.Informational, Message = "{17}")]
        public void WorkflowInstanceTerminatedRecord(
            string actorType,
            string actorId,
            string applicationTypeName,
            string applicationName,
            string serviceTypeName,
            string serviceName,
            Guid partitionId,
            long replicaOrInstanceId,
            string nodeName,
            Guid instanceId,
            long recordNumber,
            long eventTime,
            string annotations,
            string state,
            string workflowDefinitionIdentity,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceTerminatedRecordEventId,
                actorType,
                actorId,
                applicationTypeName,
                applicationName,
                serviceTypeName,
                serviceName,
                partitionId,
                replicaOrInstanceId,
                nodeName,
                instanceId,
                recordNumber,
                eventTime,
                annotations,
                state,
                workflowDefinitionIdentity,
                activityDefinitionId,
                reason,
                message);
        }

    }

}
