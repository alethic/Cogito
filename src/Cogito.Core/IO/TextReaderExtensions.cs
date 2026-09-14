using System;
using System.Collections.Generic;
using System.IO;

namespace Cogito.IO
{

    /// <summary>
    /// Provides extension methods for working with <see cref="TextReader"/> instances.
    /// </summary>
    public static class TextReaderExtensions
    {

        /// <summary>
        /// Yields each line from the <see cref="TextReader"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(this TextReader self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            string line;
            while ((line = self.ReadLine()) != null)
                yield return line;
        }

    }

}
