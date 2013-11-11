using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public interface IConnectorProvider
    {

        /// <summary>
        /// Gets the available set of negotiators.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IConnector> GetConnectors();

    }

}
