using System;
using System.Diagnostics.Contracts;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes the result of a negotiation between two neighbors.
    /// </summary>
    public struct Neighbor
    {

        IOutputNegotiator head;
        ISourceNegotiator tail;
        NegotiationResult negotiation;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <param name="negotiation"></param>
        public Neighbor(IOutputNegotiator head, ISourceNegotiator tail, NegotiationResult negotiation)
        {
            Contract.Requires<ArgumentNullException>(head != null);
            Contract.Requires<ArgumentNullException>(tail != null);

            this.head = head;
            this.tail = tail;
            this.negotiation = negotiation;
        }

        public IOutputNegotiator Head
        {
            get { return head; }
        }

        public ISourceNegotiator Tail
        {
            get { return tail; }
        }

        public NegotiationResult Negotiation
        {
            get { return negotiation; }
        }

    }

}
