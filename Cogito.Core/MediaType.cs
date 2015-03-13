using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito
{

    /// <summary>
    /// RFC 6648 media type.
    /// </summary>
    [Serializable]
    public class MediaType :
        IEquatable<MediaType>,
        ISerializable
    {

        /// <summary>
        /// Converts a <see cref="MediaType"/> to a <see cref="String"/>.
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static implicit operator string(MediaType mediaType)
        {
            Contract.Requires<ArgumentNullException>(mediaType != null);

            return mediaType.ToString();
        }

        /// <summary>
        /// Converts a <see cref="String"/> to a <see cref="MediaType"/>.
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static implicit operator MediaType(string mediaType)
        {
            Contract.Requires<ArgumentNullException>(mediaType != null);

            return new MediaType(mediaType);
        }

        /// <summary>
        /// Parses the RFC 6648 media type into a new <see cref="MediaType"/> value.
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static MediaType Parse(string mediaType)
        {
            Contract.Requires<ArgumentNullException>(mediaType != null);

            return new MediaType(mediaType);
        }

        readonly string type;
        readonly string subtype;

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        void ObjectInvariant()
        {
            Contract.Invariant(!string.IsNullOrWhiteSpace(type));
            Contract.Invariant(!string.IsNullOrWhiteSpace(subtype));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public MediaType(string value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(value));
            Contract.Requires<FormatException>(value.Split(new[] { '/' }).Length == 2);

            // parse into components
            var a = value.Split(new[] { '/' });
            if (a.Length != 2)
                throw new FormatException();

            type = a[0];
            subtype = a[1];
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public MediaType(SerializationInfo info, StreamingContext context)
            : this(info.GetString("MediaType"))
        {
            Contract.Requires<ArgumentNullException>(info != null);
        }

        /// <summary>
        /// Gets the type component.
        /// </summary>
        public string Type
        {
            get { return type; }
        }

        /// <summary>
        /// Gets the subtype component.
        /// </summary>
        public string Subtype
        {
            get { return subtype; }
        }

        /// <summary>
        /// Determines whether this instance or another specified instance are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MediaType other)
        {
            return
                object.Equals(type, other.type) &&
                object.Equals(subtype, other.subtype);
        }

        public override string ToString()
        {
            return type + "/" + subtype;
        }

        /// <summary>
        /// Determines whether this instance or another specified instance are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Equals((MediaType)obj);
        }

        public override int GetHashCode()
        {
            return type.GetHashCode() ^ subtype.GetHashCode();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MediaType", ToString());
        }

    }

}
