using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.ReflectionModel;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Collections;
using Cogito.Composition;
using Cogito.Composition.Scoping;
using Cogito.Reflection;
using Cogito.Web;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public class DefaultNancyRazorViewProvider :
        INancyRazorViewProvider
    {

        readonly ITypeResolver typeResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="typeResolver"></param>
        [ImportingConstructor]
        public DefaultNancyRazorViewProvider(
            [Import] ITypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
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
        IEnumerable<ViewReference<INancyRazorView>> GetViews(
            object model,
            string name)
        {
            Contract.Requires<ArgumentNullException>(model != null);

            var scope = typeResolver.Resolve<IScopeTypeResolver>().Resolve<IExportResolver, IWebRequestScope>();
            if (scope == null)
                throw new NullReferenceException();

            // find any layout view that supports one of the types implemented by the body
            return GetModelTypes(model)
                .SelectMany(i => scope.ResolveMany(typeof(INancyRazorView<>).MakeGenericType(i)))

                // extract name metadata
                .Select(i => new { Name = (string)i.Metadata.GetOrDefault("Name"), Export = i })

                // match against specified name
                .Select(i => new { Match = name == i.Name ? true : false, Name = i.Name, Export = i.Export })

                // if name is specified on both ends, exact match is required; otherwise not
                .Where(i => name != null && i.Name != null ? i.Match : true)

                // views that match take priority
                .OrderBy(i => i.Match ? 0 : 1)

                // extract export into new wrapped lazy vaule
                .Select(i => new
                {
                    Type = ReflectionModelServices.GetExportingMember(i.Export.Definition).GetAccessors()[0] as Type,
                    Lazy = new Lazy<INancyRazorView>(() => (INancyRazorView)i.Export.Value),
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
            object model,
            string name)
        {
            if (!requestedMediaRange.Matches("text/html"))
                return null;

            return GetViews(model, name);
        }

    }

}
