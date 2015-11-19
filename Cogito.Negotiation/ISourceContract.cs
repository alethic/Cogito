namespace Cogito.Negotiation
{

    /// <summary>
    /// Defines a contract effecting inbound negotiation.
    /// </summary>
    public interface ISourceContract
    {

        /// <summary>
        /// Negotiates with the <see cref="IOutputNegotiator"/> peer.
        /// </summary>
        /// <param name="peer"></param>
        /// <returns></returns>
        NegotiationResult Negotiate(IOutputNegotiator peer);

    }

}
