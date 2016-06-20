using System;
using System.Diagnostics.Contracts;
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

        /// <summary>
        /// Writes all data from the <paramref name="source"/> <see cref="Stream"/> into this <see cref="Stream"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <param name="bufferSize"></param>
        public static void WriteFrom(this Stream self, Stream source, int bufferSize)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(source != null);

            source.CopyTo(self, bufferSize);
        }

        /// <summary>
        /// Writes all data from the <paramref name="source"/> <see cref="Stream"/> into this <see cref="Stream"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        public static void WriteFrom(this Stream self, Stream source)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(source != null);

            source.CopyTo(self);
        }

        /// <summary>
        /// Writes all data from the <paramref name="source"/> <see cref="Stream"/> into this <see cref="Stream"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <param name="bufferSize"></param>
        public static Task WriteFromAsync(this Stream self, Stream source, int bufferSize)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(source != null);

            return source.CopyToAsync(self, bufferSize);
        }

        /// <summary>
        /// Writes all data from the <paramref name="source"/> <see cref="Stream"/> into this <see cref="Stream"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        public static Task WriteFromAsync(this Stream self, Stream source)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(source != null);

            return source.CopyToAsync(self);
        }

    }

}
