using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Collections
{

    /// <summary>
    /// Various extension methods for working with collection
    /// </summary>
    public static class CollectionExtensions
    {

        /// <summary>
        /// Adds all of the items to the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="add"></param>
        public static void AddRange<T>(this ICollection<T> self, IEnumerable<T> add)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(add != null);

            foreach (var i in add)
                self.Add(i);
        }

        /// <summary>
        /// Removes all of the items from the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="remove"></param>
        public static void RemoveRange<T>(this ICollection<T> self, IEnumerable<T> remove)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(remove != null);

            foreach (var i in remove)
                self.Remove(i);
        }

        /// <summary>
        /// Removes all of the items from the first collection which do not appear in the second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="keep"></param>
        public static void RemoveExceptRange<T>(this ICollection<T> self, IEnumerable<T> keep)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(keep != null);
            
            self.RemoveRange(self.Except(keep).ToArray());
        }

    }

}
