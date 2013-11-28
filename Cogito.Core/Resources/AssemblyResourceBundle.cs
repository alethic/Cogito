using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Cogito.Reflection;

namespace Cogito.Resources
{

    /// <summary>
    /// Describes an <see cref="IResourceBundle"/> derived from an <see cref="Assembly"/>.
    /// </summary>
    public class AssemblyResourceBundle :
        IResourceBundle
    {

        readonly Assembly assembly;
        readonly Version version;
        readonly DateTime? lastModifiedTimeUtc;
        readonly IEnumerable<AssemblyResource> resources;
        readonly IQueryable<AssemblyResource> resourcesQuery;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyResourceBundle(
            Assembly assembly,
            IMediaTypeResolver mediaTypeResolver)
        {
            Contract.Requires<ArgumentNullException>(assembly != null);
            Contract.Requires<ArgumentNullException>(mediaTypeResolver != null);

            this.assembly = assembly;
            this.version = assembly.GetVersion();
            this.lastModifiedTimeUtc = assembly.GetLastModifiedTimeUtc();
            this.resources = GetAssemblyResources(mediaTypeResolver).ToList();
            this.resourcesQuery = resources.AsQueryable();
        }

        /// <summary>
        /// Returns an <see cref="AssemblyResource"/> for each resource in the <see cref="Assembly"/>.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AssemblyResource> GetAssemblyResources(IMediaTypeResolver mediaTypeResolver)
        {
            foreach (var resourceName in assembly.GetManifestResourceNames())
                yield return new AssemblyResource(this, resourceName, mediaTypeResolver);
        }

        public Assembly Assembly
        {
            get { return assembly; }
        }

        public string Id
        {
            get { return assembly.GetName().Name; }
        }

        public Version Version
        {
            get { return version; }
        }

        public IEnumerable<Expression<Func<IResourceBundle, bool>>> Dependencies
        {
            get { return Enumerable.Empty<Expression<Func<IResourceBundle, bool>>>(); }
        }

        public IEnumerator<IResource> GetEnumerator()
        {
            return resources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return resources.GetEnumerator();
        }

        public Type ElementType
        {
            get { return resourcesQuery.ElementType; }
        }

        public Expression Expression
        {
            get { return resourcesQuery.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return resourcesQuery.Provider; }
        }

        public DateTime? LastModifiedTimeUtc
        {
            get { return lastModifiedTimeUtc; }
        }

    }

}
