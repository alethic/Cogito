using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

using Cogito.Negotiation;
using Cogito.Resources;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy
{

    [NancyModule]
    public class ResourceBundleModule : NancyModule
    {

        readonly INegotiationService negotiation;
        readonly IResourceBundleQuery query;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="query"></param>
        [ImportingConstructor]
        public ResourceBundleModule(
            INegotiationService negotiation,
            IResourceBundleQuery query)
            : base("r")
        {
            this.negotiation = negotiation;
            this.query = query;

            Get["/{Bundle}/{Version}/{ResourceName*}"] = _ => 
                GetResource(_.Bundle, _.Version, _.ResourceName);
        }

        /// <summary>
        /// Returns the IsDebug filter.
        /// </summary>
        /// <returns></returns>
        bool GetIsDebug()
        {
            var debug = false;

#if DEBUG
            debug = true;
#endif

            return debug;
        }

        /// <summary>
        /// Get the specified resource.
        /// </summary>
        /// <param name="bundleId"></param>
        /// <param name="version"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        dynamic GetResource(string bundleId, string version, string resourceName)
        {
            // return list of IResources that match the request
            var resources = query.AsEnumerable()
                .Where(i => i.Id == bundleId && i.Version.ToVersionString() == version)
                .SelectMany(i => i)
                .Where(i => i.Name == resourceName)
                .Where(i => i.IsDebug == null || i.IsDebug == GetIsDebug())
                .ToList();

            foreach (var mediaType in Negotiate.NegotiationContext.PermissableMediaRanges)
            {
                // find first available resource
                var resource = resources
                    .FirstOrDefault(i => mediaType.MatchesWithParameters(MediaRange.FromString(i.ContentType)));
                if (resource == null)
                    return null;

                var source = resource.Source();
                if (source == null)
                    return null;

                var result = negotiation.Negotiate(source.GetType(), typeof(Stream),
                    null, null);
                if (result == null)
                    return null;

                var stream = (Stream)result.Invoke(source);
                if (stream == null)
                    return null;

                return Response.FromStream(stream, resource.ContentType);
            }

            return HttpStatusCode.NotFound;
        }

    }

}
