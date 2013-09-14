using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Cogito.Composition
{

    /// <summary>
    /// Describes a collection of imports which impliments various change notification mechanisms to signal
    /// recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImportCollection<T, TMetadata> :
        IEnumerable<ILazy<T, TMetadata>>,
        IObservable<ILazy<T, TMetadata>>,
        IImportCollection<T>
    {

        new event ImportCollectionChangedEventHandler<T, TMetadata> ImportsChanged;

    }

    /// <summary>
    /// Describes a collection of imports which impliments various change notification mechanisms to signal
    /// recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImportCollection<T> :
        IEnumerable<ILazy<T>>,
        IObservable<ILazy<T>>,
        INotifyCollectionChanged,
        IImportValueCollection<T>
    {

        event ImportCollectionChangedEventHandler<T> ImportsChanged;

        /// <summary>
        /// Gets the value collection.
        /// </summary>
        IImportValueCollection<T> Values { get; }

    }

    /// <summary>
    /// Describes a collection of import values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IImportValueCollection<out T> :
        IEnumerable<T>,
        IObservable<T>,
        INotifyCollectionChanged,
        IDisposable
    {



    }

}
