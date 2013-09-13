using System;

namespace ISIS.Web.Mvc
{

    /// <summary>
    /// Event args that describe a change in export value during recomposition.
    /// </summary>
    public class RecomposedEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal RecomposedEventArgs(Lazy<T> current, Lazy<T> previous)
        {
            Current = current;
            Previous = previous;
        }

        /// <summary>
        /// Current.
        /// </summary>
        public Lazy<T> Current { get; private set; }

        /// <summary>
        /// Previous.
        /// </summary>
        public Lazy<T> Previous { get; private set; }

    }

    /// <summary>
    /// Event args that describe a change in export value during recomposition.
    /// </summary>
    /// <typeparam name="TMetadata"></typeparam>
    public sealed class RecomposedEventArgs<T, TMetadata> : RecomposedEventArgs<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        internal RecomposedEventArgs(Lazy<T, TMetadata> current, Lazy<T, TMetadata> previous)
            : base(current, previous)
        {

        }

        /// <summary>
        /// Current metadata.
        /// </summary>
        public new Lazy<T, TMetadata> Current
        {
            get { return (Lazy<T, TMetadata>)base.Current; }
        }

        /// <summary>
        /// Previous metadata.
        /// </summary>
        public new Lazy<T, TMetadata> Previous
        {
            get { return (Lazy<T, TMetadata>)base.Previous; }
        }

    }

}
