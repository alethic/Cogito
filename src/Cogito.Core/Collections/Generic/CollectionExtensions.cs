#if NETFRAMEWORK

using System;
using System.Collections.Generic;

namespace Cogito.Collections.Generic
{

    /// <summary>
    /// Provides the members of System.Collections.Generic.CollectionExtensions that .NET Framework lacks.
    /// </summary>
    public static class CollectionExtensions
    {

        /// <summary>
        /// Gets the value for the specified key, or the default value of the type. On .NET, use
        /// System.Collections.Generic.CollectionExtensions.GetValueOrDefault itself; importing both
        /// namespaces resolves to the right one on each.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.GetValueOrDefault(key, default(TValue));
        }

        /// <summary>
        /// Gets the value for the specified key, or <paramref name="defaultValue"/>. On .NET, use
        /// System.Collections.Generic.CollectionExtensions.GetValueOrDefault itself; importing both
        /// namespaces resolves to the right one on each.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

    }

}

#else

namespace Cogito.Collections.Generic
{

    /// <summary>
    /// Keeps this namespace present on .NET, where System.Collections.Generic provides its members, so that a
    /// <c>using Cogito.Collections.Generic;</c> written for .NET Framework still compiles.
    /// </summary>
    static class NamespaceAnchor
    {

    }

}

#endif
