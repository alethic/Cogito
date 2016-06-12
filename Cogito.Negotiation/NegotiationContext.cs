namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides access to the context of negotiation between two <see cref="Negotiator"/>s.
    /// </summary>
    public sealed class NegotiationContext
    {

        readonly RouteStep first;
        readonly RouteStep current;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="current"></param>
        /// <param name="tail"></param>
        internal NegotiationContext(RouteStep first, RouteStep current)
        {
            this.first = first;
            this.current = current;
        }

        /// <summary>
        /// Gets the root <see cref="RouteStep"/>. That is the first step in the current descending tree.
        /// </summary>
        public RouteStep First
        {
            get { return first; }
        }

        /// <summary>
        /// Gets the head <see cref="RouteStep"/>. That is the previous step in the current descending tree.
        /// </summary>
        public RouteStep Previous
        {
            get { return first; }
        }

    }

}
