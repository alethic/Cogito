#if !NETSTANDARD1_6

using System;
using System.Linq;
using System.Runtime.Caching;

namespace Cogito.Runtime.Caching
{

    /// <summary>
    /// Provides extension methods for working with <see cref="ObjectCache"/> instances.
    /// </summary>
    public static class ObjectCacheExtensions
    {

        /// <summary>
        /// Either creates the item in the cache, or returns the existing item in the cache.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, string key, Func<T> func, CacheItemPolicy policy)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            lock (self)
            {
                var i = (T)self.Get(key);
                if (i == null)
                    self.Add(key, i = func(), policy);

                return i;
            }
        }

        /// <summary>
        /// Either invokes the delegate given by <paramref name="func"/>, or returns the result of a previous
        /// invocation with the given cache key and cache policy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, string key, Func<T> func, DateTimeOffset absoluteExpiration, TimeSpan slidingExpiration)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return self.GetOrCreate(key, func, new CacheItemPolicy()
            {
                AbsoluteExpiration = absoluteExpiration,
                SlidingExpiration = slidingExpiration,
            });
        }

        /// <summary>
        /// Either invokes the delegate given by <paramref name="func"/>, or returns the result of a previous
        /// invocation with the given cache key and cache policy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, string key, Func<T> func, DateTimeOffset absoluteExpiration)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return GetOrCreate(self, key, func, absoluteExpiration, ObjectCache.NoSlidingExpiration);
        }

        /// <summary>
        /// Either invokes the delegate given by <paramref name="func"/>, or returns the result of a previous
        /// invocation with the given cache key and cache policy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, string key, Func<T> func, TimeSpan slidingExpiration)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return GetOrCreate(self, key, func, ObjectCache.InfiniteAbsoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// Either invokes the delegate given by <paramref name="func"/>, or returns the result of a previous
        /// invocation with the given cache key and cache policy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="func"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, Func<T> func, DateTimeOffset absoluteExpiration, params object[] keys)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));
            if (keys.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(keys));

            // generate unique key for keys
            var k = string.Join("##", Enumerable.Empty<object>()
                .Concat(keys.Select(i => i.ToString()))
                .Concat(keys.Select(i => (object)i.GetHashCode())));

            return GetOrCreate(self, k, func, absoluteExpiration);
        }

        /// <summary>
        /// Either invokes the delegate given by <paramref name="func"/>, or returns the result of a previous
        /// invocation with the given cache key and cache policy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="func"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static T GetOrCreate<T>(this ObjectCache self, Func<T> func, TimeSpan slidingExpiration, params object[] keys)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            // generate unique key for keys
            var k = string.Join("##", Enumerable.Empty<object>()
                .Concat(keys.Select(i => i.ToString()))
                .Concat(keys.Select(i => (object)i.GetHashCode())));

            return GetOrCreate(self, k, func, slidingExpiration);
        }

    }

}

#endif