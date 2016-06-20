using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Collections
{

    /// <summary>
    /// Provides extension methods for working with <see cref="NameValueCollection"/> instances.
    /// </summary>
    public static class NameValueCollectionExtensions
    {

        /// <summary>
        /// Converts the collection into a dictionary.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return source.Cast<string>().ToDictionary(i => i, i => source[i]);
        }

    }

}
