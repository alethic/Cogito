using System;
using System.Collections.Generic;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Event args that describe a change in exports.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RecomposedManyEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newExports"></param>
        /// <param name="oldExports"></param>
        internal RecomposedManyEventArgs(IEnumerable<Lazy<T>> newExports, IEnumerable<Lazy<T>> oldExports)
        {
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
    public sealed class RecomposedManyEventArgs<T, TMetadata> : RecomposedManyEventArgs<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="newExports"></param>
        /// <param name="oldExports"></param>
        internal RecomposedManyEventArgs(IEnumerable<Lazy<T, TMetadata>> newExports, IEnumerable<Lazy<T, TMetadata>> oldExports)
            : base(newExports, oldExports)
        {

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
