using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using Cogito.Linq;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides Nancy Razor views for every .nancy.cshtml file in the <see cref="Assembly."/>
    /// </summary>
    public class NancyRazorViewAssemblyCatalog :
        NancyRazorViewCatalog
    {

        const string suffix = ".nancy.cshtml";

        /// <summary>
        /// Extracts a <see cref="RazorViewDefinition"/> from the given <see cref="Assembly"/> resource.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        static RazorViewDefinition GetTemplate(Assembly assembly, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(resourceName));

            // remove suffix, split by ., extract file name as class name and preceding as namespace
            var segments = resourceName.RemoveEnd(suffix).Split('.');
            var ns = string.Join(".", segments.Take(segments.Length - 1));
            var tn = segments.Last();

            // append _ to end of type name until in the clear
            while (true)
            {
                var any = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(i => !i.IsDynamic)
                    .SelectMany(i => i.GetTypes())
                    .Where(i => i.Namespace == ns && i.Name == tn)
                    .Any();
                if (any)
                    tn += "_";
                else
                    break;
            }

            // resolve direct references of host assembly
            var refs = assembly.GetReferencedAssemblies()
                .SelectMany(i => AppDomain.CurrentDomain.GetAssemblies().Where(j => j.GetName().Name == i.Name))
                .Prepend(assembly);

            return new RazorViewDefinition(ns, tn, assembly.GetManifestResourceStream(resourceName), refs);
        }

        /// <summary>
        /// Obtains all of the resource templates from the specified <see cref="Assembly"/> which are Nancy Razor views.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        static IEnumerable<RazorViewDefinition> GetRazorViewTemplates(Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);

            return assembly.GetManifestResourceNames()
                .Where(i => i.EndsWith(suffix))
                .Select(i => GetTemplate(assembly, i))
                .Tee();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        public NancyRazorViewAssemblyCatalog(Assembly assembly)
            : base(GetRazorViewTemplates(assembly))
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
        }

        public override IEnumerable<Tuple<System.ComponentModel.Composition.Primitives.ComposablePartDefinition, System.ComponentModel.Composition.Primitives.ExportDefinition>> GetExports(System.ComponentModel.Composition.Primitives.ImportDefinition definition)
        {
            return base.GetExports(definition);
        }

    }

}
