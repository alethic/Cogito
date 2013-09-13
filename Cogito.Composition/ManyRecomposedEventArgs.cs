using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Composition
{

    /// <summary>
    /// Event args that describe a change in exports.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ManyRecomposedEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newExports"></param>
        /// <param name="oldExports"></param>
        internal ManyRecomposedEventArgs(IEnumerable<Lazy<T>> newExports, IEnumerable<Lazy<T>> oldExports)
        {
            Contract.Requires<ArgumentNullException>(newExports != null);
            Contract.Requires<ArgumentNullException>(oldExports != null);
            Contract.Ensures(newExports != null);
            Contract.Ensures(oldExports != null);
            NewExports = newExports;
            OldExports = oldExports;
        }

        /// <summary>
        /// Exports which were added.
        /// </summary>
        public IEnumerable<Lazy<T>> NewExports { get; private set; }

        /// <summary>
        /// Exports which were removed.
        /// </summary>
        public IEnumerable<Lazy<T>> OldExports { get; private set; }

    }

    /// <summary>
    /// Event args that describe a change in exports.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TMetadata"></typeparam>
    public sealed class ManyRecomposedEventArgs<T, TMetadata> : ManyRecomposedEventArgs<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newExports"></param>
        /// <param name="oldExports"></param>
        internal ManyRecomposedEventArgs(IEnumerable<Lazy<T, TMetadata>> newExports, IEnumerable<Lazy<T, TMetadata>> oldExports)
            : base(newExports, oldExports)
        {
            Contract.Requires<ArgumentNullException>(newExports != null);
            Contract.Requires<ArgumentNullException>(oldExports != null);
            Contract.Ensures(newExports != null);
            Contract.Ensures(oldExports != null);
        }

        /// <summary>
        /// Exports which were added.
        /// </summary>
        public new IEnumerable<Lazy<T, TMetadata>> NewExports
        {
            get { return (IEnumerable<Lazy<T, TMetadata>>)base.NewExports; }
        }

        /// <summary>
        /// Exports which were removed.
        /// </summary>
        public new IEnumerable<Lazy<T, TMetadata>> OldExports
        {
            get { return (IEnumerable<Lazy<T, TMetadata>>)base.OldExports; }
        }

    }

}
