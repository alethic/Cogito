using System;
using System.ComponentModel;

namespace Cogito.Composition
{

    /// <summary>
    /// Describes an import with various methods to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImportValue<T, TMetadata> :
        IObservable<ILazy<T, TMetadata>>,
        ILazy<T, TMetadata>,
        IImportValue<T>
    {

        new event ImportChangedEventHandler<T, TMetadata> ImportChanged;

    }

    /// <summary>
    /// Describes an import with various methods to signal recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImportValue<T> :
        IObservable<ILazy<T>>,
        IObservable<T>,
        ILazy<T>,
        INotifyPropertyChanged,
        IDisposable
    {

        event ImportChangedEventHandler<T> ImportChanged;

    }

}
