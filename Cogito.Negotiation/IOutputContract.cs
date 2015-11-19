namespace Cogito.Negotiation
{

    /// <summary>
    /// Defines a contract effecting outbound negotiation.
    /// </summary>
    public interface IOutputContract
    {

        /// <summary>
        /// Negotiates with the <see cref="ISourceNegotiator"/> peer.
        /// </summary>
        /// <param name="peer"></param>
        /// <returns></returns>
        NegotiationResult Negotiate(ISourceNegotiator peer);

    }

}
