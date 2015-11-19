using System.IO;

using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Defines functionality available Nancy views during rendering.
    /// </summary>
    public interface INancyRazorRenderContext :
        IRenderContext
    {

        /// <summary>
        /// Renders the specified partial model with the given name and returns the result.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        void RenderPartial(object model, string name, TextWriter writer);

    }

}
