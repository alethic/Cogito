using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;

namespace Cogito.Resources
{

    /// <summary>
    /// Provides <see cref="IResourceBundle"/>s for each loaded assembly.
    /// </summary>
    [ResourceBundleProvider]
    public class AssemblyResourceBundleProvider :
        EnumerableQuery<IResourceBundle>,
        IResourceBundleProvider
    {

        static IEnumerable<IResourceBundle> GetBundles(IMediaTypeResolver mediaTypeResolver)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(i => !i.IsDynamic)
                .Where(i => i.GetCustomAttributes<AssemblyResourceBundleAttribute>().Any())
                .Select(i => new AssemblyResourceBundle(i, mediaTypeResolver));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public AssemblyResourceBundleProvider(
            IMediaTypeResolver mediaTypeResolver)
            : base(GetBundles(mediaTypeResolver).ToList())
        {

        }

    }

}
