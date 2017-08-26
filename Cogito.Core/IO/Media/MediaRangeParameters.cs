using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.IO.Media
{

    /// <summary>
    /// Provides strongly-typed access to media range parameters.
    /// </summary>
    public class MediaRangeParameters :
        IEnumerable<KeyValuePair<string, string>>
    {

        /// <summary>
        /// Creates a <see cref="MediaRangeParameters"/> collection from a "a=1,b=2" string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static MediaRangeParameters Parse(string parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            return new MediaRangeParameters(parameters
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split('='))
                .ToDictionary(split => split[0].Trim(), split => split[1].Trim()));
        }

        public static implicit operator string(MediaRangeParameters mediaRangeParameters)
        {
            return mediaRangeParameters != null ? mediaRangeParameters.ToString() : null;
        }

        public static implicit operator MediaRangeParameters(string parameters)
        {
            return parameters != null ? Parse(parameters) : null;
        }


        readonly IDictionary<string, string> parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaRangeParameters"/> class.
        /// </summary>
        internal MediaRangeParameters()
        {
            this.parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaRangeParameters"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        internal MediaRangeParameters(IDictionary<string, string> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            this.parameters = new Dictionary<string, string>(parameters, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the names of the available parameters.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> containing the names of the parameters.</value>
        public IEnumerable<string> Keys
        {
            get { return parameters.Keys; }
        }

        /// <summary>
        /// Gets all the parameters values.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> that contains all the parameters values.</value>
        public IEnumerable<string> Values
        {
            get { return parameters.Values; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return parameters.GetEnumerator();
        }

        /// <summary>
        /// Whether or not a set of media range parameters matches another, regardless of order
        /// </summary>
        /// <param name="other">Other media range parameters</param>
        /// <returns>True if matching, false if not</returns>
        public bool Matches(MediaRangeParameters other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return parameters.OrderBy(p => p.Key).SequenceEqual(other.parameters.OrderBy(p => p.Key));
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the value for the parameter identified by the <paramref name="name"/> parameter.
        /// </summary>
        /// <param name="name">The name of the parameter to return the value for.</param>
        /// <returns>The value for the parameter. If the parameter is not defined then null is returned.</returns>
        public string this[string name]
        {
            get { if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name)); return (parameters.ContainsKey(name)) ? parameters[name] : null; }
        }

        /// <summary>
        /// Returns a string representation of this <see cref="MediaRangeParameters"/> set.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(";", parameters.Select(p => p.Key + "=" + p.Value));
        }

        /// <summary>
        /// Returns <c>true</c> if this parameter set matches the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as MediaRangeParameters;
            if (other == null)
                return false;

            return Matches(other);
        }

        /// <summary>
        /// Returns a hascode representation of this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return parameters.OrderBy(p => p.Key).Aggregate(0, (i, j) => i ^ j.Key.GetHashCode() ^ j.Value.GetHashCode());
        }

    }

}