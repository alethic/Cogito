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
    /// Provides <see cref="INancyRazorPartialView"/>s.
    /// </summary>
    public class DefaultNancyRazorPartialViewProvider : 
        INancyRazorPartialViewProvider
    {

        readonly ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public DefaultNancyRazorPartialViewProvider(
            [Import] ICompositionContext composition)
        {
            this.composition = composition;
        }

        /// <summary>
        /// Gets the appropriate type of the given model.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerable<Type> GetModelTypes(object model)
        {
            return model.GetType()
                .GetAssignableTypes();
        }

        /// <summary>
        /// Gets the partial view for the associated model and body view.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorPartialView>> GetPartialViews(
            object model)
        {
            Contract.Requires<ArgumentNullException>(model != null);

            var scope = composition.GetOrBeginScope<IWebRequestScope>();
            if (scope == null)
                throw new NullReferenceException();

            // find any Partial view that supports one of the types implemented by the body
            return GetModelTypes(model)
                .SelectMany(i => scope.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(INancyRazorPartialView<>).MakeGenericType(i)),
                    AttributedModelServices.GetTypeIdentity(typeof(INancyRazorPartialView<>).MakeGenericType(i)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.NonShared)))
                .Select(i => new
                {
                    Type = ReflectionModelServices.GetExportingMember(i.Definition).GetAccessors()[0] as Type,
                    Lazy = new Lazy<INancyRazorPartialView>(() => (INancyRazorPartialView)i.Value),
                })
                .Where(i => i.Type != null)
                .Select(i => new ViewReference<INancyRazorPartialView>(i.Type, () => i.Lazy.Value));
        }

        /// <summary>
        /// Gets the Partial view for the associated model and body view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="body"></param>
        /// <param name="model"></param>
        /// <param name="Partial"></param>
        /// <returns></returns>
        public IEnumerable<ViewReference<INancyRazorPartialView>> GetPartialViews(
            NancyContext context,
            object model)
        {
            return GetPartialViews(model);
        }

    }

}
