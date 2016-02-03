using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Collections
{

    public static class CollectionExtensions
    {

        public static void AddRange<T>(this ICollection<T> self, IEnumerable<T> add)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(add != null);

            foreach (var i in add)
                self.Add(i);
        }

        public static void RemoveRange<T>(this ICollection<T> self, IEnumerable<T> remove)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(remove != null);

            foreach (var i in remove)
                self.Remove(i);
        }

        public static void RemoveExceptRange<T>(this ICollection<T> self, IEnumerable<T> keep)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(keep != null);
            
            self.RemoveRange(self.Except(keep).ToArray());
        }

    }

}
