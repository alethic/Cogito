using System;
using System.Activities.Tracking;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Fabric;

namespace Cogito.Fabric.Activities
{

    public partial class ActivityActorEventSource
    {

        const int ActivityScheduledVerboseEventId = 10;
        const int ActivityScheduledInfoEventId = 11;
        const int ActivityScheduledWarningEventId = 12;
        const int ActivityScheduledErrorEventId = 13;
        
        [NonEvent]
        public void ActivityScheduled(IStatefulActivityActorInternal actor, ActivityScheduledRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityScheduled))
                {
                    ActivityScheduledVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityScheduled))
                {
                    ActivityScheduledInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityScheduled))
                {
                    ActivityScheduledWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityScheduled))
                {
                    ActivityScheduledError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void ActivityScheduled(IStatelessActivityActorInternal actor, ActivityScheduledRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityScheduled))
                {
                    ActivityScheduledVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityScheduled))
                {
                    ActivityScheduledInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityScheduled))
                {
                    ActivityScheduledWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityScheduled))
                {
                    ActivityScheduledError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            ActivityScheduledVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.ActivityScheduled)]
        public void ActivityScheduledVerbose(
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
                ActivityScheduledVerboseEventId,
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


        [Event(
            ActivityScheduledInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.ActivityScheduled)]
        public void ActivityScheduledInfo(
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
                ActivityScheduledInfoEventId,
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


        [Event(
            ActivityScheduledWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.ActivityScheduled)]
        public void ActivityScheduledWarning(
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
                ActivityScheduledWarningEventId,
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


        [Event(
            ActivityScheduledErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.ActivityScheduled)]
        public void ActivityScheduledError(
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
                ActivityScheduledErrorEventId,
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

    public partial class ActivityActorEventSource
    {

        const int ActivityStateVerboseEventId = 20;
        const int ActivityStateInfoEventId = 21;
        const int ActivityStateWarningEventId = 22;
        const int ActivityStateErrorEventId = 23;
        
        [NonEvent]
        public void ActivityState(IStatefulActivityActorInternal actor, ActivityStateRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityState))
                {
                    ActivityStateVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityState))
                {
                    ActivityStateInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityState))
                {
                    ActivityStateWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityState))
                {
                    ActivityStateError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void ActivityState(IStatelessActivityActorInternal actor, ActivityStateRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.ActivityState))
                {
                    ActivityStateVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.ActivityState))
                {
                    ActivityStateInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.ActivityState))
                {
                    ActivityStateWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.ActivityState))
                {
                    ActivityStateError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Arguments)) ?? string.Empty,
                        (PrepareDictionary(record.Variables)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            ActivityStateVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{20}", 
            Keywords = Keywords.ActivityState)]
        public void ActivityStateVerbose(
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
                ActivityStateVerboseEventId,
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


        [Event(
            ActivityStateInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{20}", 
            Keywords = Keywords.ActivityState)]
        public void ActivityStateInfo(
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
                ActivityStateInfoEventId,
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


        [Event(
            ActivityStateWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{20}", 
            Keywords = Keywords.ActivityState)]
        public void ActivityStateWarning(
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
                ActivityStateWarningEventId,
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


        [Event(
            ActivityStateErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{20}", 
            Keywords = Keywords.ActivityState)]
        public void ActivityStateError(
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
                ActivityStateErrorEventId,
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

    public partial class ActivityActorEventSource
    {

        const int BookmarkResumptionVerboseEventId = 30;
        const int BookmarkResumptionInfoEventId = 31;
        const int BookmarkResumptionWarningEventId = 32;
        const int BookmarkResumptionErrorEventId = 33;
        
        [NonEvent]
        public void BookmarkResumption(IStatefulActivityActorInternal actor, BookmarkResumptionRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void BookmarkResumption(IStatelessActivityActorInternal actor, BookmarkResumptionRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.BookmarkResumption))
                {
                    BookmarkResumptionError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.BookmarkName) ?? string.Empty,
                        record.BookmarkScope,
                        (null) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            BookmarkResumptionVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{16}", 
            Keywords = Keywords.BookmarkResumption)]
        public void BookmarkResumptionVerbose(
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
            string bookmarkName,
            Guid bookmarkScope,
            string payload,
            string message)
        {
            WriteEvent(
                BookmarkResumptionVerboseEventId,
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
                bookmarkName,
                bookmarkScope,
                payload,
                message);
        }


        [Event(
            BookmarkResumptionInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{16}", 
            Keywords = Keywords.BookmarkResumption)]
        public void BookmarkResumptionInfo(
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
            string bookmarkName,
            Guid bookmarkScope,
            string payload,
            string message)
        {
            WriteEvent(
                BookmarkResumptionInfoEventId,
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
                bookmarkName,
                bookmarkScope,
                payload,
                message);
        }


        [Event(
            BookmarkResumptionWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{16}", 
            Keywords = Keywords.BookmarkResumption)]
        public void BookmarkResumptionWarning(
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
            string bookmarkName,
            Guid bookmarkScope,
            string payload,
            string message)
        {
            WriteEvent(
                BookmarkResumptionWarningEventId,
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
                bookmarkName,
                bookmarkScope,
                payload,
                message);
        }


        [Event(
            BookmarkResumptionErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{16}", 
            Keywords = Keywords.BookmarkResumption)]
        public void BookmarkResumptionError(
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
            string bookmarkName,
            Guid bookmarkScope,
            string payload,
            string message)
        {
            WriteEvent(
                BookmarkResumptionErrorEventId,
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
                bookmarkName,
                bookmarkScope,
                payload,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int CancelRequestedVerboseEventId = 40;
        const int CancelRequestedInfoEventId = 41;
        const int CancelRequestedWarningEventId = 42;
        const int CancelRequestedErrorEventId = 43;
        
        [NonEvent]
        public void CancelRequested(IStatefulActivityActorInternal actor, CancelRequestedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.CancelRequested))
                {
                    CancelRequestedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.CancelRequested))
                {
                    CancelRequestedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.CancelRequested))
                {
                    CancelRequestedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.CancelRequested))
                {
                    CancelRequestedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void CancelRequested(IStatelessActivityActorInternal actor, CancelRequestedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.CancelRequested))
                {
                    CancelRequestedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.CancelRequested))
                {
                    CancelRequestedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.CancelRequested))
                {
                    CancelRequestedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.CancelRequested))
                {
                    CancelRequestedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            CancelRequestedVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.CancelRequested)]
        public void CancelRequestedVerbose(
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
                CancelRequestedVerboseEventId,
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


        [Event(
            CancelRequestedInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.CancelRequested)]
        public void CancelRequestedInfo(
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
                CancelRequestedInfoEventId,
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


        [Event(
            CancelRequestedWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.CancelRequested)]
        public void CancelRequestedWarning(
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
                CancelRequestedWarningEventId,
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


        [Event(
            CancelRequestedErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.CancelRequested)]
        public void CancelRequestedError(
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
                CancelRequestedErrorEventId,
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

    public partial class ActivityActorEventSource
    {

        const int FaultPropagationVerboseEventId = 50;
        const int FaultPropagationInfoEventId = 51;
        const int FaultPropagationWarningEventId = 52;
        const int FaultPropagationErrorEventId = 53;
        
        [NonEvent]
        public void FaultPropagation(IStatefulActivityActorInternal actor, FaultPropagationRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.FaultPropagation))
                {
                    FaultPropagationVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.FaultPropagation))
                {
                    FaultPropagationInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.FaultPropagation))
                {
                    FaultPropagationWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.FaultPropagation))
                {
                    FaultPropagationError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void FaultPropagation(IStatelessActivityActorInternal actor, FaultPropagationRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.FaultPropagation))
                {
                    FaultPropagationVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.FaultPropagation))
                {
                    FaultPropagationInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.FaultPropagation))
                {
                    FaultPropagationWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.FaultPropagation))
                {
                    FaultPropagationError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Fault?.Message) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.FaultHandler?.Name) ?? string.Empty,
                        (record.FaultHandler?.Id) ?? string.Empty,
                        (record.FaultHandler?.InstanceId) ?? string.Empty,
                        (record.FaultHandler?.TypeName) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            FaultPropagationVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{22}", 
            Keywords = Keywords.FaultPropagation)]
        public void FaultPropagationVerbose(
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
                FaultPropagationVerboseEventId,
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


        [Event(
            FaultPropagationInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{22}", 
            Keywords = Keywords.FaultPropagation)]
        public void FaultPropagationInfo(
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
                FaultPropagationInfoEventId,
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


        [Event(
            FaultPropagationWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{22}", 
            Keywords = Keywords.FaultPropagation)]
        public void FaultPropagationWarning(
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
                FaultPropagationWarningEventId,
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


        [Event(
            FaultPropagationErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{22}", 
            Keywords = Keywords.FaultPropagation)]
        public void FaultPropagationError(
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
                FaultPropagationErrorEventId,
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

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceVerboseEventId = 60;
        const int WorkflowInstanceInfoEventId = 61;
        const int WorkflowInstanceWarningEventId = 62;
        const int WorkflowInstanceErrorEventId = 63;
        
        [NonEvent]
        public void WorkflowInstance(IStatefulActivityActorInternal actor, WorkflowInstanceRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstance(IStatelessActivityActorInternal actor, WorkflowInstanceRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance))
                {
                    WorkflowInstanceError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{16}", 
            Keywords = Keywords.WorkflowInstance)]
        public void WorkflowInstanceVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string message)
        {
            WriteEvent(
                WorkflowInstanceVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                message);
        }


        [Event(
            WorkflowInstanceInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{16}", 
            Keywords = Keywords.WorkflowInstance)]
        public void WorkflowInstanceInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string message)
        {
            WriteEvent(
                WorkflowInstanceInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                message);
        }


        [Event(
            WorkflowInstanceWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{16}", 
            Keywords = Keywords.WorkflowInstance)]
        public void WorkflowInstanceWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string message)
        {
            WriteEvent(
                WorkflowInstanceWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                message);
        }


        [Event(
            WorkflowInstanceErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{16}", 
            Keywords = Keywords.WorkflowInstance)]
        public void WorkflowInstanceError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string message)
        {
            WriteEvent(
                WorkflowInstanceErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceAbortedVerboseEventId = 70;
        const int WorkflowInstanceAbortedInfoEventId = 71;
        const int WorkflowInstanceAbortedWarningEventId = 72;
        const int WorkflowInstanceAbortedErrorEventId = 73;
        
        [NonEvent]
        public void WorkflowInstanceAborted(IStatefulActivityActorInternal actor, WorkflowInstanceAbortedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstanceAborted(IStatelessActivityActorInternal actor, WorkflowInstanceAbortedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted))
                {
                    WorkflowInstanceAbortedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceAbortedVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted)]
        public void WorkflowInstanceAbortedVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceAbortedVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceAbortedInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted)]
        public void WorkflowInstanceAbortedInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceAbortedInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceAbortedWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted)]
        public void WorkflowInstanceAbortedWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceAbortedWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceAbortedErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceAborted)]
        public void WorkflowInstanceAbortedError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceAbortedErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceSuspendedVerboseEventId = 80;
        const int WorkflowInstanceSuspendedInfoEventId = 81;
        const int WorkflowInstanceSuspendedWarningEventId = 82;
        const int WorkflowInstanceSuspendedErrorEventId = 83;
        
        [NonEvent]
        public void WorkflowInstanceSuspended(IStatefulActivityActorInternal actor, WorkflowInstanceSuspendedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstanceSuspended(IStatelessActivityActorInternal actor, WorkflowInstanceSuspendedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended))
                {
                    WorkflowInstanceSuspendedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceSuspendedVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended)]
        public void WorkflowInstanceSuspendedVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceSuspendedVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceSuspendedInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended)]
        public void WorkflowInstanceSuspendedInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceSuspendedInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceSuspendedWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended)]
        public void WorkflowInstanceSuspendedWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceSuspendedWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceSuspendedErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceSuspended)]
        public void WorkflowInstanceSuspendedError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceSuspendedErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceTerminatedVerboseEventId = 90;
        const int WorkflowInstanceTerminatedInfoEventId = 91;
        const int WorkflowInstanceTerminatedWarningEventId = 92;
        const int WorkflowInstanceTerminatedErrorEventId = 93;
        
        [NonEvent]
        public void WorkflowInstanceTerminated(IStatefulActivityActorInternal actor, WorkflowInstanceTerminatedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstanceTerminated(IStatelessActivityActorInternal actor, WorkflowInstanceTerminatedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated))
                {
                    WorkflowInstanceTerminatedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.Reason) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceTerminatedVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated)]
        public void WorkflowInstanceTerminatedVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceTerminatedVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceTerminatedInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated)]
        public void WorkflowInstanceTerminatedInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceTerminatedInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceTerminatedWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated)]
        public void WorkflowInstanceTerminatedWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceTerminatedWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


        [Event(
            WorkflowInstanceTerminatedErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceTerminated)]
        public void WorkflowInstanceTerminatedError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string reason,
            string message)
        {
            WriteEvent(
                WorkflowInstanceTerminatedErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                reason,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceUnhandledExceptionVerboseEventId = 100;
        const int WorkflowInstanceUnhandledExceptionInfoEventId = 101;
        const int WorkflowInstanceUnhandledExceptionWarningEventId = 102;
        const int WorkflowInstanceUnhandledExceptionErrorEventId = 103;
        
        [NonEvent]
        public void WorkflowInstanceUnhandledException(IStatefulActivityActorInternal actor, WorkflowInstanceUnhandledExceptionRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstanceUnhandledException(IStatelessActivityActorInternal actor, WorkflowInstanceUnhandledExceptionRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException))
                {
                    WorkflowInstanceUnhandledExceptionError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        (record.FaultSource?.Name) ?? string.Empty,
                        (record.FaultSource?.Id) ?? string.Empty,
                        (record.FaultSource?.InstanceId) ?? string.Empty,
                        (record.FaultSource?.TypeName) ?? string.Empty,
                        (record.UnhandledException?.Message) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceUnhandledExceptionVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{21}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException)]
        public void WorkflowInstanceUnhandledExceptionVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string faultSourceName,
            string faultSourceId,
            string faultSourceInstanceId,
            string faultSourceTypeName,
            string exception,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUnhandledExceptionVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                faultSourceName,
                faultSourceId,
                faultSourceInstanceId,
                faultSourceTypeName,
                exception,
                message);
        }


        [Event(
            WorkflowInstanceUnhandledExceptionInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{21}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException)]
        public void WorkflowInstanceUnhandledExceptionInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string faultSourceName,
            string faultSourceId,
            string faultSourceInstanceId,
            string faultSourceTypeName,
            string exception,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUnhandledExceptionInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                faultSourceName,
                faultSourceId,
                faultSourceInstanceId,
                faultSourceTypeName,
                exception,
                message);
        }


        [Event(
            WorkflowInstanceUnhandledExceptionWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{21}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException)]
        public void WorkflowInstanceUnhandledExceptionWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string faultSourceName,
            string faultSourceId,
            string faultSourceInstanceId,
            string faultSourceTypeName,
            string exception,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUnhandledExceptionWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                faultSourceName,
                faultSourceId,
                faultSourceInstanceId,
                faultSourceTypeName,
                exception,
                message);
        }


        [Event(
            WorkflowInstanceUnhandledExceptionErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{21}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUnhandledException)]
        public void WorkflowInstanceUnhandledExceptionError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            string faultSourceName,
            string faultSourceId,
            string faultSourceInstanceId,
            string faultSourceTypeName,
            string exception,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUnhandledExceptionErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                faultSourceName,
                faultSourceId,
                faultSourceInstanceId,
                faultSourceTypeName,
                exception,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int WorkflowInstanceUpdatedVerboseEventId = 110;
        const int WorkflowInstanceUpdatedInfoEventId = 111;
        const int WorkflowInstanceUpdatedWarningEventId = 112;
        const int WorkflowInstanceUpdatedErrorEventId = 113;
        
        [NonEvent]
        public void WorkflowInstanceUpdated(IStatefulActivityActorInternal actor, WorkflowInstanceUpdatedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void WorkflowInstanceUpdated(IStatelessActivityActorInternal actor, WorkflowInstanceUpdatedRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated))
                {
                    WorkflowInstanceUpdatedError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.State) ?? string.Empty,
                        (record.WorkflowDefinitionIdentity?.Name) ?? string.Empty,
                        (record.ActivityDefinitionId) ?? string.Empty,
                        record.IsSuccessful,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            WorkflowInstanceUpdatedVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated)]
        public void WorkflowInstanceUpdatedVerbose(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            bool isSuccessful,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUpdatedVerboseEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                isSuccessful,
                message);
        }


        [Event(
            WorkflowInstanceUpdatedInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated)]
        public void WorkflowInstanceUpdatedInfo(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            bool isSuccessful,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUpdatedInfoEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                isSuccessful,
                message);
        }


        [Event(
            WorkflowInstanceUpdatedWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated)]
        public void WorkflowInstanceUpdatedWarning(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            bool isSuccessful,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUpdatedWarningEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                isSuccessful,
                message);
        }


        [Event(
            WorkflowInstanceUpdatedErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{17}", 
            Keywords = Keywords.WorkflowInstance | Keywords.WorkflowInstanceUpdated)]
        public void WorkflowInstanceUpdatedError(
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
            string workflowDefinitionIdentityName,
            string activityDefinitionId,
            bool isSuccessful,
            string message)
        {
            WriteEvent(
                WorkflowInstanceUpdatedErrorEventId,
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
                workflowDefinitionIdentityName,
                activityDefinitionId,
                isSuccessful,
                message);
        }


    }

    public partial class ActivityActorEventSource
    {

        const int CustomTrackingVerboseEventId = 200;
        const int CustomTrackingInfoEventId = 201;
        const int CustomTrackingWarningEventId = 202;
        const int CustomTrackingErrorEventId = 203;
        
        [NonEvent]
        public void CustomTracking(IStatefulActivityActorInternal actor, CustomTrackingRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.CustomTracking))
                {
                    CustomTrackingVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.CustomTracking))
                {
                    CustomTrackingInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.CustomTracking))
                {
                    CustomTrackingWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.CustomTracking))
                {
                    CustomTrackingError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }

        [NonEvent]
        public void CustomTracking(IStatelessActivityActorInternal actor, CustomTrackingRecord record, string message = "", params object[] args)
        {
            Contract.Requires<ArgumentNullException>(actor != null);
            Contract.Requires<ArgumentNullException>(record != null);
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(args != null);

            if (IsEnabled())
            {
                if (record.Level == TraceLevel.Verbose && IsEnabled(EventLevel.Verbose, Keywords.CustomTracking))
                {
                    CustomTrackingVerbose(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Info && IsEnabled(EventLevel.Informational, Keywords.CustomTracking))
                {
                    CustomTrackingInfo(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Warning && IsEnabled(EventLevel.Warning, Keywords.CustomTracking))
                {
                    CustomTrackingWarning(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

                if (record.Level == TraceLevel.Error && IsEnabled(EventLevel.Error, Keywords.CustomTracking))
                {
                    CustomTrackingError(
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
                        PrepareAnnotations(record.Annotations),
                        (record.Name) ?? string.Empty,
                        (record.Activity?.Name) ?? string.Empty,
                        (record.Activity?.Id) ?? string.Empty,
                        (record.Activity?.InstanceId) ?? string.Empty,
                        (record.Activity?.TypeName) ?? string.Empty,
                        (PrepareDictionary(record.Data)) ?? string.Empty,
                        string.Format(message, args));
                    return;
                }

            }
        }


        [Event(
            CustomTrackingVerboseEventId, 
            Level = EventLevel.Verbose, 
            Message = "{19}", 
            Keywords = Keywords.CustomTracking)]
        public void CustomTrackingVerbose(
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
                CustomTrackingVerboseEventId,
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


        [Event(
            CustomTrackingInfoEventId, 
            Level = EventLevel.Informational, 
            Message = "{19}", 
            Keywords = Keywords.CustomTracking)]
        public void CustomTrackingInfo(
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
                CustomTrackingInfoEventId,
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


        [Event(
            CustomTrackingWarningEventId, 
            Level = EventLevel.Warning, 
            Message = "{19}", 
            Keywords = Keywords.CustomTracking)]
        public void CustomTrackingWarning(
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
                CustomTrackingWarningEventId,
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


        [Event(
            CustomTrackingErrorEventId, 
            Level = EventLevel.Error, 
            Message = "{19}", 
            Keywords = Keywords.CustomTracking)]
        public void CustomTrackingError(
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
                CustomTrackingErrorEventId,
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
