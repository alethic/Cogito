using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

namespace Cogito.Composition
{

    /// <summary>
    /// Provides an import with various notifications to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TMetadata"></typeparam>
    [Export(typeof(DynamicImport<,>))]
    [Export(typeof(IImportValue<,>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DynamicImport<T, TMetadata> : IImportValue<T, TMetadata>
    {

        /// <summary>
        /// Cast to target type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator T(DynamicImport<T, TMetadata> value)
        {
            Contract.Requires<ArgumentNullException>(value != null);

            return value.Value;
        }

        Lazy<T, TMetadata> import;
        bool disposed;
        ImportChangedEventHandler<T, TMetadata> importChanged;
        ImportChangedEventHandler<T> importChanged2;

        /// <summary>
        /// Injected by the container.
        /// </summary>
        [Import(AllowRecomposition = true, AllowDefault = true)]
        public Lazy<T, TMetadata> Import
        {
            get { return import; }
            set { Contract.Requires(value != null); var t = import; import = value; OnChanged(import, t); }
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
        /// Gets the metadata of the current instance.
        /// </summary>
        public TMetadata Metadata
        {
            get { return import.Metadata; }
        }

        /// <summary>
        /// Invoke to set the incoming import and raise the appropriate events.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        protected void OnChanged(Lazy<T, TMetadata> newValue, Lazy<T, TMetadata> oldValue)
        {
            Contract.Requires<ArgumentNullException>(newValue != null);
            Contract.Requires<ArgumentNullException>(oldValue != null);

            RaiseImportChanged(newValue, oldValue);
            RaisePropertiesChanged();
        }

        /// <summary>
        /// Raise the Composed event given the new and old values.
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        protected virtual void RaiseImportChanged(Lazy<T, TMetadata> newValue, Lazy<T, TMetadata> oldValue)
        {
            Contract.Requires<ArgumentNullException>(newValue != null);
            Contract.Requires<ArgumentNullException>(oldValue != null);

            OnImportChanged(new ImportChangedEventArgs<T, TMetadata>(newValue, oldValue));
        }

        /// <summary>
        /// Raised when the value is changed.
        /// </summary>
        public event ImportChangedEventHandler<T, TMetadata> ImportChanged
        {
            add { importChanged += value; }
            remove { importChanged -= value; }
        }

        /// <summary>
        /// Raised when the value is changed.
        /// </summary>
        event ImportChangedEventHandler<T> IImportValue<T>.ImportChanged
        {
            add { importChanged2 += value; }
            remove { importChanged2 -= value; }
        }

        /// <summary>
        /// Raises the ImportChanged event.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnImportChanged(ImportChangedEventArgs<T, TMetadata> args)
        {
            Contract.Requires<ArgumentNullException>(args != null);

            if (importChanged != null)
                importChanged(this, args);
            if (importChanged2 != null)
                importChanged2(this, args);
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
            Contract.Requires<ArgumentNullException>(args != null);

            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

        /// <summary>
        /// Raises the PropertyChanged event for all the properties.
        /// </summary>
        protected void RaisePropertiesChanged()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Value"));
            OnPropertyChanged(new PropertyChangedEventArgs("IsValueCreated"));
            OnPropertyChanged(new PropertyChangedEventArgs("Metadata"));
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
            ImportChangedEventHandler<T, TMetadata> h1 = (s, a) =>
                onNext(new Internal.Lazy<T, TMetadata>(a.NewImport));

            // send disposed event to observer
            EventHandler h2 = (s, a) =>
                onCompleted();

            // subscribe observer
            ImportChanged += h1;
            Disposed += h2;

            // send initial value
            if (Import != null)
                onNext(new Internal.Lazy<T, TMetadata>(Import));

            // observer can unsubscribe by disposing the result
            return new DelegateDisposable(() =>
            {
                ImportChanged -= h1;
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
    /// Provides an import with various notifications to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Export(typeof(DynamicImport<>))]
    [Export(typeof(IImportValue<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class DynamicImport<T> :
        DynamicImport<T, IDictionary<string, object>>
    {



    }

}
