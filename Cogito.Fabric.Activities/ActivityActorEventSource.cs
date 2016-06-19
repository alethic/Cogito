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

    /// <summary>
    /// Logs events for the Activity Actor framework.
    /// </summary>
    [EventSource(Name = "Cogito-Fabric-Activities")]
    partial class ActivityActorEventSource :
        EventSource
    {

        const string ITEMS_ELEMENT = "items";
        const string ITEM_ELEMENT = "item";
        const string NAME_ATTRIBUTE = "name";
        const string TYPE_ATTRIBUTE = "type";

        public static readonly ActivityActorEventSource Current = new ActivityActorEventSource();

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static ActivityActorEventSource()
        {
            Task.Run(() => { }).Wait();
        }

        readonly NetDataContractSerializer variableSerializer = new NetDataContractSerializer();

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

            public const EventKeywords ActivityScheduled = (EventKeywords)1;
            public const EventKeywords ActivityState = (EventKeywords)2;
            public const EventKeywords BookmarkResumption = (EventKeywords)4;
            public const EventKeywords CancelRequested = (EventKeywords)8;
            public const EventKeywords FaultPropagation = (EventKeywords)16;
            public const EventKeywords WorkflowInstance = (EventKeywords)32;
            public const EventKeywords WorkflowInstanceAborted = (EventKeywords)64;
            public const EventKeywords WorkflowInstanceSuspended = (EventKeywords)128;
            public const EventKeywords WorkflowInstanceTerminated = (EventKeywords)256;
            public const EventKeywords WorkflowInstanceUnhandledException = (EventKeywords)512;
            public const EventKeywords WorkflowInstanceUpdated = (EventKeywords)1024;
            public const EventKeywords CustomTracking = (EventKeywords)2048;

        }

        #endregion

        const int MessageEventId = 1;
        const int ActorMessageEventId = 2;

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
        /// Records a generic message for a <see cref="ActivityActor"/>.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        [NonEvent]
        public void ActorMessage(ActivityActor actor, string message, params object[] args)
        {
            if (IsEnabled())
                ActorMessage(
                    actor.GetType().ToString(),
                    actor.Id.ToString(),
                    actor.ActorService.Context.CodePackageActivationContext.ApplicationTypeName,
                    actor.ActorService.Context.CodePackageActivationContext.ApplicationName,
                    actor.ActorService.Context.ServiceTypeName,
                    actor.ActorService.Context.ServiceName.ToString(),
                    actor.ActorService.Context.PartitionId,
                    actor.ActorService.Context.ReplicaId,
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

            using (var writer = XmlWriter.Create(builder, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                writer.WriteStartElement(ITEMS_ELEMENT);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        writer.WriteStartElement(ITEM_ELEMENT);
                        writer.WriteAttributeString(NAME_ATTRIBUTE, item.Key);

                        if (item.Value == null)
                        {
                            writer.WriteAttributeString(TYPE_ATTRIBUTE, string.Empty);
                            writer.WriteValue(string.Empty);
                        }
                        else
                        {
                            var valueType = item.Value.GetType();
                            writer.WriteAttributeString(TYPE_ATTRIBUTE, valueType.FullName);

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
            }

            return builder.ToString();
        }

        /// <summary>
        /// Serializes the given annotations for output.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string PrepareAnnotations(IDictionary<string, string> data)
        {
            var builder = new StringBuilder();

            using (var writer = XmlWriter.Create(builder, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                writer.WriteStartElement(ITEMS_ELEMENT);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        writer.WriteStartElement(ITEM_ELEMENT);
                        writer.WriteAttributeString(NAME_ATTRIBUTE, item.Key);
                        writer.WriteAttributeString(TYPE_ATTRIBUTE, typeof(string).FullName);
                        writer.WriteValue(item.Value ?? string.Empty);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.Flush();
            }

            return builder.ToString();
        }

    }

}
