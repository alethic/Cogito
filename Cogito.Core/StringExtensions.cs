using System;

namespace Cogito
{

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
        public static string TrimIfNotNull(this string self)
        {
            return self != null ? self.Trim() : null;
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

    }

}
