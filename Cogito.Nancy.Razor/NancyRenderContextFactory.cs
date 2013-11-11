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
    [Export(typeof(IRenderContextFactory))]
    public class NancyRenderContextFactory :
        IRenderContextFactory
    {

        readonly ICompositionContext composition;
        readonly IViewCache viewCache;
        readonly IViewResolver viewResolver;
        readonly ITextResource textResource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="viewCache"></param>
        /// <param name="viewResolver"></param>
        /// <param name="textResource"></param>
        [ImportingConstructor]
        public NancyRenderContextFactory(
            ICompositionContext composition,
            IViewCache viewCache,
            IViewResolver viewResolver,
            ITextResource textResource)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(viewCache != null);
            Contract.Requires<ArgumentNullException>(viewResolver != null);
            Contract.Requires<ArgumentNullException>(textResource != null);

            this.composition = composition;
            this.viewCache = viewCache;
            this.viewResolver = viewResolver;
            this.textResource = textResource;
        }

        public IRenderContext GetRenderContext(ViewLocationContext viewLocationContext)
        {
            return new NancyRenderContext(composition, viewResolver, viewCache, textResource, viewLocationContext);
        }

    }

}
