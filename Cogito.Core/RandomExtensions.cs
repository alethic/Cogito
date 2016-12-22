using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    /// <summary>
    /// Provides extension methods for working with <see cref="Random"/> instances.
    /// </summary>
    public static class RandomExtensions
    {

        /// <summary>
        /// Gets the next random <see cref="Int64"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long NextInt64(this Random self)
        {
            var buffer = new byte[8];
            self.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// Gets the next random <see cref="Int64"/> within the specified range.
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static long NextInt64(this Random rnd, long min, long max)
        {
            EnsureMinLEQMax(ref min, ref max);

            var numbersInRange = unchecked(max - min + 1);
            if (numbersInRange < 0)
                throw new ArgumentException("Size of range between min and max must be less than or equal to Int64.MaxValue");

            var randomOffset = NextInt64(rnd);
            if (IsModuloBiased(randomOffset, numbersInRange))
                return NextInt64(rnd, min, max); // Try again
            else
                return min + PositiveModuloOrZero(randomOffset, numbersInRange);
        }

        static bool IsModuloBiased(long randomOffset, long numbersInRange)
        {
            var greatestCompleteRange = numbersInRange * (long.MaxValue / numbersInRange);
            return randomOffset > greatestCompleteRange;
        }

        static long PositiveModuloOrZero(long dividend, long divisor)
        {
            Contract.Requires(divisor != 0L);

            long mod;
            System.Math.DivRem(dividend, divisor, out mod);
            if (mod < 0)
                mod += divisor;
            return mod;
        }

        static void EnsureMinLEQMax(ref long min, ref long max)
        {
            if (min <= max)
                return;

            var temp = min;
            min = max;
            max = temp;
        }

    }

}
