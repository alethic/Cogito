using System.Collections.Generic;
using System.ComponentModel.Composition;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides <see cref="INancyRazorLayoutView"/>s for the given base view information.
    /// </summary>
    [InheritedExport]
    public interface INancyRazorLayoutViewProvider
    {

        /// <summary>
        /// Gets the layout view for the given information.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorLayoutView>> GetLayoutViews(
            NancyContext context,
            INancyRazorView body,
            string name = null);

    }

}
