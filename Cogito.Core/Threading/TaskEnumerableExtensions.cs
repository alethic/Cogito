using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public static class TaskEnumerableExtensions
    {

        /// <summary>
        /// Returns a <see cref="Task"/> that waits for all of the individual tasks to be complete.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Task WaitAllAsync(this IEnumerable<Task> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return Task.WhenAll(source);
        }

        /// <summary>
        /// Returns a <see cref="Task{T}"/> that waits for all of the individual <see cref="Task{T}"/> to be complete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Task<T[]> ToArrayAsync<T>(this IEnumerable<Task<T>> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return Task.WhenAll<T>(source);
        }

        /// <summary>
        /// Returns <c>true</c> if all of the items in <paramref name="source"/> match <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<bool> AllAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            foreach (var i in await source.Select(predicate).ToArrayAsync())
                if (!i)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns <c>true</c> if all of the items in <paramref name="source"/> match <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<bool> AllAsync<T>(this IEnumerable<Task<T>> source, Func<Task<T>, Task<bool>> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            foreach (var i in await source.Select(predicate).ToArrayAsync())
                if (!i)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns <c>true</c> if all of the items in <paramref name="source"/> match <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<bool> AllAsync<T>(this IEnumerable<Task<T>> source, Func<T, bool> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            foreach (var i in await source.Select(async j => predicate(await j)).ToArrayAsync())
                if (!i)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns <c>true</c> if all of the items in <paramref name="source"/> are <c>true</c>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<bool> AllAsync(this IEnumerable<Task<bool>> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            foreach (var i in await source.ToArrayAsync())
                if (!i)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns <c>true</c> if any of the items in <paramref name="source"/> match <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<bool> AnyAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);

            foreach (var i in await source.Select(predicate).ToArrayAsync())
                if (i)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns <c>true</c> if any of the items in <paramref name="source"/> match <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<bool> AnyAsync<T>(this IEnumerable<Task<T>> source, Func<Task<T>, Task<bool>> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);


            foreach (var i in await source.Select(predicate).ToArrayAsync())
                if (i)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns <c>true</c> if any of the items in <paramref name="source"/> are <c>true</c>.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<bool> AnyAsync(this IEnumerable<Task<bool>> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);


            foreach (var i in await source.ToArrayAsync())
                if (i)
                    return true;

            return false;
        }

        /// <summary>
        /// Executes <paramref name="action"/> for each item in the collection.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(action != null);

            return source.Select(action).WaitAllAsync();
        }

    }

}
