using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides a cached graph of the available negotiators and their relationships.
    /// </summary>
    [Export(typeof(INegotiationGraph))]
    public class DefaultNegotiationGraph :
        NegotiationGraphBase
    {

        readonly IEnumerable<INegotiatorProvider> providers;
        readonly IEnumerable<INegotiator> negotiators;

        readonly ConcurrentDictionary<IOutputNegotiator, IEnumerable<Neighbor>> neighborCache =
            new ConcurrentDictionary<IOutputNegotiator, IEnumerable<Neighbor>>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public DefaultNegotiationGraph(
            [ImportMany] IEnumerable<INegotiatorProvider> providers)
        {
            Contract.Requires<ArgumentNullException>(providers != null);

            this.providers = providers;
            this.negotiators = providers.SelectMany(i => i.GetNegotiators()).ToList();
        }

        /// <summary>
        /// Gets the set of <see cref="INegotiator"/>s that are members of the graph.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<INegotiator> GetNegotiators()
        {
            return negotiators;
        }

        /// <summary>
        /// Gets the neighbors of the specified negotiator, caching the results.
        /// </summary>
        /// <param name="negotiator"></param>
        /// <returns></returns>
        public override IEnumerable<Neighbor> GetNeighbors(IOutputNegotiator negotiator)
        {
            return neighborCache.GetOrAdd(negotiator, _ =>
                base.GetNeighbors(_)
                    .ToList());
        }


    }

}
