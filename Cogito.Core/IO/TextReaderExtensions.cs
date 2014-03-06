using System.Collections.Generic;
using System.IO;

namespace Cogito.IO
{

    public static class TextReaderExtensions
    {

        /// <summary>
        /// Yields each line from the <see cref="TextReader"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(this TextReader self)
        {
            string line;
            while ((line = self.ReadLine()) != null)
                yield return line;
        }

    }

}
