using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void CancelRequestedRecord(IStatefulActivityActorInternal actor, CancelRequestedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                CancelRequestedRecord(
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
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    string.Format(message, args));
        }

        [NonEvent]
        public void CancelRequestedRecord(IStatelessActivityActorInternal actor, CancelRequestedRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                CancelRequestedRecord(
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
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    string.Format(message, args));
        }

        [Event(CancelRequestedRecordEventId, Level = EventLevel.Informational, Message = "{17}")]
        public void CancelRequestedRecord(
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
            string activityName,
            string activityId,
            string activityInstanceId,
            string activityTypeName,
            string message)
        {
            WriteEvent(
                CancelRequestedRecordEventId,
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
                activityName,
                activityId,
                activityInstanceId,
                activityTypeName,
                message);
        }

    }

}
