using System.Collections.Generic;
using System.Text;

namespace Cogito.Text
{

    public static class StringBuilderExtensions
    {

        /// <summary>
        /// Appends each of the strings in <paramref name="source"/> to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringBuilder AppendMany<T>(this StringBuilder self, IEnumerable<T> source)
        {
            foreach (var i in source)
                self.Append(i);
            return self;
        }

        /// <summary>
        /// Appends a line with each of the strings in <paramref name="source"/> to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringBuilder AppendManyLines<T>(this StringBuilder self, IEnumerable<T> source)
        {
            foreach (var i in source)
                self.Append(i).AppendLine();
            return self;
        }

        /// <summary>
        /// Appends a line with each of the strings in <paramref name="source"/> to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringBuilder AppendManyLines<T>(this StringBuilder self, IEnumerable<T> source, string prefix = null, string suffix = null)
        {
            foreach (var i in source)
            {
                if (prefix != null)
                    self.Append(prefix);
                self.Append(i);
                if (suffix != null)
                    self.Append(suffix);
                self.AppendLine();
            }
            return self;
        }

        /// <summary>
        /// Appends each item in <paramref name="source"/> to the <see cref="StringBuilder"/>, followed by a new line.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringBuilder AppendFullLine<T>(this StringBuilder self, IEnumerable<T> source)
        {
            foreach (var i in source)
                self.Append(i);
            self.AppendLine();
            return self;
        }

        /// <summary>
        /// Appends each nested enumerator in <paramref name="source"/> as a single line.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StringBuilder AppendManyFullLines<T>(this StringBuilder self, IEnumerable<IEnumerable<T>> source)
        {
            foreach (var i in source)
                AppendFullLine(self, i);
            return self;
        }

        /// <summary>
        /// Appends each nested enumerable in <paramref name="source"/> as a single line prefixed by <paramref
        /// name="prefix"/> and suffixed by <paramref name="suffix"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="source"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static StringBuilder AppendManyFullLines<T>(this StringBuilder self, IEnumerable<IEnumerable<T>> source, string prefix = null, string suffix = null)
        {
            foreach (var i in source)
            {
                if (prefix != null)
                    self.Append(prefix);
                AppendMany(self, i);
                if (suffix != null)
                    self.Append(suffix);
                self.AppendLine();
            }

            return self;
        }

    }

}
