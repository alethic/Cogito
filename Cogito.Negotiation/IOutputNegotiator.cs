using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a negotiator that negotiates with a <see cref="ISourceNegotiator"/> in order to produce values.
    /// </summary>
    public interface IOutputNegotiator :
        IExecutable
    {

        /// <summary>
        /// Gets the output contracts that govern negotiation.
        /// </summary>
        ICollection<IOutputContract> Contracts { get; }

        /// <summary>
        /// Gets whether the negotiations with this negotiator are cacheable.
        /// </summary>
        bool Cacheable { get; }

        /// <summary>
        /// Negotiates with the specified <see cref="ISourceContract"/>s in order to decide whether a connection can be accepted.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        NegotiationResult Negotiate(IEnumerable<ISourceContract> source);

    }

}
