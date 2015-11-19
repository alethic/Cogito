using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a negotiator that negotiates with a <see cref="IOutputNegotiator"/> in order to accept values.
    /// </summary>
    public interface ISourceNegotiator :
        IExecutable
    {

        /// <summary>
        /// Gets the source contracts that govern negotiation.
        /// </summary>
        ICollection<ISourceContract> Contracts { get; }

        /// <summary>
        /// Negotiates with the specified <see cref="IOutputContract"/>s in order to decide whether a connection can be accepted.
        /// </summary>
        /// <param name="contracts"></param>
        /// <returns></returns>
        NegotiationResult Negotiate(IEnumerable<IOutputContract> contracts);

    }

}
