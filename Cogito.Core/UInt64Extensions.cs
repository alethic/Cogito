using System.Runtime.CompilerServices;

namespace Cogito
{

    /// <summary>
    /// Provides extensions against <see cref="ulong"/> values.
    /// </summary>
    public static class UInt64Extensions
    {

        /// <summary>
        /// Calculates the number of trailing zeros in the given unsigned long.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountLeadingZeros(this ulong n)
        {
#if NET5_0 || NETCOREAPP3_0
            return System.Numerics.BitOperations.LeadingZeroCount(n);
#else
            if (n == 0)
                return 64;

            var hi = (uint)(n >> 32);
            if (hi == 0)
                return 32 + UInt32Extensions.CountLeadingZeros((uint)n);

            return UInt32Extensions.CountLeadingZeros(hi);
#endif
        }

    }

}
