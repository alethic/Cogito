using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Core.Linq
{

    /// <summary>
    /// <see cref="IQueryable"/> implementation that can be applied to an underlying <see cref="IQueryable"/>.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class Requeryable<TElement> :
        Query<TElement>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="expression"></param>
        public Requeryable(RequeryableProvider provider, Expression expression)
            : base(provider, expression)
        {
            Contract.Requires<ArgumentNullException>(provider != null);
            Contract.Requires<ArgumentNullException>(expression != null);
        }

    }

}
