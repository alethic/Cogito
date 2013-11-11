using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Graph which allows the addition of <see cref="INegotiators"/> and returns neighbors from a parent <see
    /// cref="INegotiationGraph"/>.
    /// </summary>
    public class MergedNegotiationGraph :
        NegotiationGraphBase
    {

        readonly INegotiationGraph parent;
        readonly HashSet<INegotiator> negotiators;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public MergedNegotiationGraph(INegotiationGraph parent, IEnumerable<INegotiator> negotiators)
        {
            Contract.Requires<ArgumentNullException>(parent != null);
            Contract.Requires<ArgumentNullException>(negotiators != null);

            this.parent = parent;
            this.negotiators = new HashSet<INegotiator>(negotiators.ToList());
        }

        public override IEnumerable<INegotiator> GetNegotiators()
        {
            return negotiators;
        }

        public override IEnumerable<Neighbor> GetNeighbors(IOutputNegotiator negotiator)
        {
            // neighbors derived from our set
            foreach (var i in base.GetNeighbors(negotiator))
                yield return i;

            // we own the negotiator; negotiate ourselves against parent items
            if (negotiators.Contains(negotiator))
                foreach (var i in base.GetNeighbors(negotiator, parent.GetNegotiators()))
                    yield return i;
            else
                // not our node, let parent handle
                foreach (var i in parent.GetNeighbors(negotiator))
                    yield return i;
        }


    }

}
