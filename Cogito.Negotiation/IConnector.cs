using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a component that connects and input meeting certain requirements to an output possessing certain
    /// attributes.
    /// </summary>
    public interface IConnector
    {

        /// <summary>
        /// Configures the <see cref="IConnector"/> by returning a series of <see cref="Negotiator"/>s.
        /// </summary>
        IEnumerable<INegotiator> Configure();

    }

}
