using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Diagnostics.Contracts;
using System.Linq;
using Cogito.Collections;
using Cogito.Composition;
using Cogito.Composition.Web;
using Cogito.Reflection;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides <see cref="INancyRazorLayoutView"/>s.
    /// </summary>
    public class NancyRazorLayoutViewProvider : INancyRazorLayoutViewProvider
    {

        ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public NancyRazorLayoutViewProvider(
            [Import] ICompositionContext composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Gets all of the types implemented by the given view.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        IEnumerable<Type> GetViewTypes(INancyRazorView view)
        {
            return view.GetType()
                .GetAssignableTypes()
                .Where(i => typeof(INancyRazorView).IsAssignableFrom(i));
        }

        /// <summary>
        /// Gets the layout view for the associated model and body view.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorLayoutView>> GetLayoutViews(
            INancyRazorView body,
            string layout)
        {
            Contract.Requires<ArgumentNullException>(body != null);

            var scope = composition.GetOrBeginScope<IWebRequestScope>();
            if (scope == null)
                throw new NullReferenceException();

            // find any layout view that supports one of the types implemented by the body
            return GetViewTypes(body)
                .SelectMany(i => scope.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(INancyRazorLayoutView<>).MakeGenericType(i)),
                    AttributedModelServices.GetTypeIdentity(typeof(INancyRazorLayoutView<>).MakeGenericType(i)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.NonShared)))
                .Where(i => (string)i.Metadata.GetOrDefault("Layout") == layout)
                .Select(i => new
                {
                    Type = ReflectionModelServices.GetExportingMember(i.Definition).GetAccessors()[0] as Type,
                    Lazy = new Lazy<INancyRazorLayoutView>(() => (INancyRazorLayoutView)i.Value),
                })
                .Where(i => i.Type != null)
                .Select(i => new ViewReference<INancyRazorLayoutView>(i.Type, () => i.Lazy.Value));
        }

        /// <summary>
        /// Gets the layout view for the associated model and body view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="body"></param>
        /// <param name="model"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        public IEnumerable<ViewReference<INancyRazorLayoutView>> GetLayoutViews(
            NancyContext context,
            MediaRange requestedMediaRange,
            INancyRazorView body,
            string layout = null)
        {
            if (!requestedMediaRange.Matches("text/html"))
                return null;

            return GetLayoutViews(
                body,
                layout);
        }

    }

}
