using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Base <see cref="INegotiationGraph"/> implementation.
    /// </summary>
    public abstract class NegotiationGraphBase :
        INegotiationGraph
    {

        /// <summary>
        /// Implements negotiation.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        NegotiationResult Negotiate(IOutputNegotiator head, ISourceNegotiator tail)
        {
            Contract.Requires<ArgumentNullException>(head != null);
            Contract.Requires<ArgumentNullException>(tail != null);

            return Negotiator.Negotiate(head, tail);
        }

        /// <summary>
        /// Gets the available set of <see cref="INegotiator"/> instances.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<INegotiator> GetNegotiators();

        /// <summary>
        /// Gets the neighbors of the given <see cref="IOutputNegotiator"/>.
        /// </summary>
        /// <param name="negotiator"></param>
        /// <returns></returns>
        public virtual IEnumerable<Neighbor> GetNeighbors(IOutputNegotiator negotiator)
        {
            Contract.Requires<ArgumentNullException>(negotiator != null);

            return GetNeighbors(negotiator, GetNegotiators().OfType<ISourceNegotiator>());
        }

        /// <summary>
        /// Gets the neighbors of the given <see cref="INegotiator"/> from the given <see cref="ISourceNegotiator"/> possibilities.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="sources"></param>
        /// <returns></returns>
        public virtual IEnumerable<Neighbor> GetNeighbors(IOutputNegotiator output, IEnumerable<ISourceNegotiator> sources)
        {
            Contract.Requires<ArgumentNullException>(output != null);
            Contract.Requires<ArgumentNullException>(sources != null);

            return sources
                .Where(i => !object.ReferenceEquals(i, output))
                .Select(i => new Neighbor(output, i, Negotiate(output, i)))
                .Where(i => i.Negotiation != null);
        }

    }

}
