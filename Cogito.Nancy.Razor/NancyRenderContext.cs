using System;
using System.Diagnostics.Contracts;
using Cogito.Composition;
using Nancy.Localization;
using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Customized <see cref="IRenderContext"/>.
    /// </summary>
    public class NancyRenderContext : DefaultRenderContext
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="viewResolver"></param>
        /// <param name="viewCache"></param>
        /// <param name="textResource"></param>
        /// <param name="viewLocationContext"></param>
        public NancyRenderContext(
            ICompositionContext composition,
            IViewResolver viewResolver,
            IViewCache viewCache,
            ITextResource textResource,
            ViewLocationContext viewLocationContext)
            : base(viewResolver, viewCache, textResource, viewLocationContext)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(viewResolver != null);
            Contract.Requires<ArgumentNullException>(viewCache != null);
            Contract.Requires<ArgumentNullException>(textResource != null);

            this.composition = composition;
        }

        /// <summary>
        /// Gets the current composition context.
        /// </summary>
        public ICompositionContext Composition
        {
            get { return composition; }
        }

    }

}
