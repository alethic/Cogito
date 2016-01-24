using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void WorkflowInstanceUpdatedRecord(IStatefulActivityActorInternal actor, WorkflowInstanceUpdatedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceUpdatedRecord(
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
                    record.IsSuccessful,
                    string.Format(message, args));
        }

        [NonEvent]
        public void WorkflowInstanceUpdatedRecord(IStatelessActivityActorInternal actor, WorkflowInstanceUpdatedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceUpdatedRecord(
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
                    record.IsSuccessful,
                    string.Format(message, args));
        }

        [Event(WorkflowInstanceUpdatedRecordEventId, Level = EventLevel.Informational, Message = "{17}")]
        public void WorkflowInstanceUpdatedRecord(
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
            bool isSuccessful,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUpdatedRecordEventId,
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
                isSuccessful,
                message);
        }

    }

}
