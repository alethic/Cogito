using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Cogito.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a route between two <see cref="Negotiator"/>s.
    /// </summary>
    public class Route :
        IEnumerable<RouteStep>
    {

        readonly IOutputNegotiator head;
        readonly ISourceNegotiator tail;
        readonly List<RouteStep> path;
        readonly double distance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <param name="path"></param>
        public Route(
            IOutputNegotiator head,
            ISourceNegotiator tail,
            double distance,
            IEnumerable<RouteStep> path)
        {
            this.head = head;
            this.tail = tail;
            this.distance = distance;
            this.path = path.ToList();
        }

        /// <summary>
        /// Gets the head <see cref="Negotiator"/> of the route.
        /// </summary>
        public IOutputNegotiator Head
        {
            get { return head; }
        }

        /// <summary>
        /// Gets the tail <see cref="Negotiator"/> of the route.
        /// </summary>
        public ISourceNegotiator Tail
        {
            get { return tail; }
        }

        /// <summary>
        /// Gets the total weight of the entire route.
        /// </summary>
        public double Distance
        {
            get { return distance; }
        }

        /// <summary>
        /// Executes each step in the route.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Execute(object value)
        {
            // forward value between each step
            foreach (var step in path)
                value = step.Executable.Execute(value, null);

            // return final value
            return value;
        }

        #region IEnumerable

        public IEnumerator<RouteStep> GetEnumerator()
        {
            return path.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }

}
