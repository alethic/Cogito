using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Ensures service assemblies are available in the <see cref="AppDomain"/>.
    /// </summary>
    public class AppDomainAssemblyResolver :
        MarshalByRefObject
    {

        readonly string parentBasePath;
        readonly Tuple<FileInfo, AssemblyName>[] assemblies;
        readonly ConcurrentDictionary<FileInfo, Assembly> cache;

        /// <summary>
        /// Initializes a new insance.
        /// </summary>
        /// <param name="parentBasePath"></param>
        public AppDomainAssemblyResolver(string parentBasePath)
        {
            Contract.Requires<ArgumentNullException>(parentBasePath != null);

            this.parentBasePath = parentBasePath;
            this.cache = new ConcurrentDictionary<FileInfo, Assembly>();
            this.assemblies = Enumerable.Concat(GetAssemblies(AppDomain.CurrentDomain.BaseDirectory), GetAssemblies(parentBasePath)).ToArray();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        /// <summary>
        /// Gets a set of assembly data from the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<Tuple<FileInfo, AssemblyName>> GetAssemblies(string path)
        {
            return Directory.EnumerateFiles(path)
                .Select(i => new { Path = i, Extension = Path.GetExtension(i) })
                .Where(i => i.Extension.Equals(".dll", StringComparison.InvariantCultureIgnoreCase) || i.Extension.Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
                .Select(i => new { Path = i.Path, Name = TryGetAssemblyName(i.Path) })
                .Where(i => i.Name != null)
                .Select(i => Tuple.Create(new FileInfo(i.Path), i.Name))
                .ToArray();
        }

        /// <summary>
        /// Invoked when the <see cref="AppDomain"/> is unable to load an <see cref="Assembly"/>. Ensures the service
        /// <see cref="Assembly"/> is available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Contract.Requires<ArgumentNullException>(sender != null);
            Contract.Requires<ArgumentNullException>(args != null);

            var name = new AssemblyName(args.Name);

            // resolve assembly from cache or from disk
            return assemblies
                .Where(i => AssemblyName.ReferenceMatchesDefinition(name, i.Item2))
                .Select(i => cache.GetOrAdd(i.Item1, _ => TryLoadAssemblyFrom(_.FullName)))
                .FirstOrDefault(i => i != null);
        }

        /// <summary>
        /// Tries to get the <see cref="AssemblyName"/>.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        AssemblyName TryGetAssemblyName(string path)
        {
            try
            {
                return AssemblyName.GetAssemblyName(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        Assembly TryLoadAssemblyFrom(string path)
        {
            try
            {
                return Assembly.LoadFrom(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

    }

}
