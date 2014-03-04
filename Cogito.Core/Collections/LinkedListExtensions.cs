using System.Collections.Generic;

namespace Cogito.Collections
{

    /// <summary>
    /// Extension methods for working with <see cref="LinkedList"/> instances.
    /// </summary>
    public static class LinkedListExtensions
    {

        /// <summary>
        /// Gets an enumerable of <see cref="LinkedListNode"/>s.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<LinkedListNode<T>> Forward<T>(this LinkedList<T> self)
        {
            return Forward<T>(self.First);
        }

        /// <summary>
        /// Gets an enumerable of nodes from the current node forwards.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<LinkedListNode<T>> Forward<T>(this LinkedListNode<T> self)
        {
            for (var node = self; node != null; node = node.Next)
                yield return node;
        }

        /// <summary>
        /// Gets an enumerable of nodes from the current node backwards.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<LinkedListNode<T>> Backward<T>(this LinkedListNode<T> self)
        {
            for (var node = self; node != null; node = node.Previous)
                yield return node;
        }

    }

}
