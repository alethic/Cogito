using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;

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
            Contract.Requires<ArgumentNullException>(key != null);

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
            Contract.Requires<ArgumentNullException>(key != null);

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

        /// <summary>
        /// Converts the <see cref="IEnumerable{TKey,TValue}"/> to a <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TElement> ToDictionary<TKey, TElement>(this IEnumerable<KeyValuePair<TKey, TElement>> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return source.ToDictionary(i => i.Key, i => i.Value);
        }

        /// <summary>
        /// Transforms the given dictionary of strings to a <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            var c = new NameValueCollection();

            // add items to collection
            foreach (var i in source)
                c.Add(i.Key, i.Value);

            return c;
        }

    }

}
