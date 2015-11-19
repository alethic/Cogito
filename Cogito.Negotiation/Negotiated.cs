using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Represents a completed negotiation that can be invoked.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class Negotiated<TSource, TOutput> :
        Negotiated
    {

        readonly IEnumerable<Route> routes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="routes"></param>
        public Negotiated(IEnumerable<Route> routes)
        {
            Contract.Requires<ArgumentNullException>(routes != null);

            this.routes = routes;
        }

        /// <summary>
        /// Invokes the negotiation with the given source object.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public TOutput Invoke(TSource source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return (TOutput)routes
                .Select(i => i.Execute(source))
                .FirstOrDefault(i => i != null);
        }

        public override object Invoke(object source)
        {
            return Invoke((TSource)source);
        }

    }

    /// <summary>
    /// Represents a completed negotiation that can be invoked.
    /// </summary>
    public abstract class Negotiated
    {

        /// <summary>
        /// Invokes the negotiation with the given source object.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public abstract object Invoke(object source);

    }

}
