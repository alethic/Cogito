using System;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;

using Cogito.Composition;

using Nancy.Localization;
using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    [Export(typeof(INancyRazorRenderContextFactory))]
    public class DefaultNancyRenderContextFactory :
        INancyRazorRenderContextFactory
    {

        readonly ICompositionContext composition;
        readonly IViewResolver viewResolver;
        readonly IViewCache viewCache;
        readonly INancyRazorPartialViewProvider partialViewProvider;
        readonly ITextResource textResource;
        INancyRazorViewRenderer viewRenderer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="viewCache"></param>
        /// <param name="viewResolver"></param>
        /// <param name="partialViewProvider"></param>
        /// <param name="viewRenderer"></param>
        /// <param name="textResource"></param>
        [ImportingConstructor]
        public DefaultNancyRenderContextFactory(
            ICompositionContext composition,
            IViewResolver viewResolver,
            IViewCache viewCache,
            INancyRazorPartialViewProvider partialViewProvider,
            ITextResource textResource)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(viewResolver != null);
            Contract.Requires<ArgumentNullException>(viewCache != null);
            Contract.Requires<ArgumentNullException>(partialViewProvider != null);
            Contract.Requires<ArgumentNullException>(textResource != null);

            this.composition = composition;
            this.viewResolver = viewResolver;
            this.viewCache = viewCache;
            this.partialViewProvider = partialViewProvider;
            this.textResource = textResource;
        }

        public INancyRazorRenderContext GetRenderContext(ViewLocationContext viewLocationContext)
        {
            this.viewRenderer = composition.GetExportedValue<INancyRazorViewRenderer>();

            return new NancyRazorRenderContext(
                composition,
                viewResolver,
                viewCache,
                textResource,
                partialViewProvider,
                viewRenderer,
                viewLocationContext);
        }

    }

}
