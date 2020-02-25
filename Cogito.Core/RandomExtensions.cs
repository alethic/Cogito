using System;

namespace Cogito
{

    /// <summary>
    /// Provides extension methods for working with <see cref="Random"/> instances.
    /// </summary>
    public static class RandomExtensions
    {

        /// <summary>
        /// Gets the next random <see cref="long"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long NextInt64(this Random self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

#if NETSTANDARD2_1 || NETCOREAPP3_0
            var buffer = (Span<byte>)stackalloc byte[sizeof(long)];
            self.NextBytes(buffer);
            return BitConverter.ToInt64(buffer);
#else
            var buffer = new byte[sizeof(long)];
            self.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
#endif
        }

#if !NETSTANDARD1_6

        /// <summary>
        /// Gets the next random <see cref="long"/> within the specified range.
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static long NextInt64(this Random rnd, long min, long max)
        {
            if (rnd == null)
                throw new ArgumentNullException(nameof(rnd));

            EnsureMinLEqMax(ref min, ref max);

            var numbersInRange = unchecked(max - min + 1);
            if (numbersInRange < 0)
                throw new ArgumentException("Size of range between min and max must be less than or equal to Int64.MaxValue");

            var randomOffset = NextInt64(rnd);
            if (IsModuloBiased(randomOffset, numbersInRange))
                return NextInt64(rnd, min, max);
            else
                return min + PositiveModuloOrZero(randomOffset, numbersInRange);
        }

        static bool IsModuloBiased(long randomOffset, long numbersInRange)
        {
            return randomOffset > numbersInRange * (long.MaxValue / numbersInRange);
        }

        static long PositiveModuloOrZero(long dividend, long divisor)
        {
            System.Math.DivRem(dividend, divisor, out long mod);

            if (mod < 0)
                mod += divisor;

            return mod;
        }

        static void EnsureMinLEqMax(ref long min, ref long max)
        {
            if (min <= max)
                return;

            var temp = min;
            min = max;
            max = temp;
        }

#endif

    }

}
