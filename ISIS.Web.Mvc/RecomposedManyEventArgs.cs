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
        /// <param name="added"></param>
        /// <param name="removed"></param>
        internal RecomposedManyEventArgs(IEnumerable<Lazy<T>> added, IEnumerable<Lazy<T>> removed)
        {
            Added = added;
            Removed = removed;
        }

        /// <summary>
        /// Exports which were added.
        /// </summary>
        public IEnumerable<Lazy<T>> Added { get; private set; }

        /// <summary>
        /// Exports which were removed.
        /// </summary>
        public IEnumerable<Lazy<T>> Removed { get; private set; }

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
        /// <param name="added"></param>
        /// <param name="removed"></param>
        internal RecomposedManyEventArgs(IEnumerable<Lazy<T, TMetadata>> added, IEnumerable<Lazy<T, TMetadata>> removed)
            : base(added, removed)
        {

        }

        /// <summary>
        /// Exports which were added.
        /// </summary>
        public new IEnumerable<Lazy<T, TMetadata>> Added
        {
            get { return (IEnumerable<Lazy<T, TMetadata>>)base.Added; }
        }

        /// <summary>
        /// Exports which were removed.
        /// </summary>
        public new IEnumerable<Lazy<T, TMetadata>> Removed
        {
            get { return (IEnumerable<Lazy<T, TMetadata>>)base.Removed; }
        }

    }

}
