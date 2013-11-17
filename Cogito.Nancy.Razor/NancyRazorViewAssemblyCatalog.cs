using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Cogito;
using Cogito.Linq;

using System.Threading.Tasks;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides Nancy Razor views for every .nancy.cshtml file in the <see cref="Assembly."/>
    /// </summary>
    public class NancyRazorViewAssemblyCatalog : NancyRazorViewCatalog
    {

        const string suffix = ".nancy.cshtml";

        /// <summary>
        /// Extracts a <see cref="RazorViewTemplate"/> from the given <see cref="Assembly"/> resource.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        static RazorViewTemplate GetTemplate(Assembly assembly, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(resourceName));

            // remove suffix, split by ., extract file name as class name and preceeding as namespace
            var t = resourceName.RemoveEnd(suffix);
            var a = t.Split('.');
            var cn = a.Last();
            var ns = string.Join(".", a.Take(a.Length - 1));

            // resolve direct references of host assembly
            var refs = assembly.GetReferencedAssemblies()
                .SelectMany(i => AppDomain.CurrentDomain.GetAssemblies().Where(j => j.GetName().Name == i.Name))
                .Prepend(assembly);

            return new RazorViewTemplate(ns, cn, assembly.GetManifestResourceStream(resourceName), refs);
        }

        /// <summary>
        /// Obtains all of the resource templates from the specified <see cref="Assembly"/> which are Nancy Razor views.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        static IEnumerable<RazorViewTemplate> GetRazorViewTemplates(Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);

            return assembly.GetManifestResourceNames()
                .Where(i => i.EndsWith(suffix))
                .Select(i => GetTemplate(assembly, i));
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

    }

}
