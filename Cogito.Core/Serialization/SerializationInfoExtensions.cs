using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cogito.Serialization
{

    /// <summary>
    /// Provides various extension methods for working with <see cref="SerializationInfo"/> instances.
    /// </summary>
    public static class SerializationInfoExtensions
    {

        /// <summary>
        /// Gets the value from the serialization info and casts it to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetValue<T>(this SerializationInfo info, string name)
        {
            Contract.Requires<ArgumentNullException>(info != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return (T)info.GetValue(name, typeof(T));
        }

    }

}
