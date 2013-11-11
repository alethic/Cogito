using System;
using System.Diagnostics.Contracts;
using System.Linq;
using Cogito.Resources;
using Nancy.ViewEngines.Razor;

namespace Cogito.Nancy.Razor
{

    public static class UrlHelpersExtensions
    {

        /// <summary>
        /// Gets the custom render context version.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <returns></returns>
        static NancyRenderContext GetRenderContext<T>(UrlHelpers<T> helpers)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Ensures(Contract.Result<NancyRenderContext>() != null);

            return (NancyRenderContext)helpers.RenderContext;
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
            return new NonEncodedHtmlString(helpers.Content("/r/" + resource.Bundle.Id + "/" + resource.Bundle.Version + "/" + resource.Name));
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
                throw new NullReferenceException();

            // return url
            return new NonEncodedHtmlString(helpers.Content("/r/" + resource.Bundle.Id + "/" + resource.Bundle.Version + "/" + resource.Name));
        }

        /// <summary>
        /// Resolves the URL of a resource given its name relative to the current view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helpers"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static IHtmlString ResourceUrl<T>(this UrlHelpers<T> helpers, string resourceName)
        {
            Contract.Requires<ArgumentNullException>(helpers != null);
            Contract.Requires<ArgumentNullException>(resourceName != null);

            throw new NotImplementedException();
        }

    }

}
