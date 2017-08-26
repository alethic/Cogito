using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cogito.Collections
{

    /// <summary>
    /// <see cref="IDictionary"/> implementation which creates elements on demand if they do not yet exist.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DemandDictionary<TKey, TValue> :
        IDictionary<TKey, TValue>
    {

        /// <summary>
        /// Implements a TryFunc around a plain Func.
        /// </summary>
        /// <param name="getter"></param>
        /// <returns></returns>
        static TryFunc<TKey, TValue> TryFuncFunc(Func<TKey, TValue> getter)
        {
            return (TryFunc<TKey, TValue>)((TKey k, out TValue v) =>
            {
                v = getter(k);
                return true;
            });
        }

        readonly IDictionary<TKey, TValue> cache;
        readonly TryFunc<TKey, TValue> getter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DemandDictionary(TryFunc<TKey, TValue> getter, IDictionary<TKey, TValue> cache)
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));

            this.getter = getter;
            this.cache = cache;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DemandDictionary(Func<TKey, TValue> getter, IDictionary<TKey, TValue> cache)
            : this(TryFuncFunc(getter), cache)
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="getter"></param>
        /// <param name="threadSafe"></param>
        public DemandDictionary(TryFunc<TKey, TValue> getter, bool threadSafe)
            : this(getter, threadSafe ? (IDictionary<TKey, TValue>)new ConcurrentDictionary<TKey, TValue>() : new Dictionary<TKey, TValue>())
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="getter"></param>
        /// <param name="threadSafe"></param>
        public DemandDictionary(Func<TKey, TValue> getter, bool threadSafe)
            : this(TryFuncFunc(getter), threadSafe)
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="getter"></param>
        public DemandDictionary(TryFunc<TKey, TValue> getter)
            : this(getter, false)
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="getter"></param>
        public DemandDictionary(Func<TKey, TValue> getter)
            : this(TryFuncFunc(getter), false)
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
        }

        /// <summary>
        /// Executes the getter, caching the result.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryFuncExec(TKey key, out TValue value)
        {
            if (getter(key, out value))
            {
                cache.Add(key, value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes the getter, caching the result, and returning the result, or throwing an exception if no result
        /// can be got.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue TryFuncExec(TKey key)
        {
            TValue value;
            if (TryFuncExec(key, out value))
                return value;

            throw new IndexOutOfRangeException();
        }

        public void Add(TKey key, TValue value)
        {
            cache.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return cache.ContainsKey(key) || TryFuncExec(key, out value);
        }

        public ICollection<TKey> Keys
        {
            get { return cache.Keys; }
        }

        public bool Remove(TKey key)
        {
            return cache.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return TryFuncExec(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return cache.Values; }
        }

        public TValue this[TKey key]
        {
            get { return cache.ContainsKey(key) ? cache[key] : TryFuncExec(key); }
            set { cache[key] = value; }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            cache.Add(item);
        }

        public void Clear()
        {
            cache.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            // cache contains it; or we successfully created it, and then cache contained it
            TValue value;
            return cache.Contains(item) || TryFuncExec(item.Key, out value) && cache.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            cache.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return cache.Count; }
        }

        public bool IsReadOnly
        {
            get { return cache.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return cache.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return cache.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)cache).GetEnumerator();
        }

    }

}
