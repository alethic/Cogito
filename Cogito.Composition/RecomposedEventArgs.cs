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
        internal RecomposedEventArgs(Lazy<T> newExport, Lazy<T> oldExport)
        {
            NewExport = newExport;
            OldExport = oldExport;
        }

        /// <summary>
        /// Current.
        /// </summary>
        public Lazy<T> NewExport { get; private set; }

        /// <summary>
        /// Previous.
        /// </summary>
        public Lazy<T> OldExport { get; private set; }

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
        /// <param name="newExport"></param>
        /// <param name="oldExport"></param>
        internal RecomposedEventArgs(Lazy<T, TMetadata> newExport, Lazy<T, TMetadata> oldExport)
            : base(newExport, oldExport)
        {

        }

        /// <summary>
        /// Current metadata.
        /// </summary>
        public new Lazy<T, TMetadata> NewExport
        {
            get { return (Lazy<T, TMetadata>)base.NewExport; }
        }

        /// <summary>
        /// Previous metadata.
        /// </summary>
        public new Lazy<T, TMetadata> OldExport
        {
            get { return (Lazy<T, TMetadata>)base.OldExport; }
        }

    }

}
