using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Cogito.Resources
{

    public static class ResourceBundleQueryExtensions
    {

        /// <summary>
        /// Returns the IsDebug filter.
        /// </summary>
        /// <returns></returns>
        static bool GetIsDebug()
        {
            var debug = false;

#if DEBUG
            debug = true;
#endif

            return debug;
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

            return query
                .Where(i => i.Id == bundleId && object.Equals(i.Version, version))
                .SelectMany(i => i)
                .Where(i => i.Name == resourceName)
                .Where(i => i.IsDebug == null || i.IsDebug == GetIsDebug());
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

            return query
                .Where(i => i.Id == bundleId && object.Equals(i.Version.ToString(), version))
                .SelectMany(i => i)
                .Where(i => i.Name == resourceName)
                .Where(i => i.IsDebug == null || i.IsDebug == GetIsDebug());
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
