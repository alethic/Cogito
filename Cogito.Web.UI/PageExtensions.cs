using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.UI;

using Cogito.Linq;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides extesion methods for <see cref="Page"/> instances.
    /// </summary>
    public static class PageExtensions
    {

        /// <summary>
        /// Gets the configured <see cref="ResourceManager"/> on the specified page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ResourceManager GetResourceManager(this Page page)
        {
            Contract.Requires<ArgumentNullException>(page != null);

            return page.Controls
                .Cast<Control>()
                .Recurse(i => i.Controls.Cast<Control>())
                .OfType<ResourceManager>()
                .FirstOrDefault();
        }

    }

}
