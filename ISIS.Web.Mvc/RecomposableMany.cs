using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Provides a wrapper that can be used for accepting recomposition of a collection through a constructor argument.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export]
    public class RecomposableMany<T> : IEnumerable<Lazy<T>>, INotifyCollectionChanged, IObservable<Lazy<T>>, IObservable<T>, IDisposable
    {

        IEnumerable<Lazy<T>> imports;
        bool disposed;

        /// <summary>
        /// Current values.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        internal IEnumerable<Lazy<T>> Imports
        {
            get { return imports; }
            set { var t = this.imports; this.imports = value; OnChanged(this.imports, t); }
        }

        /// <summary>
        /// Raises all the appropriate events.
        /// </summary>
        void OnChanged(IEnumerable<Lazy<T>> newItems, IEnumerable<Lazy<T>> oldItems)
        {
            var n = newItems ?? Enumerable.Empty<Lazy<T>>();
            var o = oldItems ?? Enumerable.Empty<Lazy<T>>();

            var a = n.Except(o); // added
            var r = o.Except(n); // removed

            RaiseComposed(a, r);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, r));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, a));
        }

        /// <summary>
        /// Raised when the import is composed.
        /// </summary>
        public event EventHandler<RecomposedManyEventArgs<T>> Composed;

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        /// <param name="added"></param>
        /// <param name="removed"></param>
        protected virtual void RaiseComposed(IEnumerable<Lazy<T>> added, IEnumerable<Lazy<T>> removed)
        {
            OnComposed(new RecomposedManyEventArgs<T>(added, removed));
        }

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        protected void OnComposed(RecomposedManyEventArgs<T> args)
        {
            if (Composed != null)
                Composed(this, args);
        }

        /// <summary>
        /// Raised when the exports are changed.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Raises the CollectionChanged event.
        /// </summary>
        void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, args);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the imports.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Lazy<T>> GetEnumerator()
        {
            return Imports.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IDisposable IObservable<Lazy<T>>.Subscribe(IObserver<Lazy<T>> observer)
        {
            Disposed += (s, a) =>
                observer.OnCompleted();
            EventHandler<RecomposedManyEventArgs<T>> h = (s, a) =>
            {
                foreach (var i in a.Added)
                    observer.OnNext(i);
            };

            Composed += h;
            return new DelegateDisposable(() => Composed -= h);
        }

        IDisposable IObservable<T>.Subscribe(IObserver<T> observer)
        {
            Disposed += (s, a) =>
                observer.OnCompleted();
            EventHandler<RecomposedManyEventArgs<T>> h = (s, a) =>
            {
                foreach (var i in a.Added)
                    observer.OnNext(i.Value);
            };

            Composed += h;
            return new DelegateDisposable(() => Composed -= h);
        }

        protected event EventHandler Disposed;

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
    /// Provides a wrapper that can be used for accepting recomposition of a collection with metadata through a constructor argument.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export]
    public sealed class RecomposableMany<T, TMetadata> : RecomposableMany<T>, IEnumerable<Lazy<T, TMetadata>>, IObservable<Lazy<T, TMetadata>>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal RecomposableMany()
            : base()
        {

        }

        /// <summary>
        /// Current exports.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public new IEnumerable<Lazy<T, TMetadata>> Imports
        {
            get { return (IEnumerable<Lazy<T, TMetadata>>)base.Imports; }
            set { base.Imports = value; }
        }

        /// <summary>
        /// Raised when the import is composed.
        /// </summary>
        public new event EventHandler<RecomposedManyEventArgs<T, TMetadata>> Composed;

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        /// <param name="added"></param>
        /// <param name="removed"></param>
        protected override void RaiseComposed(IEnumerable<Lazy<T>> added, IEnumerable<Lazy<T>> removed)
        {
            var args = new RecomposedManyEventArgs<T, TMetadata>((IEnumerable<Lazy<T, TMetadata>>)added, (IEnumerable<Lazy<T, TMetadata>>)removed);
            base.OnComposed(args);
            OnComposed(args);
        }

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        /// <param name="args"></param>
        void OnComposed(RecomposedManyEventArgs<T, TMetadata> args)
        {
            if (Composed != null)
                Composed(this, args);
        }

        public new IEnumerator<Lazy<T, TMetadata>> GetEnumerator()
        {
            return Imports.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IDisposable IObservable<Lazy<T, TMetadata>>.Subscribe(IObserver<Lazy<T, TMetadata>> observer)
        {
            Disposed += (s, a) =>
                observer.OnCompleted();
            EventHandler<RecomposedManyEventArgs<T, TMetadata>> h = (s, a) =>
            {
                foreach (var i in a.Added)
                    observer.OnNext(i);
            };

            Composed += h;
            return new DelegateDisposable(() => Composed -= h);
        }

    }

}
