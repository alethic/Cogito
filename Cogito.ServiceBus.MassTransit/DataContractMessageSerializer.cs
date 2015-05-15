using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

using MassTransit;
using MassTransit.Serialization;
using MassTransit.Serialization.Custom;

namespace Cogito.ServiceBus.MassTransit
{

    public class DataContractMessageSerializer :
        IMessageSerializer
    {

        const string ContentTypeHeaderValue = "application/vnd.masstransit+xml+datacontract";
        static readonly XNamespace EnvelopeNamespace = "http://schemas.cogito.cx/Cogito.ServiceBus.MassTransit";


        /// <summary>
        /// Gets the serializer content type.
        /// </summary>
        public string ContentType
        {
            get { return ContentTypeHeaderValue; }
        }

        /// <summary>
        /// Writes the <see cref="Envelope"/> to the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="envelope"></param>
        void WriteEnvelope(Stream stream, global::MassTransit.Serialization.Envelope envelope)
        {
            Contract.Requires<ArgumentNullException>(stream != null);
            Contract.Requires<ArgumentNullException>(envelope != null);

            // write XML to stream
            using (var wrt1 = new NonClosingStream(stream))
            {
                // create internal Envelope implementation
                var obj = new Envelope();
                obj.ConversationId = envelope.ConversationId;
                obj.CorrelationId = envelope.CorrelationId;
                obj.DestinationAddress = envelope.DestinationAddress;
                obj.ExpirationTime = envelope.ExpirationTime;
                obj.FaultAddress = envelope.FaultAddress;
                obj.Headers = new EnvelopeHeaderDictionary(envelope.Headers);
                obj.Message = envelope.Message;
                obj.MessageId = envelope.MessageId;
                obj.MessageType = new EnvelopeMessageTypeList(envelope.MessageType);
                obj.Network = envelope.Network;
                obj.RequestId = envelope.RequestId;
                obj.ResponseAddress = envelope.ResponseAddress;
                obj.RetryCount = envelope.RetryCount;
                obj.SourceAddress = envelope.SourceAddress;

                // message type must be stored and loaded
                var knownType = envelope.Message.GetType();

                // serialize to XML
                var xml = new XDocument();
                using (var wrt = xml.CreateWriter())
                    new DataContractSerializer(typeof(Envelope), new[] { knownType }).WriteObject(wrt, obj);

                // set known type
                xml.Root.SetAttributeValue(EnvelopeNamespace + "KnownType", knownType.FullName + ", " + knownType.Assembly.GetName().Name);

                // output
                xml.Save(wrt1);
            }
        }

        /// <summary>
        /// Reads the <see cref="Envelope"/> from the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        global::MassTransit.Serialization.Envelope ReadEnvelope(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null);

            using (var rdr = XmlReader.Create(stream))
            {
                // obtain known type and remove attribute
                var xml = XDocument.Load(rdr);
                var atr = xml.Root.Attribute(EnvelopeNamespace + "KnownType");
                var type = Type.GetType((string)atr);
                atr.Remove();

                // dump to stream, XDocument CreateReader is buggy
                var stm = new MemoryStream();
                xml.Save(stm);
                stm.Position = 0;

                // deserialize and convert to MassTransit envelope type
                var obj = (Envelope)new DataContractSerializer(typeof(Envelope), new[] { type }).ReadObject(XmlReader.Create(stm));
                var envelope = (global::MassTransit.Serialization.Envelope)Activator.CreateInstance(typeof(global::MassTransit.Serialization.Envelope), true);
                envelope.ConversationId = obj.ConversationId;
                envelope.CorrelationId = obj.CorrelationId;
                envelope.DestinationAddress = obj.DestinationAddress;
                envelope.ExpirationTime = obj.ExpirationTime;
                envelope.FaultAddress = obj.FaultAddress;
                envelope.Headers = obj.Headers;
                envelope.Message = obj.Message;
                envelope.MessageId = obj.MessageId;
                envelope.MessageType = obj.MessageType;
                envelope.Network = obj.Network;
                envelope.RequestId = obj.RequestId;
                envelope.ResponseAddress = obj.ResponseAddress;
                envelope.RetryCount = obj.RetryCount;
                envelope.SourceAddress = obj.SourceAddress;
                return envelope;
            }
        }

        public void Serialize<T>(Stream output, global::MassTransit.ISendContext<T> context)
            where T : class
        {
            try
            {
                context.SetContentType(ContentTypeHeaderValue);
                WriteEnvelope(output, global::MassTransit.Serialization.Envelope.Create(context));
            }
            catch (SerializationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SerializationException("Failed to serialize message", ex);
            }
        }

        public void Deserialize(IReceiveContext context)
        {
            try
            {
                context.SetUsingEnvelope(ReadEnvelope(context.BodyStream));
            }
            catch (SerializationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SerializationException("Failed to deserialize message", ex);
            }
        }

    }

}