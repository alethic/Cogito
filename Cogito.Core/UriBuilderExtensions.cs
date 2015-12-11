using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    public static class UriBuilderExtensions
    {

        /// <summary>
        /// Appends the given name and value as query arguments to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQuery(this UriBuilder self, string name, string value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);

            var p = Uri.EscapeDataString(name) + "=" + Uri.EscapeDataString(value ?? "");

            if (self.Query != null &&
                self.Query.Length > 1)
                self.Query = self.Query.Substring(1) + "&" + p;
            else
                self.Query = p;

            return self;
        }

        /// <summary>
        /// Appends the given name and value query arguments to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UriBuilder AppendQuery(this UriBuilder self, string name, object value)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(name != null);

            return AppendQuery(self, name, value.ToString());
        }

    }

}
