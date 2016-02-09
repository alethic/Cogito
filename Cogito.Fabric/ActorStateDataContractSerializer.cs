using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric
{

    /// <summary>
    /// Provides methods for serializing actor state.
    /// </summary>
    public class ActorStateDataContractSerializer
    {

        readonly DataContractSerializer serializer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="actorStateType"></param>
        internal ActorStateDataContractSerializer(Type actorStateType)
        {
            Contract.Requires<ArgumentNullException>(actorStateType != null);

            serializer = new DataContractSerializer(actorStateType, new DataContractSerializerSettings()
            {
                MaxItemsInObjectGraph = int.MaxValue,
                DataContractSurrogate = ActorDataContractSurrogate.Instance,
                KnownTypes = new[] { typeof(ActorReference) }
            });
        }

        /// <summary>
        /// Deserializes the actor state from the specified buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] buffer)
        {
            Contract.Requires<ArgumentNullException>(buffer != null);

            using (var stream = new MemoryStream(buffer))
                return Deserialize<T>(stream);
        }

        /// <summary>
        /// Deserializes the actor state from the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream != null);

            using (var reader = XmlReader.Create(stream))
                return Deserialize<T>(reader);
        }

        /// <summary>
        /// Deserializes the actor state from the specified <see cref="XmlReader"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public T Deserialize<T>(XmlReader reader)
        {
            Contract.Requires<ArgumentNullException>(reader != null);

            return (T)serializer.ReadObject(reader);
        }

        /// <summary>
        /// Serializes the actor state to the specified buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>
        public byte[] Serialize<T>(T state)
        {
            Contract.Requires<ArgumentNullException>(state != null);

            using (var srm = new MemoryStream())
            {
                Serialize<T>(state, srm);
                return srm.ToArray();
            }
        }

        /// <summary>
        /// Serializes the actor state to the specified <see cref="Stream"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="state"></param>
        /// <param name="stream"></param>
        public void Serialize<T>(T state, Stream stream)
        {
            Contract.Requires<ArgumentNullException>(state != null);
            Contract.Requires<ArgumentNullException>(stream != null);

            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true, CloseOutput = false }))
                Serialize<T>(state, writer);
        }

        /// <summary>
        /// Serializes the actor state to the specified <see cref="XmlWriter"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="state"></param>
        /// <param name="writer"></param>
        public void Serialize<T>(T state, XmlWriter writer)
        {
            Contract.Requires<ArgumentNullException>(state != null);
            Contract.Requires<ArgumentNullException>(writer != null);

            serializer.WriteObject(writer, state);
            writer.Flush();
        }

    }

}
