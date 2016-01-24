using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void CustomTrackingRecord(IStatefulActivityActorInternal actor, CustomTrackingRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                CustomTrackingRecord(
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
                    record.Name,
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    record.Data.Count > 0 ? PrepareDictionary(record.Data) : emptyItemsTag,
                    string.Format(message, args));
        }

        [NonEvent]
        public void CustomTrackingRecord(IStatelessActivityActorInternal actor, CustomTrackingRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                CustomTrackingRecord(
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
                    record.Name,
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    record.Data.Count > 0 ? PrepareDictionary(record.Data) : emptyItemsTag,
                    string.Format(message, args));
        }

        [Event(CustomTrackingRecordEventId, Level = EventLevel.Informational, Message = "{19}")]
        public void CustomTrackingRecord(
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
            string name,
            string activityName,
            string activityId,
            string activityInstanceId,
            string activityTypeName,
            string data,
            string message)
        {
            WriteEvent(
                CustomTrackingRecordEventId,
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
                name,
                activityName,
                activityId,
                activityInstanceId,
                activityTypeName,
                data,
                message);
        }

    }

}
