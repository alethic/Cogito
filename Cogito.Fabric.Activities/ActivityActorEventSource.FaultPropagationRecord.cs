using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void FaultPropagationRecord(IStatefulActivityActorInternal actor, FaultPropagationRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                FaultPropagationRecord(
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
                    record.Fault.Message,
                    record.FaultSource.Name,
                    record.FaultSource.Id,
                    record.FaultSource.InstanceId,
                    record.FaultSource.TypeName,
                    record.FaultHandler.Name,
                    record.FaultHandler.Id,
                    record.FaultHandler.InstanceId,
                    record.FaultHandler.TypeName,
                    string.Format(message, args));
        }

        [NonEvent]
        public void FaultPropagationRecord(IStatelessActivityActorInternal actor, FaultPropagationRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                FaultPropagationRecord(
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
                    record.Fault.Message,
                    record.FaultSource.Name,
                    record.FaultSource.Id,
                    record.FaultSource.InstanceId,
                    record.FaultSource.TypeName,
                    record.FaultHandler.Name,
                    record.FaultHandler.Id,
                    record.FaultHandler.InstanceId,
                    record.FaultHandler.TypeName,
                    string.Format(message, args));
        }

        [Event(FaultPropagationRecordEventId, Level = EventLevel.Informational, Message = "{22}")]
        public void FaultPropagationRecord(
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
            string faultMessage,
            string faultSourceName,
            string faultSourceId,
            string faultSourceInstanceId,
            string faultSourceTypeName,
            string faultHandlerName,
            string faultHandlerId,
            string faultHandlerInstanceId,
            string faultHandlerTypeName,
            string message)
        {
            WriteEvent(
                FaultPropagationRecordEventId,
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
                faultMessage,
                faultSourceName,
                faultSourceId,
                faultSourceInstanceId,
                faultSourceTypeName,
                faultHandlerName,
                faultHandlerId,
                faultHandlerInstanceId,
                faultHandlerTypeName,
                message);
        }

    }

}
