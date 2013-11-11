using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Builds routes between negotiables.
    /// </summary>
    public interface IRouter
    {

        /// <summary>
        /// Generates a route between a head <see cref="IOutputNegotiator"/> and a tail <see cref="ISourceNegotiator"/>.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        IEnumerable<Route> Route(INegotiationGraph graph, IOutputNegotiator head, ISourceNegotiator tail);

    }

}
