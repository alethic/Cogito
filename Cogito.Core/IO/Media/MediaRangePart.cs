using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito.IO.Media
{

    /// <summary>
    /// Represents a media type or subtype in a <see cref="MediaRange"/>.
    /// </summary>
    [Serializable]
    public struct MediaRangePart :
        ISerializable
    {

        /// <summary>
        /// Converts a <see cref="String"/> to a <see cref="MediaRangePart"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator MediaRangePart(string value)
        {
            return new MediaRangePart(value);
        }

        /// <summary>
        /// Converts a <see cref="MediaRangePart"/> to a <see cref="String"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static implicit operator string(MediaRangePart type)
        {
            return type.ToString();
        }


        readonly string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaRangePart"/> class for the media type part.
        /// </summary>
        /// <param name="value"></param>
        MediaRangePart(string value)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));

            this.value = value;
        }

        /// <summary>
        /// Deserializes an instance of <see cref="MediaRangePart"/> class.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public MediaRangePart(SerializationInfo info, StreamingContext context)
            : this(info.GetString("Value"))
        {
            Contract.Requires<ArgumentNullException>(info != null);
        }

        /// <summary>
        /// Gets a value indicating whether the media type is a wildcard or not.
        /// </summary>
        /// <value><see langword="true" /> if the media type is a wildcard, otherwise <see langword="false" />.</value>
        public bool IsWildcard
        {
            get { return value != null && string.Equals(value, "*", StringComparison.Ordinal); }
        }

        /// <summary>
        /// Matched the media type with another media type.
        /// </summary>
        /// <param name="other">The media type that should be matched against.</param>
        /// <returns><see langword="true" /> if the media types match, otherwise <see langword="false" />.</returns>
        public bool Matches(MediaRangePart other)
        {
            return IsWildcard || other.IsWildcard || value.Equals(other.value, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object other)
        {
            return other is MediaRangePart ? Matches((MediaRangePart)other) : false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", value);
        }

    }

}