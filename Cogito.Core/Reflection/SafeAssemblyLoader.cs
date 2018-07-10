using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyModel;

namespace Cogito.Reflection
{

    public static class SafeAssemblyLoader
    {

        /// <summary>
        /// Loads an <see cref="Assembly"/> from a path, ignoring failures.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Assembly Load(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentOutOfRangeException(nameof(path));

            try
            {
#if NETSTANDARD2_0 || NETSTANDARD1_6
                return System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
#else
                return Assembly.LoadFrom(path);
#endif
            }
            catch (Exception)
            {
                // ignore
            }

            return null;
        }

#if NETSTANDARD2_0 || NETSTANDARD1_6

        /// <summary>
        /// Load all assemblies.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> LoadAll()
        {
            return DependencyContext.Default.RuntimeLibraries
                .SelectMany(i => i.GetDefaultAssemblyNames(DependencyContext.Default))
                .Select(LoadAssembly)
                .Where(i => i != null);
        }

        /// <summary>
        /// Safely loads the specified <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assemblyName"></param>
        static Assembly LoadAssembly(AssemblyName assemblyName)
        {
            if (assemblyName == null)
                throw new ArgumentNullException(nameof(assemblyName));

            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception)
            {
                return null;
            }
        }

#else

        /// <summary>
        /// Load all assemblies.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> LoadAll()
        {
            return GetBaseDirectories()
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Distinct()
                .Where(i => Directory.Exists(i))
                .SelectMany(i => Enumerable.Empty<string>()
                    .Concat(Directory.EnumerateFiles(i, "*.dll", SearchOption.TopDirectoryOnly))
                    .Concat(Directory.EnumerateFiles(i, "*.exe", SearchOption.TopDirectoryOnly)))
                .Distinct()
                .Select(i => Load(i))
                .Where(i => i != null);
        }

#endif

        /// <summary>
        /// Gets the application search paths.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<string> GetBaseDirectories()
        {
#if NETSTANDARD2_0 || NETSTANDARD1_6
            yield return AppContext.BaseDirectory;
#else
            yield return AppDomain.CurrentDomain.BaseDirectory;
            yield return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            yield return AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
#endif
        }

    }

}
