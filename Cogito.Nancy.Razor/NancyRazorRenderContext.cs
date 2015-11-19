using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

using Cogito.Composition;

using Nancy.Localization;
using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Customized <see cref="IRenderContext"/>.
    /// </summary>
    public class NancyRazorRenderContext : 
        DefaultRenderContext,
        INancyRazorRenderContext
    {

        readonly ICompositionContext composition;
        readonly INancyRazorPartialViewProvider partialViewProvider;
        readonly INancyRazorViewRenderer viewRenderer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        /// <param name="viewResolver"></param>
        /// <param name="viewCache"></param>
        /// <param name="textResource"></param>
        /// <param name="partialViewProvider"></param>
        /// <param name="viewRenderer"></param>
        /// <param name="viewLocationContext"></param>
        public NancyRazorRenderContext(
            ICompositionContext composition,
            IViewResolver viewResolver,
            IViewCache viewCache,
            ITextResource textResource,
            INancyRazorPartialViewProvider partialViewProvider,
            INancyRazorViewRenderer viewRenderer,
            ViewLocationContext viewLocationContext)
            : base(viewResolver, viewCache, textResource, viewLocationContext)
        {
            Contract.Requires<ArgumentNullException>(composition != null);
            Contract.Requires<ArgumentNullException>(viewResolver != null);
            Contract.Requires<ArgumentNullException>(viewCache != null);
            Contract.Requires<ArgumentNullException>(textResource != null);
            Contract.Requires<ArgumentNullException>(partialViewProvider != null);
            Contract.Requires<ArgumentNullException>(viewRenderer != null);
            Contract.Requires<ArgumentNullException>(viewLocationContext != null);

            this.composition = composition;
            this.partialViewProvider = partialViewProvider;
            this.viewRenderer = viewRenderer;
        }

        /// <summary>
        /// Gets the current composition context.
        /// </summary>
        public ICompositionContext Composition
        {
            get { return composition; }
        }

        /// <summary>
        /// Renders the given partial model with the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void RenderPartial(object model, string name, TextWriter writer)
        {
            // obtain view
            var view = partialViewProvider.GetPartialViews(Context, (object)model)
                .FirstOrDefault();
            if (view == null)
                throw new ViewNotFoundException(model.GetType().Name);

            viewRenderer.RenderView(Context, view.View, model, writer);
        }

    }

}
