using System.Collections.Generic;
using System.ComponentModel.Composition;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides <see cref="INancyRazorView"/>s for a given model type.
    /// </summary>
    [InheritedExport(typeof(INancyRazorViewProvider))]
    public interface INancyRazorViewProvider
    {

        /// <summary>
        /// Gets the view for the requested media type and model.
        /// </summary>
        /// <param name="requestedMediaRange"></param>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorView>> GetViews(
            NancyContext context,
            MediaRange requestedMediaRange,
            object model);

    }

}
