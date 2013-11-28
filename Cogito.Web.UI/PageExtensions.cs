using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cogito.Linq;
using System.Threading.Tasks;
using System.Web.UI;

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
            return page.Controls
                .Cast<Control>()
                .Recurse(i => i.Controls.Cast<Control>())
                .OfType<ResourceManager>()
                .FirstOrDefault();
        }

    }

}
