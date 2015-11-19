namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a weighting contract on a negotiator.
    /// </summary>
    public interface IWeightContract
    {

        /// <summary>
        /// Gets the weighting value.
        /// </summary>
        double Weight { get; }

    }

}
