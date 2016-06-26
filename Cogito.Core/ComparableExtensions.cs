using System;

namespace Cogito
{


    /// <summary>
    /// Provides various extension methods for <see cref="IComparable"/> objects.
    /// </summary>
    public static class ComparableExtensions
    {

        /// <summary>
        /// Returns <c>true</c> if this instance is between the two instances, or equal to either.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool Between<T>(this T self, T left, T right)
            where T : IComparable<T>
        {
            return Between(self, left, right, IntervalMode.Open);
        }

        /// <summary>
        /// Returns <c>true</c> if this instance is between the two instances given the <see cref="IntervalMode"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool Between<T>(this T self, T left, T right, IntervalMode mode = IntervalMode.Open)
            where T : IComparable<T>
        {
            return Between(self, left, right, mode == IntervalMode.Open || mode == IntervalMode.SemiOpenLeft, mode == IntervalMode.Open || mode == IntervalMode.SemiOpenRight);
        }

        /// <summary>
        /// Returns <c>true</c> if this instance is between the two instances.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static bool Between<T>(this T self, T left, T right, bool openLeft = false, bool openRight = false)
            where T : IComparable<T>
        {
            var l = openLeft ? self.CompareTo(left) >= 0 : self.CompareTo(left) > 0;
            var r = openRight ? self.CompareTo(right) <= 0 : self.CompareTo(right) < 0;
            return l && r;
        }

    }

}
