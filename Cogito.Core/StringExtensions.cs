using System;

namespace Cogito
{

    /// <summary>
    /// Various extensions for working with strings.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Parses the <see cref="string"/> as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TimeSpan ParseTimeSpan(this string self)
        {
            return TimeSpan.Parse(self);
        }

        /// <summary>
        /// Attempts to parse the <see cref="string"/> as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TimeSpan? TryParseTimeSpan(this string self)
        {
            return self != null && TimeSpan.TryParse(self, out var r) ? (TimeSpan?)r : null;
        }

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
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var idx = self.LastIndexOf(value);
            if (idx > -1)
                return self.Remove(idx);

            return self;
        }

        /// <summary>
        /// Gets the leftmost portion of the string up to the count.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Left(this string self, int count)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            return self.Substring(0, System.Math.Min(self.Length, count));
        }

        /// <summary>
        /// Parses the string as an integer.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ParseInt32(this string self)
        {
            return int.Parse(self ?? throw new ArgumentNullException(nameof(self)));
        }

        /// <summary>
        /// Attempts to parse the string as an integer.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int? TryParseInt32(this string self)
        {
            int i;
            return int.TryParse(self, out i) ? (int?)i : null;
        }

        /// <summary>
        /// Parses the string as a long.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long ParseInt64(this string self)
        {
            return long.Parse(self ?? throw new ArgumentNullException(nameof(self)));
        }

        /// <summary>
        /// Attempts to parse the string as a long.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long? TryParseInt64(this string self)
        {
            long i;
            return long.TryParse(self, out i) ? (long?)i : null;
        }

        /// <summary>
        /// Parses the string as a <see cref="Guid"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Guid ParseGuid(this string self)
        {
            return Guid.Parse(self ?? throw new ArgumentNullException(nameof(self)));
        }

        /// <summary>
        /// Attempts to parse the <see cref="string"/> as a <see cref="Guid"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Guid? TryParseGuid(this string self)
        {
            Guid i;
            return Guid.TryParse(self, out i) ? (Guid?)i : null;
        }

    }

}
