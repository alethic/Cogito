using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    /// <summary>
    /// Various extensions for working with strings.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Returns <c>null</c> if the <see cref="String"/> is <c>null</c> or empty.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string NullIfEmpty(this string self)
        {
            return !string.IsNullOrEmpty(self) ? self : null;
        }

        /// <summary>
        /// Returns <c>null</c> if the <see cref="String"/> is <c>null</c> or empty.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string NullIfWhitespace(this string self)
        {
            return !string.IsNullOrWhiteSpace(self) ? self : null;
        }

        /// <summary>
        /// Returns an empty string if the given string is <c>null</c>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string EmptyIfNull(this string self)
        {
            return self ?? "";
        }

        /// <summary>
        /// Returns the trimmed version of the string, or <c>null</c> if the string is <c>null</c>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string TrimIfNotNull(this string self, params char[] trimChars)
        {
            return self != null ? self.Trim(trimChars) : null;
        }

        /// <summary>
        /// Returns the trimmed version of the string, or <c>null</c> if the string is <c>null</c>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string TrimEndIfNotNull(this string self, params char[] trimChars)
        {
            return self != null ? self.TrimEnd(trimChars) : null;
        }

        /// <summary>
        /// Returns the trimmed version of the string, or <c>null</c> if the string is <c>null</c>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string TrimStartIfNotNull(this string self, params char[] trimChars)
        {
            return self != null ? self.TrimStart(trimChars) : null;
        }

        /// <summary>
        /// Returns the trimmed version of the string if it is not empty, otherwise returns <c>null</c>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string TrimOrNull(this string self)
        {
            return self == null ? null : (self = self.Trim()) == "" ? null : self;
        }

        /// <summary>
        /// Removes the end portion of the string that matches <paramref name="value"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveEnd(this string self, string value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(value != null);

            var idx = self.LastIndexOf(value);
            if (idx > -1)
                return self.Remove(idx);

            return self;
        }

    }

}
