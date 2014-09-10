using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cogito.Collections
{

    /// <summary>
    /// Dictionary implementation that wraps two other dictionaries.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MergedDictionary<TKey, TValue> :
        IDictionary<TKey, TValue>
    {

        readonly IDictionary<TKey, TValue> first;
        readonly IDictionary<TKey, TValue> second;
        readonly IDictionary<TKey, TValue> self;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public MergedDictionary(IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            this.first = first;
            this.second = second;
            this.self = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            self.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return
                self.ContainsKey(key) ||
                second.ContainsKey(key) ||
                first.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return new ReadOnlyCollection<TKey>(self.Select(i => i.Key).ToList()); }
        }

        public bool Remove(TKey key)
        {
            if (self.Remove(key) | second.Remove(key) | first.Remove(key))
                return true;

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (self.TryGetValue(key, out value))
                return true;
            if (second.TryGetValue(key, out value))
                return true;
            if (first.TryGetValue(key, out value))
                return true;

            return false;
        }

        public ICollection<TValue> Values
        {
            get { return new ReadOnlyCollection<TValue>(self.Select(i => i.Value).ToList()); }
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue k;
                if (!TryGetValue(key, out k))
                    throw new KeyNotFoundException();

                return default(TValue);
            }
            set
            {
                self[key] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            self.Add(item);
        }

        public void Clear()
        {
            self.Clear();
            second.Clear();
            first.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return self.Contains(item) || second.Contains(item) || first.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this.ToArray().CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; ; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return self.Remove(item) | second.Remove(item) | first.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return self.Concat(second).Concat(first)
                .GroupBy(i => i.Key)
                .Select(i => i.First())
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
