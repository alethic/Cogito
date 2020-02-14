using System;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Linq
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
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
        }

        /// <summary>
        /// Applies the <see cref="Requerable{TElement}"/> to a new <see cref="IQueryable"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IQueryable<TElement> Requery(IQueryable<TElement> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            throw new NotImplementedException();
        }

    }

}
