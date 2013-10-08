using System.Collections.Generic;

namespace Cogito.Collections
{

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
            self.UnionWith(source);
            return self;
        }

    }

}
