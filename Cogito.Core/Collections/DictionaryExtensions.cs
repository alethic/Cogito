using System;
using System.Collections.Generic;

namespace Cogito.Collections
{

    public static class DictionaryExtensions
    {

        /// <summary>
        /// Gets the value for the specified key, or the default value of the type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            TValue v;
            return source.TryGetValue(key, out v) ? v : default(TValue);
        }

        /// <summary>
        /// Gets the value for the specified key or creates it.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> create)
        {
            TValue v;
            return source.TryGetValue(key, out v) ? v : source[key] = create(key);
        }

    }

}
