using System;
using System.Activities.Tracking;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void ActivityStateRecord(IStatefulActivityActorInternal actor, ActivityStateRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                ActivityStateRecord(
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
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    record.Arguments.Count > 0 ? PrepareDictionary(record.Arguments) : emptyItemsTag,
                    record.Variables.Count > 0 ? PrepareDictionary(record.Variables) : emptyItemsTag,
                    string.Format(message, args));
        }

        [NonEvent]
        public void ActivityStateRecord(IStatelessActivityActorInternal actor, ActivityStateRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
                ActivityStateRecord(
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
                    record.Activity.Name,
                    record.Activity.Id,
                    record.Activity.InstanceId,
                    record.Activity.TypeName,
                    record.Arguments.Count > 0 ? PrepareDictionary(record.Arguments) : emptyItemsTag,
                    record.Variables.Count > 0 ? PrepareDictionary(record.Variables) : emptyItemsTag,
                    string.Format(message, args));
        }

        [Event(ActivityStateRecordEventId, Level = EventLevel.Informational, Message = "{20}")]
        public void ActivityStateRecord(
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
            string activityName,
            string activityId,
            string activityInstanceId,
            string activityTypeName,
            string arguments,
            string variables,
            string message)
        {
            WriteEvent(
                ActivityStateRecordEventId,
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
                activityName,
                activityId,
                activityInstanceId,
                activityTypeName,
                arguments,
                variables,
                message);
        }

    }

}
