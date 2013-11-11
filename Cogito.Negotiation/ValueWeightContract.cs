namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes valued weight.
    /// </summary>
    public struct ValueWeightContract :
        IOutputContract
    {

        readonly double weight;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="weight"></param>
        public ValueWeightContract(double weight)
        {
            this.weight = weight;
        }

        public NegotiationResult Negotiate(ISourceNegotiator peer)
        {
            return new NegotiationResult(weight);
        }

    }

}
