using System;

namespace Cogito
{

    /// <summary>
    /// Various extension methods for <see cref="TimeSpan"/> instances.
    /// </summary>
    public static class TimeSpanExtensions
    {

        /// <summary>
        /// Returns the largest <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static TimeSpan Max(this TimeSpan value1, TimeSpan value2)
        {
            return TimeSpan.FromTicks(System.Math.Max(value1.Ticks, value2.Ticks));
        }

        /// <summary>
        /// Returns the smallest <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static TimeSpan Min(this TimeSpan value1, TimeSpan value2)
        {
            return TimeSpan.FromTicks(System.Math.Min(value1.Ticks, value2.Ticks));
        }

    }

}
