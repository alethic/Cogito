using System;
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
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return (T)info.GetValue(name, typeof(T));
        }

    }

}
