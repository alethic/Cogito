using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    public interface INancyRazorRenderContextFactory
    {

        /// <summary>
        /// Gets a <see cref="INancyRazorRenderContext"/> for the given <see cref="ViewLocationContext"/>.
        /// </summary>
        /// <param name="viewLocationContext"></param>
        /// <returns></returns>
        INancyRazorRenderContext GetRenderContext(ViewLocationContext viewLocationContext);

    }

}
