using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

using Cogito.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Default <see cref="IResourcePackage"/> implementation.
    /// </summary>
    public class ResourceBundle :
        IResourceBundle
    {

        readonly string id;
        readonly Version version;
        IQueryable<Expression<Func<IResourceBundle, bool>>> dependencies;
        IQueryable<IResource> resources;

        /// <summary>
        /// Code Contracts Invariant
        /// </summary>
        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(id != null);
            Contract.Invariant(version != null);
            Contract.Invariant(dependencies != null);
            Contract.Invariant(resources != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        ResourceBundle(
            string id,
            Version version)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(version != null);

            this.id = id;
            this.version = version;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="resources"></param>
        /// <param name="dependencies"></param>
        /// <param name="resourceDependencies"></param>
        public ResourceBundle(
            string id,
            Version version,
            IQueryable<Resource> resources,
            IQueryable<Expression<Func<IResourceBundle, bool>>> dependencies)
            : this(id, version)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resources != null);

            this.resources = resources;
            this.dependencies = dependencies ?? Enumerable.Empty<Expression<Func<IResourceBundle, bool>>>().AsQueryable();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="items"></param>
        /// <param name="dependencies"></param>
        /// <param name="resourceDependency"></param>
        public ResourceBundle(
            string id,
            Version version,
            IEnumerable<Resource> items,
            IEnumerable<Expression<Func<IResourceBundle, bool>>> dependencies = null)
            : this(
                id,
                version,
                items.AsQueryable(),
                dependencies != null ? dependencies.AsQueryable() : null)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(items != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="items"></param>
        public ResourceBundle(
            string id,
            Version version,
            params Resource[] items)
            : this(
                id,
                version,
                items.AsQueryable())
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(items != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="resources"></param>
        /// <param name="dependencies"></param>
        /// <param name="resourceDependency"></param>
        public ResourceBundle(
            string id,
            Version version,
            IEnumerable<Expression<Func<IResourceBundle, bool>>> dependencies,
            params Resource[] resources)
            : this(
                id,
                version,
                resources.AsQueryable(),
                dependencies != null ? dependencies.AsQueryable() : null)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resources != null);
            Contract.Requires<ArgumentOutOfRangeException>(resources.Length > 0);
        }

        /// <summary>
        /// Gets the ID of the bundle.
        /// </summary>
        public string Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the <see cref="Version"/> of the bundle.
        /// </summary>
        public Version Version
        {
            get { return version; }
        }

        /// <summary>
        /// Gets the dependencies of this bundle.
        /// </summary>
        public IQueryable<Expression<Func<IResourceBundle, bool>>> Dependencies
        {
            get { return dependencies; }
        }

        /// <summary>
        /// Adds the given resource.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ResourceBundle Includes(Resource item)
        {
            Contract.Requires<ArgumentNullException>(item != null);

            resources = resources.Append(item).AsQueryable();
            return this;
        }

        /// <summary>
        /// Adds the given resource.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="source"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="isDebug"></param>
        /// <param name="dependencies"></param>
        /// <returns></returns>
        public ResourceBundle Includes(
            string name,
            string contentType,
            Func<object> source,
            CultureInfo cultureInfo = null,
            bool? isDebug = null,
            params Expression<Func<IResourceBundle, bool>>[] dependencies)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);

            return Includes(new Resource(this, name, contentType, cultureInfo, isDebug, source, null, dependencies));
        }

        /// <summary>
        /// Adds the given resource.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="source"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="isDebug"></param>
        /// <param name="dependencies"></param>
        /// <returns></returns>
        public ResourceBundle Includes(
            string name,
            string contentType,
            object source,
            CultureInfo cultureInfo = null,
            bool? isDebug = null,
            params Expression<Func<IResourceBundle, bool>>[] dependencies)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(contentType != null);
            Contract.Requires<ArgumentNullException>(source != null);

            return Includes(name, contentType, () => source, cultureInfo, isDebug, dependencies);
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="dependency"></param>
        public ResourceBundle Requires(Expression<Func<IResourceBundle, bool>> dependency)
        {
            Contract.Requires<ArgumentNullException>(dependency != null);
            dependencies = dependencies.Append(dependency).AsQueryable();
            return this;
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public ResourceBundle Requires(string bundleId)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            return Requires(_ => _.Id == bundleId);
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="minimumVersion"></param>
        /// <returns></returns>
        public ResourceBundle Requires(string bundleId, Version minimumVersion)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);
            return minimumVersion != null ? Requires(_ => _.Id == bundleId) : Requires(_ => _.Id == bundleId && _.Version >= minimumVersion);
        }

        /// <summary>
        /// Adds the given dependency.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="minimumVersion"></param>
        /// <param name="maximumVersion"></param>
        /// <returns></returns>
        public ResourceBundle Requires(string bundleId, Version minimumVersion, Version maximumVersion)
        {
            Contract.Requires<ArgumentNullException>(bundleId != null);

            if (minimumVersion != null && maximumVersion != null)
                return Requires(_ => _.Id == bundleId && _.Version >= minimumVersion && _.Version <= maximumVersion);
            else if (maximumVersion != null)
                return Requires(_ => _.Id == bundleId && _.Version <= maximumVersion);
            else if (minimumVersion != null)
                return Requires(bundleId, minimumVersion);
            else
                return Requires(bundleId);
        }

        #region IQueryable

        IEnumerator<IResource> GetEnumerator()
        {
            return resources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return resources.GetEnumerator();
        }

        IEnumerator<IResource> IEnumerable<IResource>.GetEnumerator()
        {
            return resources.GetEnumerator();
        }

        Type IQueryable.ElementType
        {
            get { return resources.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return resources.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return resources.Provider; }
        }

        #endregion

    }

}
