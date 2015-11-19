using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides <see cref="Negotiator"/> implementations from <see cref="IConnectorProvider"/>s.
    /// </summary>
    [NegotiatorProvider]
    public class DefaultNegotiatorProvider :
        INegotiatorProvider
    {

        readonly IEnumerable<IConnectorProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        [ImportingConstructor]
        public DefaultNegotiatorProvider(
            [ImportMany] IEnumerable<IConnectorProvider> providers)
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.providers = providers;
        }

        public IEnumerable<INegotiator> GetNegotiators()
        {
            return providers
                .SelectMany(i => i.GetConnectors())
                .SelectMany(i => i.Configure());
        }

    }

}
