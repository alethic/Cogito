using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;

namespace Cogito.Composition.Hosting
{

    public sealed class ExportProviderCollection : ICollection<ExportProvider>, INotifyCollectionChanged
    {

        ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
        List<ExportProvider> providers = new List<ExportProvider>();

        public void Add(ExportProvider item)
        {
            providers.Add(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void AddRange(IEnumerable<ExportProvider> items)
        {
            Contract.Requires<ArgumentNullException>(items != null);

            var all = items.ToList();

            providers.AddRange(all);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, all));
        }

        public void Clear()
        {
            List<ExportProvider> all;

            all = providers.ToList();
            providers.Clear();

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, all));
        }

        public bool Contains(ExportProvider item)
        {
            return providers.Contains(item);
        }

        public void CopyTo(ExportProvider[] array, int arrayIndex)
        {
            providers.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { lock (providers) return providers.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; ; }
        }

        public bool Remove(ExportProvider item)
        {
            var b = providers.Remove(item);
            if (b)
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));

            return b;
        }

        public IEnumerator<ExportProvider> GetEnumerator()
        {
            return providers.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, args);
        }

    }

}
