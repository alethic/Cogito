using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides operations to navigate a negotiation graph.
    /// </summary>
    public interface INegotiationGraph
    {

        /// <summary>
        /// Gets the set of available <see cref="INegotiators"/> which are members of the graph.
        /// </summary>
        /// <returns></returns>
        IEnumerable<INegotiator> GetNegotiators();

        /// <summary>
        /// Gets or adds the negotiated neighbors of the specified negotiator.
        /// </summary>
        /// <param name="negotiator"></param>
        /// <returns></returns>
        IEnumerable<Neighbor> GetNeighbors(IOutputNegotiator negotiator);

    }

}
