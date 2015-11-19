using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Cogito.Linq;

namespace Cogito.Negotiation
{

    [Export(typeof(INegotiationService))]
    public class NegotiationService :
        INegotiationService
    {

        static readonly MethodInfo genericMethodDefinition = typeof(NegotiationService)
            .GetMethods()
            .Where(i => i.Name == "Negotiate")
            .Where(i => i.IsGenericMethodDefinition)
            .Where(i => i.GetParameters().Length == 2)
            .First();

        readonly INegotiationGraph graph;
        readonly IRouter router;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="router"></param>
        [ImportingConstructor]
        public NegotiationService(
            INegotiationGraph graph,
            IRouter router)
        {
            this.graph = graph;
            this.router = router;
        }

        /// <summary>
        /// Negotiates between two types with a given set of additional <see cref="INegotiator"/>s, and a specified
        /// head and tail.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <param name="negotiators"></param>
        /// <returns></returns>
        public Negotiated<TSource, TOutput> Negotiate<TSource, TOutput>(
            INegotiator head,
            INegotiator tail,
            IEnumerable<INegotiator> negotiators)
        {
            // overlay input graph
            var overlay = new MergedNegotiationGraph(graph, negotiators);

            // build the routes and check for at least one
            var routes = router.Route(overlay, head, tail).Tee();
            var route1 = routes.FirstOrDefault();
            if (route1 == null)
                return null;

            // return first non-null route
            return new Negotiated<TSource, TOutput>(routes);
        }


        /// <summary>
        /// Negotiators between two types.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="sourceConfigure"></param>
        /// <param name="outputConfigure"></param>
        /// <returns></returns>
        public Negotiated<TSource, TOutput> Negotiate<TSource, TOutput>(
            Action<IOutputNegotiator> sourceConfigure,
            Action<ISourceNegotiator> outputConfigure)
        {
            // configure additional properties on head
            var head = Negotiator.Terminate<TSource>();
            if (sourceConfigure != null)
                sourceConfigure(head);

            // configure additional propoerties on tail
            var tail = Negotiator.Terminate<TOutput>();
            if (outputConfigure != null)
                outputConfigure(tail);

            return Negotiate<TSource, TOutput>(
                head,
                tail,
                new[] { head, tail });
        }

        /// <summary>
        /// Negotiates between two types.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="outputType"></param>
        /// <param name="sourceConfigure"></param>
        /// <param name="outputConfigure"></param>
        /// <returns></returns>
        public Negotiated Negotiate(
            Type sourceType,
            Type outputType,
            Action<IOutputNegotiator> sourceConfigure,
            Action<ISourceNegotiator> outputConfigure)
        {
            Contract.Requires<ArgumentNullException>(sourceType != null);
            Contract.Requires<ArgumentNullException>(outputType != null);

            return (Negotiated)genericMethodDefinition.MakeGenericMethod(sourceType, outputType)
                .Invoke(this, new object[] { sourceConfigure, outputConfigure });
        }

    }

}
