using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Composition;
using Cogito.Reflection;
using Cogito.Web;

using Nancy;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides <see cref="INancyRazorLayoutView"/>s.
    /// </summary>
    public class DefaultNancyRazorLayoutViewProvider : 
        INancyRazorLayoutViewProvider
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public DefaultNancyRazorLayoutViewProvider(
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
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorLayoutView>> GetLayoutViews(
            INancyRazorView body,
            string name)
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
            INancyRazorView body,
            string layout = null)
        {
            return GetLayoutViews(
                body,
                layout);
        }

    }

}
