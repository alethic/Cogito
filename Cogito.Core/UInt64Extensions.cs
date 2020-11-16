#if NET5_0 || NETCOREAPP3_0
using System.Runtime.Intrinsics.X86;
#endif

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
        public static int CountLeadingZeros(this ulong n)
        {
            if (n == 0)
                return 64;

#if NET5_0 || NETCOREAPP3_0
            if (Lzcnt.X64.IsSupported)
                return (int)Lzcnt.X64.LeadingZeroCount(n);
#endif

            var v = n;
            var t = 0;

            while (v != 0)
            {
                v >>= 1;
                t++;
            }

            return 64 - t;
        }

    }

}
