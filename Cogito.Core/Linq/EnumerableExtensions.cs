using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Linq
{

    /// <summary>
    /// Various extension methods for working with <see cref="IEnumerable"/>s.
    /// </summary>
    public static class EnumerableExtensions
    {

        /// <summary>
        /// Performs an action on each item in a list, used to shortcut a "foreach" loop.
        /// </summary>
        /// <typeparam name="T">Type contained in List</typeparam>
        /// <param name="source">List to enumerate over</param>
        /// <param name="action">Lambda Function to be performed on all elements in List</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(action != null);

            foreach (T item in source)
                action(item);
        }

        /// <summary>
        /// Returns an empty <see cref="IEnumerable"/> if <paramref name="source"/> is null.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable EmptyIfNull(this IEnumerable source)
        {
            return source ?? Enumerable.Empty<object>();
        }

        /// <summary>
        /// Returns an empty <see cref="IEnumerable"/> if <paramref name="source"/> is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns the given enumerable with the given object added to the end.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T o)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (T t in source)
                yield return t;
            yield return o;
        }

        /// <summary>
        /// Returns the given enumerable with the given object added to the beginning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T o)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            yield return o;
            foreach (T t in source)
                yield return t;
        }

        /// <summary>
        /// Iterates recursively through an initial enumerable and each returned child enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public static IEnumerable<T> Recurse<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> children)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(children != null);

            foreach (T t in source)
            {
                yield return t;
                foreach (T t2 in Recurse(children(t), children))
                    yield return t2;
            }
        }

        /// <summary>
        /// Recurses down a given property path until null is encountered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="nextFunc"></param>
        /// <returns></returns>
        public static IEnumerable<T> Recurse<T>(this T target, Func<T, T> nextFunc)
        {
            Contract.Requires<ArgumentNullException>(nextFunc != null);

            // yield existing item
            yield return target;

            // get the next step, then walk it, and yield up results
            var next = nextFunc(target);
            if (next != null)
                foreach (T i in Recurse(next, nextFunc))
                    yield return i;
        }

        /// <summary>
        /// Inserts <paramref name="value"/> into the <see cref="IEnumerable"/> before each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<T> InsertBeforeEach<T>(this IEnumerable<T> source, T value)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (var i in source)
            {
                yield return value;
                yield return i;
            }
        }

        /// <summary>
        /// Inserts <paramref name="value"/> into the <see cref="IEnumerable"/> after each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<T> InsertAfterEach<T>(this IEnumerable<T> source, T value)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (var i in source)
            {
                yield return i;
                yield return value;
            }
        }

        /// <summary>
        /// Returns an enumerable for each input item in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Explode<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (var i in source)
                yield return Enumerable.Empty<T>().Prepend(i);
        }

        /// <summary>
        /// Initializes a new <see cref="LinkedList{T}"/> containing the specified source items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return new LinkedList<T>(source);
        }

        /// <summary>
        /// Initializes a new <see cref="HashSet"/> containing the specified source items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return new HashSet<T>(source);
        }

        /// <summary>
        /// Wraps the given enumerable with another enumerable that can be enumerated multiple times without
        /// reenumerating the original.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Tee<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return Tee(source, false);
        }

        /// <summary>
        /// Wraps the given enumerable with another enumerable that can be enumerated multiple times without
        /// reenumerating the original.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Tee<T>(this IEnumerable<T> source, bool threadSafe)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            if (threadSafe)
                return TeeInternalThreadSafe<T>(source.GetEnumerator(), new List<T>());
            else
                return TeeInternal<T>(source.GetEnumerator(), new List<T>());
        }

        /// <summary>
        /// Generator for Tee.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        static IEnumerable<T> TeeInternal<T>(this IEnumerator<T> source, IList<T> cache)
        {
            int index = 0;
            while (true)
            {
                // Fill from enumerator if we haven't done so already
                if (index == cache.Count)
                {
                    if (source.MoveNext())
                        cache.Add(source.Current);
                    else
                        yield break;
                }

                // Yield value from cache and advance
                yield return cache[index++];
            }
        }

        /// <summary>
        /// Generator for Tee.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        static IEnumerable<T> TeeInternalThreadSafe<T>(this IEnumerator<T> source, IList<T> cache)
        {
            int index = 0;
            while (true)
            {
                lock (cache)
                {
                    // Fill from enumerator if we haven't done so already
                    if (index == cache.Count)
                    {
                        if (source.MoveNext())
                            cache.Add(source.Current);
                        else
                            yield break;
                    }
                }

                // yield value from cache and advance
                yield return cache[index++];
            }
        }

        /// <summary>
        /// Transforms the input, making the previous item available.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectWithPrevious<T, TResult>(this IEnumerable<T> source, Func<T, T, TResult> func)
        {
            T p = default(T);

            foreach (var i in source)
            {
                yield return func(i, p);
                p = i;
            }
        }

        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            var enumerators = source
                .Select(e => e.GetEnumerator())
                .ToArray();

            try
            {
                while (enumerators.All(e => e.MoveNext()))
                    yield return enumerators
                        .Select(e => e.Current)
                        .ToArray();
            }
            finally
            {
                Array.ForEach(enumerators, e => e.Dispose());
            }
        }

        /// <summary>
        /// Returns <c>true</c> if the <paramref name="source"/> sequences contains all the elements of the <paramref name="items"/> sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(items != null);

            return !items.Except(source).Any();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and projects the elements
        /// for each group by using a specified function. Does not maintain groups across adjecent matches.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TElement, TKey>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(keySelector != null);

            var last = default(TKey);
            var haveLast = false;
            var list = new LinkedList<TElement>();

            foreach (var s in source)
            {
                var k = keySelector(s);
                if (haveLast)
                {
                    if (!Equals(k, last))
                    {
                        yield return new GroupOfAdjacent<TKey, TElement>(last, list);

                        list = new LinkedList<TElement>();
                        list.AddLast(s);
                        last = k;
                    }
                    else
                    {
                        list.AddLast(s);
                        last = k;
                    }
                }
                else
                {
                    list.AddLast(s);
                    last = k;
                    haveLast = true;
                }
            }

            if (haveLast)
                yield return new GroupOfAdjacent<TKey, TElement>(last, list);
        }

    }

}
