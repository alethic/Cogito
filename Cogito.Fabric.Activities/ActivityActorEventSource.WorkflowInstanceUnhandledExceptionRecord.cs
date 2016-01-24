using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void WorkflowInstanceUnhandledExceptionRecord(IStatefulActivityActorInternal actor, WorkflowInstanceUnhandledExceptionRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceUnhandledExceptionRecord(
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
                    record.FaultSource.Name,
                    record.UnhandledException != null ? record.UnhandledException.Message : null,
                    string.Format(message, args));
        }

        [NonEvent]
        public void WorkflowInstanceUnhandledExceptionRecord(IStatelessActivityActorInternal actor, WorkflowInstanceUnhandledExceptionRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                WorkflowInstanceUnhandledExceptionRecord(
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
                    record.FaultSource.Name,
                    record.UnhandledException != null ? record.UnhandledException.Message : null,
                    string.Format(message, args));
        }

        [Event(WorkflowInstanceUnhandledExceptionRecordEventId, Level = EventLevel.Informational, Message = "{18}")]
        public void WorkflowInstanceUnhandledExceptionRecord(
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
            string faultSourceName,
            string exception,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUnhandledExceptionRecordEventId,
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
                faultSourceName,
                exception,
                message);
        }

    }

}
