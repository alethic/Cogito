using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public interface INegotiatorProvider
    {

        /// <summary>
        /// Gets the available set of negotiators.
        /// </summary>
        /// <returns></returns>
        IEnumerable<INegotiator> GetNegotiators();

    }

}
