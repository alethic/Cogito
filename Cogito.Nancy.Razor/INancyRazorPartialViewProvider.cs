using System.Collections.Generic;
using System.ComponentModel.Composition;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides <see cref="INancyRazorView"/>s for a given model type.
    /// </summary>
    [InheritedExport(typeof(INancyRazorPartialViewProvider))]
    public interface INancyRazorPartialViewProvider
    {

        /// <summary>
        /// Gets the partial view for the requested media type and model.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorPartialView>> GetPartialViews(
            NancyContext context,
            object model);

    }

}
