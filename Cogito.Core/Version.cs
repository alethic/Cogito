using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito
{

    /// <summary>
    /// Represents a version.
    /// </summary>
    public abstract class Version : ICloneable, IComparable, IComparable<Version>, IEquatable<Version>
    {

        public static bool operator >(Version version1, Version version2)
        {
            Contract.Requires<ArgumentNullException>(version1 != null);
            Contract.Requires<ArgumentNullException>(version2 != null);
            return version1.CompareTo(version2) == 1;
        }

        public static bool operator >=(Version version1, Version version2)
        {
            Contract.Requires<ArgumentNullException>(version1 != null);
            Contract.Requires<ArgumentNullException>(version2 != null);
            return version1.CompareTo(version2) >= 0;
        }

        public static bool operator <(Version version1, Version version2)
        {
            Contract.Requires<ArgumentNullException>(version1 != null);
            Contract.Requires<ArgumentNullException>(version2 != null);
            return version1.CompareTo(version2) == -1;
        }

        public static bool operator <=(Version version1, Version version2)
        {
            Contract.Requires<ArgumentNullException>(version1 != null);
            Contract.Requires<ArgumentNullException>(version2 != null);
            return version1.CompareTo(version2) <= 0;
        }

        public static bool operator ==(Version version1, Version version2)
        {
            return EqualityComparer<Version>.Default.Equals(version1, version2);
        }

        public static bool operator !=(Version version1, Version version2)
        {
            return !EqualityComparer<Version>.Default.Equals(version1, version2);
        }

        /// <summary>
        /// Creates a clone of this <see cref="Version"/> object.
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return (Version)Activator.CreateInstance(GetType(), new object[] { ToVersionString() });
        }

        /// <summary>
        /// Compares this <see cref="Version"/> with another <see cref="Object"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(object other)
        {
            return StringComparer.InvariantCulture.Compare(ToVersionString(), other != null ? other.ToString() : null);
        }

        /// <summary>
        /// Compares this <see cref="Version"/> with another <see cref="Version"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(Version other)
        {
            return StringComparer.InvariantCulture.Compare(ToVersionString(), other != null ? other.ToVersionString() : null);
        }

        /// <summary>
        /// Compares this <see cref="Version"/> with another object for equality.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Version;
            if (other == null)
                return false;

            return Equals(other);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="Version"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToVersionString().GetHashCode();
        }

        /// <summary>
        /// Compares this <see cref="Version"/> with another <see cref="Version"/> for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(Version other)
        {
            if (object.ReferenceEquals(this, other))
                return true;

            if (object.ReferenceEquals(other, null))
                return false;

            return ToVersionString() == other.ToVersionString();
        }

        /// <summary>
        /// Returns a string representation of the <see cref="Version"/>.
        /// </summary>
        /// <returns></returns>
        public abstract string ToVersionString();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToVersionString();
        }

    }

}
