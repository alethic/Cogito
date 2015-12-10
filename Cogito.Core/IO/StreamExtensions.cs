using System.IO;
using System.Threading.Tasks;

namespace Cogito.IO
{

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
        public static void WriteAll(this Stream self, Stream source)
        {
            WriteAll(self, source, 1024);
        }

        /// <summary>
        /// Writes all data from the <paramref name="source"/> <see cref="Stream"/> into this <see cref="Stream"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <param name="blockSize"></param>
        public static void WriteAll(this Stream self, Stream source, int blockSize)
        {
            var buf = new byte[blockSize];
            int read = 0;
            while ((read = source.Read(buf, 0, blockSize)) > 0)
                self.Write(buf, 0, read);
        }

    }

}
