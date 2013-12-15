using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

using Cogito.Collections;

namespace Cogito.Reflection
{

    public static class AssemblyExtensions
    {

        /// <summary>
        /// Provides an <see cref="IEqualityComparer"/> that compares <see cref="Assembly"/> instances on their FullName.
        /// </summary>
        static readonly IEqualityComparer<Assembly> FullNameAssemblyEqualityComparer =
            new DelegateEqualityComparer<Assembly>(
                (x, y) => x.FullName == y.FullName,
                (x) => x.FullName.GetHashCode());

        /// <summary>
        /// Returns an enumeration of the referenced assemblies of the given <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> LoadAllReferencedAssemblies(this Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);

            // determine unique assemblies
            var set = new HashSet<Assembly>(FullNameAssemblyEqualityComparer);
            set.Add(assembly);
            LoadAllReferencedAssembliesInternal(assembly, set);
            return set;
        }

        /// <summary>
        /// Recurses into referenced assemblies, adding to set and continuing only if not already present in set.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblies"></param>
        static void LoadAllReferencedAssembliesInternal(this Assembly assembly, HashSet<Assembly> assemblies)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(assemblies != null);

            foreach (var assemblyName in assembly.GetReferencedAssemblies())
                if ((assembly = assemblyName.ReflectionOnlyLoad()) != null && assemblies.Add(assembly))
                    LoadAllReferencedAssembliesInternal(assembly, assemblies);
        }

        /// <summary>
        /// Resolves the <see cref="Version"/> of the specified assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Version GetVersion(this Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);

            return new RuntimeVersion(assembly.GetName().Version);
        }

    }

}
