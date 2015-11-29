using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cogito.Threading
{

    public static class TaskEnumerableExtensions
    {

        public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> source)
        {
            return Task.WhenAll<T>(source);
        }

        public static Task WhenAll(this IEnumerable<Task> source)
        {
            return Task.WhenAll(source);
        }

        public static Task<TResult[]> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            return source.Select(selector).WhenAll();
        }

        public static Task<TResult[]> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<Task<TResult>>> selector)
        {
            return source.SelectMany(selector).WhenAll();
        }

        public static Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
        {
            return source.Select(action).WhenAll();
        }

    }

}
