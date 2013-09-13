using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Cogito.Composition
{

    /// <summary>
    /// Base <see cref="Composable"/> implementation.
    /// </summary>
    [Export(typeof(Composable<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Composable<T> : INotifyPropertyChanged, IObservable<Lazy<T>>, IObservable<T>, IDisposable
    {

        /// <summary>
        /// Cast to target type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator T(Composable<T> value)
        {
            return value.Value;
        }

        Lazy<T> import;
        bool disposed;

        /// <summary>
        /// Import.
        /// </summary>
        [Import(AllowRecomposition = true, AllowDefault = true)]
        internal virtual Lazy<T> Import
        {
            get { return import; }
            set { var t = this.import; this.import = value; OnChanged(value,t); }
        }

        /// <summary>
        /// Gets the initialized value of the current instance.
        /// </summary>
        public T Value
        {
            get { return import.Value; }
        }

        /// <summary>
        /// Gets a value that indicates whether a value has been created for this instance.
        /// </summary>
        public bool IsValueCreated
        {
            get { return import.IsValueCreated; }
        }

        /// <summary>
        /// Invoke to set the incoming import and raise the appropriate events.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        protected void OnChanged(Lazy<T> newValue, Lazy<T> oldValue)
        {
            RaiseComposed(newValue, oldValue);
            RaisePropertiesChanged();
        }

        /// <summary>
        /// Raise the Composed event given the new and old values.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        protected virtual void RaiseComposed(Lazy<T> newValue, Lazy<T> oldValue)
        {
            OnComposed(new RecomposedEventArgs<T>(newValue, oldValue));
        }

        /// <summary>
        /// Raised when the value is composed.
        /// </summary>
        public event EventHandler<RecomposedEventArgs<T>> Composed;

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnComposed(RecomposedEventArgs<T> args)
        {
            if (Composed != null)
                Composed(this, args);
        }

        /// <summary>
        /// Raised when the value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

        /// <summary>
        /// Raises the PropertyChanged event for all the properties..
        /// </summary>
        protected void RaisePropertiesChanged()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Value"));
            OnPropertyChanged(new PropertyChangedEventArgs("IsValueCreated"));
        }

        IDisposable IObservable<Lazy<T>>.Subscribe(IObserver<Lazy<T>> observer)
        {
            Disposed += (s, a) => 
                observer.OnCompleted();
            EventHandler<RecomposedEventArgs<T>> h = (s, a) =>
                observer.OnNext(import);

            Composed += h;
            return new DelegateDisposable(() => Composed -= h);
        }

        IDisposable IObservable<T>.Subscribe(IObserver<T> observer)
        {
            Disposed += (s, a) =>
                observer.OnCompleted();
            EventHandler<RecomposedEventArgs<T>> h = (s, a) =>
                observer.OnNext(Value);

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
    /// Provides a wrapper that can be used for accepting recomposition through a constructor argument.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(Composable<,>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class Composable<T, TMetadata> : Composable<T>, IObservable<Lazy<T, TMetadata>>
    {

        [Import(AllowRecomposition = true, AllowDefault = true)]
        internal new Lazy<T, TMetadata> Import
        {
            get { return (Lazy<T, TMetadata>)base.Import; }
            set { base.Import = value; }
        }

        /// <summary>
        /// Gets the metadata associated with the referenced object.
        /// </summary>
        public TMetadata Metadata
        {
            get { return Import.Metadata; }
        }

        /// <summary>
        /// Raise the Composed event given the new and old values.
        /// </summary>
        /// <param name="newLazy"></param>
        /// <param name="oldLazy"></param>
        protected override void RaiseComposed(Lazy<T> newLazy, Lazy<T> oldLazy)
        {
            var newM = (Lazy<T, TMetadata>)newLazy;
            var oldM = (Lazy<T, TMetadata>)oldLazy;
            var args = new RecomposedEventArgs<T, TMetadata>(newM, oldM);
            base.OnComposed(args);
            OnComposed(args);
        }

        /// <summary>
        /// Raises the Composed event.
        /// </summary>
        /// <param name="args"></param>
        void OnComposed(RecomposedEventArgs<T, TMetadata> args)
        {
            if (Composed != null)
                Composed(this, args);
        }

        /// <summary>
        /// Raised when the value is recomposed.
        /// </summary>
        public new event EventHandler<RecomposedEventArgs<T, TMetadata>> Composed;

        IDisposable IObservable<Lazy<T, TMetadata>>.Subscribe(IObserver<Lazy<T, TMetadata>> observer)
        {
            Disposed += (s, a) =>
                observer.OnCompleted();
            EventHandler<RecomposedEventArgs<T, TMetadata>> h = (s, a) =>
                observer.OnNext(Import);

            Composed += h;
            return new DelegateDisposable(() => Composed -= h);
        }

    }

}
