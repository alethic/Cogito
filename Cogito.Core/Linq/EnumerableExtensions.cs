using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cogito.Linq
{

    /// <summary>
    /// Various extension methods for working with <see cref="IEnumerable"/>s.
    /// </summary>
    public static class EnumerableExtensions
    {

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
            foreach (var i in source)
                yield return Enumerable.Empty<T>().Prepend(i);
        }

        /// <summary>
        /// Initializes a new <see cref="HashSet"/> containing the specified source items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }

    }

}
