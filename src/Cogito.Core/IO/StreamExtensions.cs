using System;
using System.IO;
using System.Threading.Tasks;

namespace Cogito.IO
{

    /// <summary>
    /// Provides various extension methods for working with <see cref="Stream"/> instances.
    /// </summary>
    public static class StreamExtensions
    {

        /// <summary>
        /// Reads all the data from the <see cref="Stream"/> and returns the resulting array.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(this Stream self)
        {
            var stm = new MemoryStream();
            self.CopyTo(stm);
            return stm.ToArray();
        }

        /// <summary>
        /// Reads all the data from the <see cref="Stream"/> and returns the resulting array.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async Task<byte[]> ReadAllBytesAsync(this Stream self)
        {
            var stm = new MemoryStream();
            await self.CopyToAsync(stm);
            return stm.ToArray();
        }

    }

}
