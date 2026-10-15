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

#if NETCOREAPP3_0_OR_GREATER
            var buffer = (Span<byte>)stackalloc byte[sizeof(long)];
            self.NextBytes(buffer);
            return BitConverter.ToInt64(buffer);
#else
            var buffer = new byte[sizeof(long)];
            self.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
#endif
        }


    }

}
