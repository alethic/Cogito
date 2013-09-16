using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Linq;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides a collection of imports with various notifications to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(DynamicImportCollection<,>))]
    [Export(typeof(IImportCollection<,>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DynamicImportCollection<T, TMetadata> :
        IImportCollection<T, TMetadata>
    {

        IEnumerable<Lazy<T, TMetadata>> imports;
        bool disposed;
        event ImportCollectionChangedEventHandler<T, TMetadata> importsChanged;
        event ImportCollectionChangedEventHandler<T> importsChanged2;

        [ImportingConstructor]
        public DynamicImportCollection()
        {

        }

        /// <summary>
        /// Property into which the container injects values.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<T, TMetadata>> Imports
        {
            get { return imports; }
            set { var t = imports; imports = value; OnChanged(imports, t); }
        }

        /// <summary>
        /// Raises all the appropriate events.
        /// </summary>
        void OnChanged(IEnumerable<Lazy<T, TMetadata>> newItems, IEnumerable<Lazy<T, TMetadata>> oldItems)
        {
            var n = newItems.EmptyIfNull<Lazy<T, TMetadata>>();
            var o = oldItems.EmptyIfNull<Lazy<T, TMetadata>>();

            var a = n.Except(o); // added
            var r = o.Except(n); // removed

            RaiseComposed(a, r);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, r));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, a));
        }

        /// <summary>
        /// Raised when the imports change.
        /// </summary>
        public event ImportCollectionChangedEventHandler<T, TMetadata> ImportsChanged
        {
            add { importsChanged += value; }
            remove { importsChanged -= value; }
        }

        /// <summary>
        /// Raised when the imports change.
        /// </summary>
        event ImportCollectionChangedEventHandler<T> IImportCollection<T>.ImportsChanged
        {
            add { importsChanged2 += value; }
            remove { importsChanged2 -= value; }
        }

        /// <summary>
        /// Raises the ImportsChanged event.
        /// </summary>
        /// <param name="newItems"></param>
        /// <param name="oldItems"></param>
        protected virtual void RaiseComposed(IEnumerable<Lazy<T, TMetadata>> newItems, IEnumerable<Lazy<T, TMetadata>> oldItems)
        {
            Contract.Requires<ArgumentNullException>(newItems != null);
            Contract.Requires<ArgumentNullException>(oldItems != null);

            OnImportsChanged(new ImportCollectionChangedEventArgs<T, TMetadata>(newItems, oldItems));
        }

        /// <summary>
        /// Raises the ImportsChanged event.
        /// </summary>
        protected void OnImportsChanged(ImportCollectionChangedEventArgs<T, TMetadata> args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            if (importsChanged != null)
                importsChanged(this, args);
            if (importsChanged2 != null)
                importsChanged2(this, args);
        }

        /// <summary>
        /// Raised when the imports are changed.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Raises the CollectionChanged event.
        /// </summary>
        void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            if (CollectionChanged != null)
                CollectionChanged(this, args);
        }

        public IImportValueCollection<T> Values
        {
            get { return this; }
        }

        IEnumerator<ILazy<T, TMetadata>> IEnumerable<ILazy<T, TMetadata>>.GetEnumerator()
        {
            return Imports.Select(i => new Internal.Lazy<T, TMetadata>(i)).GetEnumerator();
        }

        IEnumerator<ILazy<T>> IEnumerable<ILazy<T>>.GetEnumerator()
        {
            return Imports.Select(i => new Internal.Lazy<T, TMetadata>(i)).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Imports.Select(i => i.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Imports.Select(i => i.Value).GetEnumerator();
        }

        /// <summary>
        /// Implements the basic subscription logic.
        /// </summary>
        /// <param name="onNext"></param>
        /// <param name="onCompleted"></param>
        /// <returns></returns>
        IDisposable Subscribe(Action<ILazy<T, TMetadata>> onNext, Action onCompleted)
        {
            // send recomposition events to observer
            ImportCollectionChangedEventHandler<T, TMetadata> h1 = (s, a) =>
            {
                foreach (var i in a.NewImports)
                    onNext(new Internal.Lazy<T, TMetadata>(i));
            };

            // send disposed event to observer
            EventHandler h2 = (s, a) =>
                onCompleted();

            // subscribe observer
            ImportsChanged += h1;
            Disposed += h2;

            // send initial values
            if (Imports != null)
                foreach (var i in Imports)
                    if (i != null)
                        onNext(new Internal.Lazy<T, TMetadata>(i));

            // observer can unsubscribe by disposing the result
            return new DelegateDisposable(() =>
            {
                ImportsChanged -= h1;
                Disposed -= h2;
            });
        }

        IDisposable IObservable<ILazy<T, TMetadata>>.Subscribe(IObserver<ILazy<T, TMetadata>> observer)
        {
            return Subscribe(i => observer.OnNext(i), () => observer.OnCompleted());
        }

        IDisposable IObservable<ILazy<T>>.Subscribe(IObserver<ILazy<T>> observer)
        {
            return Subscribe(i => observer.OnNext(i), () => observer.OnCompleted());
        }

        IDisposable IObservable<T>.Subscribe(IObserver<T> observer)
        {
            return Subscribe(i => observer.OnNext(i.Value), () => observer.OnCompleted());
        }

        /// <summary>
        /// Raised when the instance is disposed.
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                if (Disposed != null)
                    Disposed(this, EventArgs.Empty);
                disposed = true;
            }
        }

    }

    /// <summary>
    /// Provides a collection of exports with various notifications to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(DynamicImportCollection<>))]
    [Export(typeof(IImportCollection<>))]
    [Export("ImportCollection", typeof(IImportCollection<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DynamicImportCollection<T> :
        DynamicImportCollection<T, IDictionary<string, object>>
    {


        [ImportingConstructor]
        public DynamicImportCollection()
            :base()
        {

        }


    }

}
