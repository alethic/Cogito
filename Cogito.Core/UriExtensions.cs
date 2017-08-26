using System;

namespace Cogito
{

    /// <summary>
    /// Various extension methods for working with <see cref="Uri"/> instances.
    /// </summary>
    public static class UriExtensions
    {

        /// <summary>
        /// Combines the given path with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, string path)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (!self.IsAbsoluteUri)
                throw new ArgumentOutOfRangeException(nameof(self));
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            // append missing final slash
            var b = new UriBuilder(self);
            if (!b.Path.EndsWith("/"))
                b.Path += "/";

            // append new path element
            b.Path += path;

            // generate from relative path
            return b.Uri;
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params string[] paths)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (!self.IsAbsoluteUri)
                throw new ArgumentOutOfRangeException(nameof(self));
            if (paths == null)
                throw new ArgumentNullException(nameof(paths));

            foreach (var p in paths)
                self = self.Combine(p);

            return self;
        }

    }

}
