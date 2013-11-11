using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides <see cref="IConnector"/> implementations from the container.
    /// </summary>
    [ConnectorProvider]
    public class DefaultConnectorProvider :
        IConnectorProvider
    {

        readonly IEnumerable<IConnector> negotiators;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="negotiators"></param>
        [ImportingConstructor]
        public DefaultConnectorProvider(
            [ImportMany] IEnumerable<IConnector> negotiators)
        {
            Contract.Requires<ArgumentNullException>(negotiators != null);

            this.negotiators = negotiators;
        }

        public IEnumerable<IConnector> GetConnectors()
        {
            return negotiators;
        }

    }

}
