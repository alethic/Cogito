namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a negotiation between two components and the resulting weight.
    /// </summary>
    public class NegotiationResult
    {

        /// <summary>
        /// Returns a <see cref="NegotiationResult"/> instance that represents success.
        /// </summary>
        public static NegotiationResult Success
        {
            get { return new NegotiationResult(0d); }
        }

        readonly double weight;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="weight"></param>
        public NegotiationResult(double weight)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Gets the negotiated weight.
        /// </summary>
        public double Weight
        {
            get { return weight; }
        }

    }

}
