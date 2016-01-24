using System;
using System.Activities.Tracking;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Fabric;


namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        [NonEvent]
        public void ActivityScheduledRecord(IStatefulActivityActorInternal actor, ActivityScheduledRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordVerbose(
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
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordInformational(
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
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordWarning(
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
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordError(
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
                    return;
                }

            }
        }
        [NonEvent]
        public void ActivityScheduledRecord(IStatelessActivityActorInternal actor, ActivityScheduledRecord record, string message = "", params object[] args)
        {
            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordVerbose(
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
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordInformational(
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
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordWarning(
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
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityScheduledRecord))
                {
                    ActivityScheduledRecordError(
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
                    return;
                }

            }
        }

        [Event(ActivityScheduledRecordEventId, Level = EventLevel.Verbose, Message = "{17}")]
        public void ActivityScheduledRecordVerbose(
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
                ActivityScheduledRecordEventId,
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


        [Event(ActivityScheduledRecordEventId, Level = EventLevel.Informational, Message = "{17}")]
        public void ActivityScheduledRecordInformational(
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
                ActivityScheduledRecordEventId,
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


        [Event(ActivityScheduledRecordEventId, Level = EventLevel.Warning, Message = "{17}")]
        public void ActivityScheduledRecordWarning(
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
                ActivityScheduledRecordEventId,
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


        [Event(ActivityScheduledRecordEventId, Level = EventLevel.Error, Message = "{17}")]
        public void ActivityScheduledRecordError(
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
                ActivityScheduledRecordEventId,
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
