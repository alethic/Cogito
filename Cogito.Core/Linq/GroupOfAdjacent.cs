using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Linq
{

    public class GroupOfAdjacent<TKey, TElement> :
        IEnumerable<TElement>,
        IGrouping<TKey, TElement>
    {

        readonly TKey key;
        readonly IEnumerable<TElement> list;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="list"></param>
        internal GroupOfAdjacent(TKey key, IEnumerable<TElement> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            this.key = key;
            this.list = list;
        }

        /// <summary>
        /// Gets the key of the grouping.
        /// </summary>
        public TKey Key
        {
            get { return key; }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            foreach (var s in list)
                yield return s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
