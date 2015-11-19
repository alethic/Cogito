using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    public static class UriBuilderExtensions
    {

        /// <summary>
        /// Appends the given name and value as query arguments to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQuery(this UriBuilder b, string name, string value)
        {
            Contract.Requires<ArgumentNullException>(b != null);
            Contract.Requires<ArgumentNullException>(name != null);

            var p = Uri.EscapeDataString(name) + "=" + Uri.EscapeDataString(value ?? "");

            if (b.Query != null &&
                b.Query.Length > 1)
                b.Query = b.Query.Substring(1) + "&" + p;
            else
                b.Query = p;

            return b;
        }

    }

}
