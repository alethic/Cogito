using System;
using System.Linq;
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
        /// <param name="segment"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, Uri segment)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));
            if (segment.IsAbsoluteUri)
                throw new ArgumentException("Segment URI must be relative.", nameof(segment));

            return Combine(self, new[] { segment });
        }

        /// <summary>
        /// Combines the given path with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="segments"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params Uri[] segments)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (segments == null)
                throw new ArgumentNullException(nameof(segments));
            if (segments.Any(i => i.IsAbsoluteUri))
                throw new ArgumentException("Segment URIs must all be relative.", nameof(segments));

            return Combine(self, segments.Select(i => i.ToString()).ToArray());
        }

        /// <summary>
        /// Combines the given path with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="segment"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, string segment)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (segment == null)
                throw new ArgumentNullException(nameof(segment));

            return Combine(self, new[] { segment });
        }

        /// <summary>
        /// Combines the given paths with the URI.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="segments"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, params string[] segments)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (segments == null)
                throw new ArgumentNullException(nameof(segments));

            // append missing final slash
            var b = new UriBuilder(self.IsAbsoluteUri ? self : new Uri("unknown:" + self.ToString()));

            // additional paths to append
            var l = new StringBuilder(b.Path.TrimEnd('/'));

            // append each additional path to the builder
            for (var i = 0; i < segments.Length; i++)
            {
                l.Append("/");
                l.Append(segments[i].Trim('/'));
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
