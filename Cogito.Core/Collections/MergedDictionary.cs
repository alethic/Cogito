using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Collections
{

    /// <summary>
    /// A collection of keys and values which overlaps an existing <see cref="IDictionary"/>.
    /// </summary>
    public class MergedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {

        IDictionary<TKey, TValue> prev;
        IDictionary<TKey, TValue> self;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="prev"></param>
        public MergedDictionary(IDictionary<TKey, TValue> prev)
            : this(prev, null)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="prev"></param>
        public MergedDictionary(IDictionary<TKey, TValue> prev, IDictionary<TKey, TValue> self)
        {
            this.prev = prev ?? new Dictionary<TKey, TValue>();
            this.self = self ?? new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            self.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return self.ContainsKey(key) || prev.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return self.Keys.Concat(prev.Keys).ToList(); }
        }

        public bool Remove(TKey key)
        {
            return self.Remove(key) | prev.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return self.TryGetValue(key, out value) || prev.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return self.Values.Concat(prev.Values).ToList(); }
        }

        public TValue this[TKey key]
        {
            get { return self.ContainsKey(key) ? self[key] : prev.ContainsKey(key) ? prev[key] : default(TValue); }
            set { self[key] = value; }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            self.Add(item);
        }

        public void Clear()
        {
            self.Clear();
            prev.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return self.Contains(item) || prev.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            self.CopyTo(array, arrayIndex);
            prev.CopyTo(array, arrayIndex + Count);
        }

        public int Count
        {
            get { return self.Count + prev.Count; }
        }

        public bool IsReadOnly
        {
            get { return self.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return self.Remove(item) | prev.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return self.Concat(prev).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
