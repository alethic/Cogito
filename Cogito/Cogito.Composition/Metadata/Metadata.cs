using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Base <see cref="IMetadata"/> implementation.
    /// </summary>
    public abstract class Metadata : IMetadata
    {

        IQueryable<IMetadataItem> defaultQueryable;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Metadata()
        {
            defaultQueryable = new EnumerableQuery<IMetadataItem>(this);
        }

        public abstract IEnumerator<IMetadataItem> GetEnumerator();

        #region IEnumerable

        IEnumerator<IMetadataItem> IEnumerable<IMetadataItem>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IQueryable

        public Type ElementType
        {
            get { return typeof(IMetadataItem); }
        }

        public virtual Expression Expression
        {
            get { return defaultQueryable.Expression; }
        }

        public virtual IQueryProvider Provider
        {
            get { return defaultQueryable.Provider; }
        }

        #endregion

        #region IDictionary

        void IDictionary<string, object>.Add(string key, object value)
        {
            throw new NotSupportedException();
        }

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return this.Any(i => i.Key == key);
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return new ReadOnlyCollection<string>(this.Select(i => i.Key).ToList()); }
        }

        bool IDictionary<string, object>.Remove(string key)
        {
            throw new NotSupportedException();
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return (value = this.Where(i => i.Key == key).Select(i => i.Value).FirstOrDefault()) != null;
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { return new ReadOnlyCollection<object>(this.Select(i => i.Value).ToList()); }
        }

        object IDictionary<string, object>.this[string key]
        {
            get { return this.Where(i => i.Key == key).Select(i => i.Value).FirstOrDefault(); }
            set { throw new NotSupportedException(); }
        }

        #endregion

        #region ICollection

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return this.Any(i => i.Key == item.Key && i.Value == item.Value);
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((IEnumerable<KeyValuePair<string, object>>)this).ToArray().CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return this.Count(); }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return this.Select(i => new KeyValuePair<string, object>(i.Key, i.Value)).GetEnumerator();
        }

        #endregion

    }

}
