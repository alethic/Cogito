using System;
using System.Collections.Generic;

namespace Cogito.Collections
{

    /// <summary>
    /// Various extension methods for operating on sets.
    /// </summary>
    public static class HashSetExtensions
    {

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in either the current set or the specified collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ISet<T> ThenUnionWith<T>(this ISet<T> self, IEnumerable<T> source)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            self.UnionWith(source);
            return self;
        }

    }

}
