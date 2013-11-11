using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Web.Razor;

using Cogito.Web.Razor;

using Nancy;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides Nancy Razor View parts from a set of Razor template streams.
    /// </summary>
    public class NancyRazorViewCatalog : TypeCatalog
    {

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static IEnumerable<Type> GetOrBuildViewTypes(IEnumerable<RazorViewTemplate> templates)
        {
            Contract.Requires<ArgumentNullException>(templates != null);
            return templates.Select(i => GetOrBuildViewType(i));
        }

        /// <summary>
        /// Gets or builds the given view type from the given stream.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        static Type GetOrBuildViewType(RazorViewTemplate template)
        {
            Contract.Requires<ArgumentNullException>(template.Name != null);
            Contract.Requires<ArgumentNullException>(template.Stream != null);
            Contract.Requires(typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly != null);

            // generate new template class type
            var type = RazorTemplateBuilder.GetOrBuildType(
                () => { template.Stream.Position = 0; return new StreamReader(template.Stream); },
                defaultNamespace: template.Namespace,
                defaultClassName: template.Name,
                defaultBaseClass: typeof(NancyRazorViewBase),
                innerTemplateType: typeof(global::Nancy.ViewEngines.Razor.HelperResult),
                referencedAssemblies: template.ReferencedAssemblies.Concat(new[] { 
                        typeof(NancyEngine).Assembly,
                        typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly,
                        typeof(System.ComponentModel.Composition.Hosting.CompositionContainer).Assembly,
                        typeof(NancyRazorViewCatalog).Assembly,
                        typeof(global::Nancy.ViewEngines.Razor.NancyRazorViewBase).Assembly,
                }),
                importedNamespaces: new[] {
                    typeof(System.ComponentModel.Composition.ExportAttribute).Namespace,
                    typeof(NancyRazorViewCatalog).Namespace,
                },
                host: new NancyRazorEngineHost(new CSharpRazorCodeLanguage()));

            // save away view
            return type;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="templates"></param>
        public NancyRazorViewCatalog(IEnumerable<RazorViewTemplate> templates)
            : base(GetOrBuildViewTypes(templates), new NancyRazorViewReflectionContext())
        {
            Contract.Requires<ArgumentNullException>(templates != null);
        }

    }

}
