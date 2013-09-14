using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Composition
{

    /// <summary>
    /// Event args that describe a change in imports due to a recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ImportCollectionChangedEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Imports which were added.
        /// </summary>
        public abstract IEnumerable<T> NewValues { get; }

        /// <summary>
        /// Imports which were removed.
        /// </summary>
        public abstract IEnumerable<T> OldValues { get; }

    }

    /// <summary>
    /// Event args that describe a change in imports due to a recomposition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TMetadata"></typeparam>
    public sealed class ImportCollectionChangedEventArgs<T, TMetadata> : ImportCollectionChangedEventArgs<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newImports"></param>
        /// <param name="oldImports"></param>
        internal ImportCollectionChangedEventArgs(IEnumerable<Lazy<T, TMetadata>> newImports, IEnumerable<Lazy<T, TMetadata>> oldImports)
        {
            Contract.Requires<ArgumentNullException>(newImports != null);
            Contract.Requires<ArgumentNullException>(oldImports != null);
            Contract.Ensures(newImports != null);
            Contract.Ensures(oldImports != null);

            NewImports = newImports;
            OldImports = oldImports;
        }

        /// <summary>
        /// Imports which were added.
        /// </summary>
        public IEnumerable<Lazy<T, TMetadata>> NewImports { get; set; }

        /// <summary>
        /// Imports which were removed.
        /// </summary>
        public IEnumerable<Lazy<T, TMetadata>> OldImports { get; set; }


        public override IEnumerable<T> NewValues
        {
            get { return NewImports.Select(i => i.Value); }
        }

        public override IEnumerable<T> OldValues
        {
            get { return OldImports.Select(i => i.Value); }
        }

    }

}
