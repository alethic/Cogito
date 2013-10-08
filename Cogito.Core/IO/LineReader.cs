using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;

namespace Cogito.IO
{

    public class LineReader : TextReader
    {

        IEnumerator<string> iterator;

        string current;
        StringReader line;
        StringReader next;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public LineReader(IEnumerable<string> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            iterator = source.GetEnumerator();
        }

        /// <summary>
        /// Gets the next line to be processed.
        /// </summary>
        /// <returns></returns>
        StringReader Next()
        {
            var f = false;
            var s = "";
            while (next == null && !f)
                if (!(f = iterator.MoveNext()))
                    if ((s = iterator.Current) != null)
                        next = s != "" ? new StringReader(s) : new StringReader(Environment.NewLine);

            return next;
        }

        /// <summary>
        /// Gets the line to currently be processed.
        /// </summary>
        /// <returns></returns>
        StringReader Line()
        {
            // if we're null, attempt to fetch the next
            return line ?? (line = Next());
        }

        public override int Peek()
        {
            throw new NotImplementedException();
        }

        public override int Read()
        {
            throw new NotImplementedException();
        }

        public override Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public override string ReadLine()
        {
            throw new NotImplementedException();
        }

        public override Task<string> ReadLineAsync()
        {
            throw new NotImplementedException();
        }

        public override string ReadToEnd()
        {
            throw new NotImplementedException();
        }

        public override Task<string> ReadToEndAsync()
        {
            throw new NotImplementedException();
        }

    }

}
