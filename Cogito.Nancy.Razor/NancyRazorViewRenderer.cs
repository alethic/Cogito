using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Cogito.Collections;
using Cogito.Composition.Scoping;
using Cogito.Linq;
using Cogito.Web;
using Nancy;
using Nancy.Responses.Negotiation;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Cogito.Nancy.Razor
{

    public class NancyRazorViewRenderer :
        INancyRazorViewRenderer
    {

        readonly IRazorConfiguration configuration;
        readonly IRenderContextFactory contextFactory;
        readonly INancyRazorLayoutViewProvider layoutViewProvider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="contextFactory"></param>
        /// <param name="layoutViewProvider"></param>
        [ImportingConstructor]
        public NancyRazorViewRenderer(
            [Import] IRazorConfiguration configuration,
            [Import] IRenderContextFactory contextFactory,
            [Import] INancyRazorLayoutViewProvider layoutViewProvider)
        {
            Contract.Requires<ArgumentNullException>(configuration != null);
            Contract.Requires<ArgumentNullException>(contextFactory != null);
            Contract.Requires<ArgumentNullException>(layoutViewProvider != null);

            this.configuration = configuration;
            this.contextFactory = contextFactory;
            this.layoutViewProvider = layoutViewProvider;
        }

        /// <summary>
        /// Renders the given view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="writer"></param>
        public void RenderView(
            NancyContext context,
            MediaRange requestedMediaRange,
            INancyRazorView view,
            object model,
            TextWriter writer)
        {
            // begin rendering as partial
            RenderView(
                context,
                requestedMediaRange,
                view,
                model,
                writer,
                null,
                null);
        }

        /// <summary>
        /// Implements the rendering of the view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="writer"></param>
        /// <param name="except"></param>
        /// <param name="body"></param>
        /// <param name="sectionContents"></param>
        void RenderView(
            NancyContext context,
            MediaRange requestedMediaRange,
            INancyRazorView view,
            object model,
            TextWriter writer,
            IEnumerable<Type> except = null,
            string body = null,
            IDictionary<string, string> sectionContents = null)
        {

            if (except == null)
                except = Enumerable.Empty<Type>();

            if (!requestedMediaRange.Matches("text/html"))
                return;

            // location of the view
            var locationContext = new ViewLocationContext()
            {
                Context = context,
                ModuleName = context.NegotiationContext.ModuleName,
                ModulePath = context.NegotiationContext.ModulePath,
            };

            // execute the view
            try
            {
                var engine = new RazorViewEngine(configuration);
                var render = contextFactory.GetRenderContext(locationContext);
                view.Initialize(engine, render, model);
                view.ExecuteView(body, sectionContents);
            }
            catch (ViewRenderException e)
            {
                // attempt to execute normally, which should give us the real exception
                var engine = new RazorViewEngine(configuration);
                var render = contextFactory.GetRenderContext(locationContext);
                view.Initialize(engine, render, model);
                dynamic d = view;
                d.Execute();

                throw e;
            }

            // if we're not a shell, we might have a layout
            // obtain layout if available
            var layout = layoutViewProvider.GetLayoutViews(
                    context,
                    requestedMediaRange,
                    view,
                    null)
                .Where(i => !except.Contains(i.ViewType))
                .Select(i => i)
                .FirstOrDefault();
            if (layout != null)
            {
                // layout found, recurse
                RenderView(
                    context,
                    requestedMediaRange,
                    layout.View,
                    model,
                    writer,
                    except.Prepend(layout.ViewType),
                    view.Body,
                    new MergedDictionary<string, string>(sectionContents, view.SectionContents));

                // if we recursed, we do not write the body
                return;
            }

            // write out final body
            writer.Write(view.Body);
        }

    }


}
