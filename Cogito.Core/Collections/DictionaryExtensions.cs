using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Collections
{

    public static class DictionaryExtensions
    {

        /// <summary>
        /// Gets the value for the specified key, or the default value of the type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            TValue v;
            return self.TryGetValue(key, out v) ? v : default(TValue);
        }

        /// <summary>
        /// Gets the value for the specified key, or the default value of the type.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetOrDefault(this IDictionary self, object key)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            return self.Contains(key) ? self[key] : null;
        }

        /// <summary>
        /// Gets the value for the specified key or creates it.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, Func<TKey, TValue> create)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            // ConcurrentDictionary provides it's own thread-safe version
            if (self is ConcurrentDictionary<TKey, TValue>)
                return ((ConcurrentDictionary<TKey, TValue>)self).GetOrAdd(key, create);

            TValue v;
            return self.TryGetValue(key, out v) ? v : self[key] = create(key);
        }

        /// <summary>
        /// Returns a <see cref="IDictionary"/> implementation which merges the first dictionary with the second.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> second)
        {
            return new MergedDictionary<TKey, TValue>(source, second);
        }

    }

}
