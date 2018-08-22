using System;
using System.Text;

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
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Combine(self, new[] { path });
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
            if (paths == null)
                throw new ArgumentNullException(nameof(paths));

            // append missing final slash
            var b = new UriBuilder(self.IsAbsoluteUri ? self : new Uri("unknown:" + self.ToString()));

            // additional paths to append
            var l = new StringBuilder(b.Path.TrimEnd('/'));

            // append each additional path to the builder
            for (var i = 0; i < paths.Length; i++)
            {
                l.Append("/");
                l.Append(paths[i].Trim('/'));
            }

            // append new path to builder
            b.Path = l.ToString();

            // originally absolute, builder is fine
            if (self.IsAbsoluteUri)
                return b.Uri;
            else
                return new Uri(b.Uri.PathAndQuery, UriKind.Relative);
        }

    }

}
