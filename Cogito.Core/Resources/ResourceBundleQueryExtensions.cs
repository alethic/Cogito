using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Resources
{

    /// <summary>
    /// Provides extension methods for operating against a <see cref="IQueryable<IResourceBundle>"/>.
    /// </summary>
    public static class ResourceBundleQueryExtensions
    {

        /// <summary>
        /// Returns the IsDebug filter.
        /// </summary>
        /// <returns></returns>
        static bool GetIsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// Queries for the set of <see cref="IResource"/>s that match the given information.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IQueryable<IResource> Query(this IQueryable<IResourceBundle> query, string bundleId, Version version, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(query != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            return Query(query, bundleId, resourceName)
                .Where(i => i.Bundle.Id == bundleId && object.Equals(i.Bundle.Version, version));
        }

        /// <summary>
        /// Queries for the set of <see cref="IResource"/>s that match the given information.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IQueryable<IResource> Query(this IQueryable<IResourceBundle> query, string bundleId, string version, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(query != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            return Query(query, bundleId, resourceName)
                .Where(i => i.Bundle.Id == bundleId && object.Equals(i.Bundle.Version.ToString(), version));
        }

        /// <summary>
        /// Queries for the set of <see cref="IResource"/>s that match the given information.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="bundleId"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IQueryable<IResource> Query(this IQueryable<IResourceBundle> query, string bundleId, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(query != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            return query
                .Where(i => i.Id == bundleId)
                .OrderByDescending(i => i.Version)
                .SelectMany(i => i)
                .Where(i => i.Name == resourceName)
                .Where(i => i.IsDebug == null || i.IsDebug == GetIsDebug());
        }

    }

}
