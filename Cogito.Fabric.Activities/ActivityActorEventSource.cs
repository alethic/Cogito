using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Fabric;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cogito.Fabric.Activities
{

    [EventSource(Name = "Cogito-Fabric-Activities")]
    public partial class ActivityActorEventSource :
        EventSource
    {

        const string truncatedItemsTag = "<items>...</items>";
        const string emptyItemsTag = "<items />";
        const string itemsTag = "items";
        const string itemTag = "item";
        const string nameAttribute = "name";
        const string typeAttribute = "type";
        NetDataContractSerializer variableSerializer;

        public static readonly ActivityActorEventSource Current = new ActivityActorEventSource();

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static ActivityActorEventSource()
        {
            Task.Run(() => { }).Wait();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        ActivityActorEventSource()
            : base()
        {

        }

        #region Keywords

        public static class Keywords
        {

            public const EventKeywords ActivityScheduledRecord = (EventKeywords)1;
            public const EventKeywords ActivityStateRecord = (EventKeywords)2;
            public const EventKeywords BookmarkResumptionRecord = (EventKeywords)4;
            public const EventKeywords CancelRequestedRecord = (EventKeywords)8;
            public const EventKeywords FaultPropagationRecord = (EventKeywords)16;
            public const EventKeywords WorkflowInstanceRecord = (EventKeywords)32;
            public const EventKeywords WorkflowInstanceAbortedRecord = (EventKeywords)64;
            public const EventKeywords WorkflowInstanceSuspendedRecord = (EventKeywords)128;
            public const EventKeywords WorkflowInstanceTerminatedRecord = (EventKeywords)256;
            public const EventKeywords WorkflowInstanceUnhandledExceptionRecord = (EventKeywords)512;
            public const EventKeywords WorkflowInstanceUpdatedRecord = (EventKeywords)1024;
            public const EventKeywords CustomTrackingRecord = (EventKeywords)2048;

        }

        #endregion

        const int MessageEventId = 1;
        const int ActorMessageEventId = 2;
        const int ActivityScheduledRecordEventId = 3;
        const int ActivityStateRecordEventId = 4;
        const int BookmarkResumptionRecordEventId = 5;
        const int CancelRequestedRecordEventId = 6;
        const int FaultPropagationRecordEventId = 7;
        const int WorkflowInstanceRecordEventId = 8;
        const int WorkflowInstanceAbortedRecordEventId = 9;
        const int WorkflowInstanceSuspendedRecordEventId = 10;
        const int WorkflowInstanceTerminatedRecordEventId = 11;
        const int WorkflowInstanceUnhandledExceptionRecordEventId = 12;
        const int WorkflowInstanceUpdatedRecordEventId = 13;
        const int CustomTrackingRecordEventId = 14;

        #region Events

        /// <summary>
        /// Records a generic message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        [NonEvent]
        public void Message(string message, params object[] args)
        {
            if (IsEnabled())
                Message(string.Format(message, args));
        }

        /// <summary>
        /// Records a generic message.
        /// </summary>
        /// <param name="message"></param>
        [Event(MessageEventId, Level = EventLevel.Informational, Message = "{0}")]
        public void Message(string message)
        {
            if (IsEnabled())
                WriteEvent(MessageEventId, message);
        }

        /// <summary>
        /// Records a generic message for a <see cref="StatelessActivityActor"/>.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        [NonEvent]
        public void ActorMessage(StatelessActivityActor actor, string message, params object[] args)
        {
            if (IsEnabled())
                ActorMessage(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationTypeName,
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationName,
                    actor.ActorService.ServiceInitializationParameters.ServiceTypeName,
                    actor.ActorService.ServiceInitializationParameters.ServiceName.ToString(),
                    actor.ActorService.ServiceInitializationParameters.PartitionId,
                    actor.ActorService.ServiceInitializationParameters.InstanceId,
                    FabricRuntime.GetNodeContext().NodeName,
                    string.Format(message, args));
        }

        /// <summary>
        /// Records a generic message for a <see cref="StatefulActivityActor"/>.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        [NonEvent]
        public void ActorMessage(StatefulActivityActor actor, string message, params object[] args)
        {
            if (IsEnabled())
                ActorMessage(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationTypeName,
                    actor.ActorService.ServiceInitializationParameters.CodePackageActivationContext.ApplicationName,
                    actor.ActorService.ServiceInitializationParameters.ServiceTypeName,
                    actor.ActorService.ServiceInitializationParameters.ServiceName.ToString(),
                    actor.ActorService.ServiceInitializationParameters.PartitionId,
                    actor.ActorService.ServiceInitializationParameters.ReplicaId,
                    FabricRuntime.GetNodeContext().NodeName,
                    string.Format(message, args));
        }


        /// <summary>
        /// Implementation method for ActorMessage.
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="actorId"></param>
        /// <param name="applicationTypeName"></param>
        /// <param name="applicationName"></param>
        /// <param name="serviceTypeName"></param>
        /// <param name="serviceName"></param>
        /// <param name="partitionId"></param>
        /// <param name="replicaOrInstanceId"></param>
        /// <param name="nodeName"></param>
        /// <param name="message"></param>
        [Event(ActorMessageEventId, Level = EventLevel.Informational, Message = "{9}")]
        void ActorMessage(
            string actorType,
            string actorId,
            string applicationTypeName,
            string applicationName,
            string serviceTypeName,
            string serviceName,
            Guid partitionId,
            long replicaOrInstanceId,
            string nodeName,
            string message)
        {
            WriteEvent(
                ActorMessageEventId,
                actorType,
                actorId,
                applicationTypeName,
                applicationName,
                serviceTypeName,
                serviceName,
                partitionId,
                replicaOrInstanceId,
                nodeName,
                message);
        }

        #endregion

        /// <summary>
        /// Serializes the given dictionary for output.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string PrepareDictionary(IDictionary<string, object> data)
        {
            var builder = new StringBuilder();
            var settings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true
            };

            using (var writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartElement(itemsTag);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        writer.WriteStartElement(itemTag);
                        writer.WriteAttributeString(nameAttribute, item.Key);

                        if (item.Value == null)
                        {
                            writer.WriteAttributeString(typeAttribute, string.Empty);
                            writer.WriteValue(string.Empty);
                        }
                        else
                        {
                            var valueType = item.Value.GetType();
                            writer.WriteAttributeString(typeAttribute, valueType.FullName);

                            if (valueType == typeof(int) ||
                                valueType == typeof(float) ||
                                valueType == typeof(double) ||
                                valueType == typeof(long) ||
                                valueType == typeof(bool) ||
                                valueType == typeof(uint) ||
                                valueType == typeof(ushort) ||
                                valueType == typeof(short) ||
                                valueType == typeof(ulong) ||
                                valueType == typeof(string) ||
                                valueType == typeof(DateTimeOffset))
                            {
                                writer.WriteValue(item.Value);
                            }
                            else if (valueType == typeof(Guid))
                            {
                                writer.WriteValue(item.Value.ToString());
                            }
                            else if (valueType == typeof(DateTime))
                            {
                                writer.WriteValue(((DateTime)item.Value).ToUniversalTime());
                            }
                            else
                            {
                                if (variableSerializer == null)
                                    variableSerializer = new NetDataContractSerializer();

                                try
                                {
                                    variableSerializer.WriteObject(writer, item.Value);
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }

                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.Flush();

                return builder.ToString();
            }
        }

        /// <summary>
        /// Serializes the given annotations for output.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string PrepareAnnotations(IDictionary<string, string> data)
        {
            var stringTypeName = typeof(string).FullName;

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true
            };

            using (var writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartElement(itemsTag);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        writer.WriteStartElement(itemTag);
                        writer.WriteAttributeString(nameAttribute, item.Key);
                        writer.WriteAttributeString(typeAttribute, stringTypeName);
                        writer.WriteValue(item.Value ?? string.Empty);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.Flush();

                return builder.ToString();
            }
        }

    }

}
