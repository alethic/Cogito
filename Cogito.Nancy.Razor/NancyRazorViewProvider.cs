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
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public class NancyRazorViewProvider : INancyRazorViewProvider
    {

        ICompositionContext composition;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="composition"></param>
        [ImportingConstructor]
        public NancyRazorViewProvider(
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
        /// Gets the view for the associated model type.
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        IEnumerable<ViewReference<INancyRazorView>> GetViews(object model)
        {
            Contract.Requires<ArgumentNullException>(model != null);

            var scope = composition.GetOrBeginScope<IRequestScope>();
            if (scope == null)
                throw new NullReferenceException();

            // find any layout view that supports one of the types implemented by the body
            return GetModelTypes(model)
                .SelectMany(i => scope.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(INancyRazorView<>).MakeGenericType(i)),
                    AttributedModelServices.GetTypeIdentity(typeof(INancyRazorView<>).MakeGenericType(i)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    false,
                    CreationPolicy.NonShared)))
                .Select(i => new
                {
                    Type = ReflectionModelServices.GetExportingMember(i.Definition).GetAccessors()[0] as Type,
                    Lazy = new Lazy<INancyRazorView>(() => (INancyRazorView)i.Value),
                })
                .Where(i => i.Type != null)
                .Select(i => new ViewReference<INancyRazorView>(i.Type, () => i.Lazy.Value));
        }

        /// <summary>
        /// Gets the view for the associated information.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestedMediaRange"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<ViewReference<INancyRazorView>> GetViews(
            NancyContext context,
            MediaRange requestedMediaRange,
            object model)
        {
            if (!requestedMediaRange.Matches("text/html"))
                return null;

            return GetViews(model);
        }

    }

}
