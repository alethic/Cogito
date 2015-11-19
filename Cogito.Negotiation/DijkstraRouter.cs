using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Collections;
using Cogito.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Negotiations paths between two negotiables.
    /// </summary>
    [Export(typeof(IRouter))]
    public class DijkstraRouter :
        IRouter
    {

        /// <summary>
        /// Describes a node during path finding.
        /// </summary>
        class Node
        {

            IExecutable negotiator;
            NegotiationResult negotiation;
            Node previous;
            double distance;
            bool finished;

            //IEnumerable<Tuple<Node, Negotiation>> neighbors;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="negotiator"></param>
            public Node(IExecutable negotiator)
            {
                Contract.Requires<ArgumentNullException>(negotiator != null);

                this.negotiator = negotiator;
                this.negotiation = null;
                this.previous = null;
                this.distance = double.PositiveInfinity;
                this.finished = false;
            }

            /// <summary>
            /// Gets the <see cref="IExecutable"/> represented by the node.
            /// </summary>
            public IExecutable Negotiator
            {
                get { return negotiator; }
            }

            /// <summary>
            /// Gets the <see cref="Negotiation"/> between this <see cref="Negotiator"/> and the previous <see
            /// cref="Negotiator"/> that currently serves as the least cost path to this node.
            /// </summary>
            public NegotiationResult Negotiation
            {
                get { return negotiation; }
                set { negotiation = value; }
            }

            /// <summary>
            /// Gets or sets the previous node that curently serves as the least cost path to this node.
            /// </summary>
            public Node Previous
            {
                get { return previous; }
                set { previous = value; }
            }

            /// <summary>
            /// Gets or sets the current distance to the node from the root.
            /// </summary>
            public double Distance
            {
                get { return distance; }
                set { distance = value; }
            }

            /// <summary>
            /// Gets whether or not this node is finished.
            /// </summary>
            public bool Finished
            {
                get { return finished; }
                set { finished = value; }
            }

        }

        /// <summary>
        /// Instance of the running algorithm.
        /// </summary>
        class Algorithm :
            IEnumerable<Route>
        {

            readonly INegotiationGraph graph;
            readonly IOutputNegotiator root;
            readonly ISourceNegotiator dest;

            readonly DemandDictionary<IExecutable, Node> nodes;
            readonly FibonacciQueue<Node, double> queue;

            Route route;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="graph"></param>
            /// <param name="dest"></param>
            /// <param name="root"></param>
            public Algorithm(
                INegotiationGraph graph,
                IOutputNegotiator root,
                ISourceNegotiator dest)
            {
                this.graph = graph;
                this.nodes = new DemandDictionary<IExecutable, Node>(_ => AllocateNode(_));
                this.queue = new FibonacciQueue<Node, double>(_ => _.Distance);
                this.root = root;
                this.dest = dest;
            }

            /// <summary>
            /// Generates a new <see cref="Node"/> for a <see cref="IExecutable"/> that does not yet have a node.
            /// </summary>
            /// <param name="negotiator"></param>
            /// <returns></returns>
            Node AllocateNode(IExecutable negotiator)
            {
                var node = new Node(negotiator);
                queue.Enqueue(node);
                return node;
            }

            /// <summary>
            /// Gets the <see cref="Node"/> associated with the <see cref="INegotiator"/>.
            /// </summary>
            /// <param name="negotiator"></param>
            /// <returns></returns>
            Node GetNode(IExecutable negotiator)
            {
                return nodes[negotiator];
            }

            /// <summary>
            /// Gets the <see cref="Node"/> that should be worked next.
            /// </summary>
            /// <returns></returns>
            Node GetNext()
            {
                return queue.Dequeue();
            }

            /// <summary>
            /// Gets the unfinished neighbors of the given node.
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            IEnumerable<STuple<Node, NegotiationResult>> GetNeighbors(Node node)
            {
                // only output negotiators can have neighbors
                var output = node.Negotiator as IOutputNegotiator;
                if (output == null)
                    yield break;

                foreach (var i in graph.GetNeighbors(output))
                    yield return STuple.Create(GetNode(i.Tail), i.Negotiation);
            }

            /// <summary>
            /// Returns an enumeration of routes from <paramref name="root"/> to <paramref name="dest"/>.
            /// </summary>
            /// <param name="root"></param>
            /// <param name="dest"></param>
            /// <returns></returns>
            Route GetRoute()
            {
                // reset root node
                var init = GetNode(root);
                init.Distance = 0;
                queue.Update(init);

                while (queue.Count > 0)
                {
                    // current node
                    var head = queue.Dequeue();

                    // update neighbor
                    foreach (var pair in GetNeighbors(head))
                    {
                        var tail = pair.Item1;
                        var nego = pair.Item2;

                        var distance = head.Distance + nego.Weight;
                        if (distance < tail.Distance)
                        {
                            // update tail with better path through head
                            tail.Negotiation = nego;
                            tail.Distance = distance;
                            tail.Previous = head;
                            queue.Update(tail);
                        }
                    }

                    // head has been finished
                    head.Finished = true;

                    // we've reached the target; return the reverse path
                    if (head.Negotiator == dest)
                        return new Route(
                            root,
                            dest,
                            head.Distance,
                            head
                                .Recurse(i => i.Previous)
                                .SelectWithPrevious((i, p) => new RouteStep(
                                    i.Negotiator,
                                    p != null && p.Negotiation != null ? p.Negotiation.Weight : 0d))
                                .Reverse()
                                .ToList());
                }

                return null;
            }


            public IEnumerator<Route> GetEnumerator()
            {
                if ((route ?? (route = GetRoute())) != null)
                    yield return route;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }

        /// <summary>
        /// Negotiates a route between <paramref name="root"/> and <paramref name="dest"/>.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public IEnumerable<Route> Route(INegotiationGraph graph, IOutputNegotiator root, ISourceNegotiator dest)
        {
            return new Algorithm(graph, root, dest);
        }

    }

}
