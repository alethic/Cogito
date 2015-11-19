using System;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Resources;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Provides standard Url helpers.
    /// </summary>
    public static class UrlHelpersExtensions
    {

        /// <summary>
        /// Gets the custom render context version.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <returns></returns>
        static NancyRazorRenderContext GetRenderContext<T>(UrlHelpers<T> helpers)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Ensures(Contract.Result<NancyRazorRenderContext>() != null);

            return (NancyRazorRenderContext)helpers.RenderContext;
        }

        /// <summary>
        /// Resolves the URL of a resource given its name relative to the current view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IHtmlString ResourceUrl<T>(this UrlHelpers<T> helpers, string bundleId, Version version, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            var query = GetRenderContext<T>(helpers).Composition.GetExportedValueOrDefault<IResourceBundleQuery>();
            if (query == null)
                throw new NullReferenceException();

            // find first available resource
            var resource = query.Query(bundleId, version, resourceName)
                .FirstOrDefault();
            if (resource == null)
                throw new NullReferenceException();

            // return url
            return ResourceUrl<T>(helpers, resource);
        }

        /// <summary>
        /// Resolves the URL of a resource given its name relative to the current view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IHtmlString ResourceUrl<T>(this UrlHelpers<T> helpers, string bundleId, string version, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(version != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            var query = GetRenderContext<T>(helpers).Composition.GetExportedValueOrDefault<IResourceBundleQuery>();
            if (query == null)
                throw new NullReferenceException();

            // find first available resource
            var resource = query.Query(bundleId, version, resourceName)
                .FirstOrDefault();
            if (resource == null)
                throw new NullReferenceException();

            // return url
            return ResourceUrl<T>(helpers, resource);
        }

        /// <summary>
        /// Resolves the URL of a resource given its name relative to the current view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IHtmlString ResourceUrl<T>(this UrlHelpers<T> helpers, string bundleId, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Requires<ArgumentNullException>(bundleId != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            var query = GetRenderContext<T>(helpers).Composition.GetExportedValueOrDefault<IResourceBundleQuery>();
            if (query == null)
                throw new NullReferenceException();

            // find first available resource
            var resource = query.Query(bundleId, resourceName)
                .FirstOrDefault();
            if (resource == null)
                throw new ResourceNotFoundException(bundleId, resourceName);

            // return url
            return ResourceUrl<T>(helpers, resource);
        }

        /// <summary>
        /// Formats a URL for the given <see cref="IResource"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static IHtmlString ResourceUrl<T>(this UrlHelpers<T> helpers, IResource resource)
        {
            return new NonEncodedHtmlString(helpers.Content(string.Format("/r/{0}/{1}/{2}",
                resource.Bundle.Id,
                resource.Bundle.Version,
                resource.Name)));
        }

    }

}
