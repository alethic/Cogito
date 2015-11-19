using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    public static class UriExtensions
    {

        /// <summary>
        /// Navigates the absolute URL to the specified relative path.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Uri Combine(this Uri self, string path)
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentOutOfRangeException>(self.IsAbsoluteUri);
            Contract.Requires<ArgumentNullException>(path != null);

            if (!self.ToString().EndsWith("/"))
                self = new Uri(self.ToString() + "/");

            return new Uri(self, path);
        }

    }

}
