using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

using Cogito.Collections;
using Cogito.Linq;

using Nancy;
using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    public class DefaultNancyRazorViewRenderer :
        INancyRazorViewRenderer
    {

        readonly INancyRazorRenderContextFactory contextFactory;
        readonly INancyRazorLayoutViewProvider layoutViewProvider;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="contextFactory"></param>
        /// <param name="layoutViewProvider"></param>
        [ImportingConstructor]
        public DefaultNancyRazorViewRenderer(
            [Import] INancyRazorRenderContextFactory contextFactory,
            [Import] INancyRazorLayoutViewProvider layoutViewProvider)
        {
            Contract.Requires<ArgumentNullException>(contextFactory != null);
            Contract.Requires<ArgumentNullException>(layoutViewProvider != null);

            this.contextFactory = contextFactory;
            this.layoutViewProvider = layoutViewProvider;
        }

        /// <summary>
        /// Renders the given view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="writer"></param>
        public void RenderView(
            NancyContext context,
            INancyRazorView view,
            object model,
            TextWriter writer)
        {
            // begin rendering as partial
            RenderView(
                context,
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
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <param name="writer"></param>
        /// <param name="except"></param>
        /// <param name="body"></param>
        /// <param name="sectionContents"></param>
        void RenderView(
            NancyContext context,
            INancyRazorView view,
            object model,
            TextWriter writer,
            IEnumerable<Type> except = null,
            string body = null,
            IDictionary<string, string> sectionContents = null)
        {

            if (except == null)
                except = Enumerable.Empty<Type>();

            // location of the view
            var locationContext = new ViewLocationContext()
            {
                Context = context,
                ModuleName = context.NegotiationContext.ModuleName,
                ModulePath = context.NegotiationContext.ModulePath,
            };

            // execute the view
            var render = contextFactory.GetRenderContext(locationContext);
            view.Initialize(render, model);
            view.ExecuteView(body, sectionContents);

            // we might have a layout
            var layout = layoutViewProvider.GetLayoutViews(
                    context,
                    view,
                    view.Layout)
                .Where(i => !except.Contains(i.ViewType))
                .Select(i => i)
                .FirstOrDefault();

            if (layout != null)
            {
                // layout found, recurse
                RenderView(
                    context,
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
