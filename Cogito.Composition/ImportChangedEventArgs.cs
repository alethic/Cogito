using System;

namespace Cogito.Composition
{

    /// <summary>
    /// Event args that describe a change in import value during recomposition.
    /// </summary>
    public abstract class ImportChangedEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Current import.
        /// </summary>
        public Lazy<T> NewImport
        {
            get { return NewImportInternal;}
        }

        protected abstract Lazy<T> NewImportInternal { get; }

        /// <summary>
        /// Previous import.
        /// </summary>
        public Lazy<T> OldImport
        {
           get {  return OldImportInternal;}
        }

        protected abstract Lazy<T> OldImportInternal { get; }

    }

    /// <summary>
    /// Event args that describe a change in import value during recomposition.
    /// </summary>
    /// <typeparam name="TMetadata"></typeparam>
    public sealed class ImportChangedEventArgs<T, TMetadata> : ImportChangedEventArgs<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newImport"></param>
        /// <param name="oldImport"></param>
        internal ImportChangedEventArgs(Lazy<T, TMetadata> newImport, Lazy<T, TMetadata> oldImport)
        {
            NewImport = newImport;
            OldImport = oldImport;
        }

        /// <summary>
        /// Current import.
        /// </summary>
        public new Lazy<T, TMetadata> NewImport { get; private set; }

        protected override Lazy<T> NewImportInternal
        {
            get { return NewImport; }
        }

        /// <summary>
        /// Previous import.
        /// </summary>
        public new Lazy<T, TMetadata> OldImport { get; private set; }

        protected override Lazy<T> OldImportInternal
        {
            get { return OldImport; }
        }

    }

}
