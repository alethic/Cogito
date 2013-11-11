using System.ComponentModel.Composition;
using System.IO;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Component which is responsible for rendering a Nancy Razor view.
    /// </summary>
    [InheritedExport(typeof(INancyRazorViewRenderer))]
    public interface INancyRazorViewRenderer
    {

        /// <summary>
        /// Renders the view to the given output.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="writer"></param>
        void RenderView(
            NancyContext context,
            MediaRange requestedMediaRange,
            INancyRazorView view,
            object model,
            TextWriter writer);

    }

}
