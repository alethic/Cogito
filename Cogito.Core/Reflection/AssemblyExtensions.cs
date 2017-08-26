using System;
using System.Collections.Generic;
using System.Reflection;

#if NETSTANDARD1_6
using System.Runtime.Loader;
#endif

using Cogito.Collections;

namespace Cogito.Reflection
{

    /// <summary>
    /// Various extension methods for working with <see cref="Assembly"/> instances.
    /// </summary>
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
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

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
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

#if !NETSTANDARD1_6

            foreach (var assemblyName in assembly.GetReferencedAssemblies())
                if ((assembly = assemblyName.ReflectionOnlyLoad()) != null && assemblies.Add(assembly))
                    LoadAllReferencedAssembliesInternal(assembly, assemblies);

#else

            foreach (var assemblyName in assembly.GetReferencedAssemblies())
                if ((assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName)) != null && assemblies.Add(assembly))
                    LoadAllReferencedAssembliesInternal(assembly, assemblies);

#endif
        }

    }

}
