using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

using Cogito.Negotiation;
using Cogito.Resources;
using Cogito.Collections;

using Nancy;
using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy
{

    [Export(typeof(IResponseProcessor))]
    public class ResourceProcessor : IResponseProcessor
    {

        static readonly ProcessorMatch noMatch = new ProcessorMatch();
        static readonly ProcessorMatch onMatch = new ProcessorMatch { ModelResult = MatchResult.ExactMatch, RequestedContentTypeResult = MatchResult.ExactMatch };

        readonly INegotiationService negotiation;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="negotiation"></param>
        [ImportingConstructor]
        public ResourceProcessor(
            INegotiationService negotiation)
        {
            this.negotiation = negotiation;
        }

        /// <summary>
        /// Returns the output stream.
        /// </summary>
        /// <param name="requestedMediaRange"></param>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Tuple<Stream, Cogito.MediaType> GetItem(MediaRange requestedMediaRange, object model, NancyContext context)
        {
            // resource processor cache
            var cache = (Dictionary<Tuple<MediaRange, object>, Tuple<Stream, Cogito.MediaType>>)
                context.Items.GetOrAdd(typeof(ResourceProcessor).Name, _ =>
                    new Dictionary<Tuple<MediaRange, object>, Tuple<Stream, Cogito.MediaType>>());

            return cache.GetOrAdd(Tuple.Create(requestedMediaRange, model), _ =>
            {
                // we handle enumerations of resources
                var resources = _.Item2 as IEnumerable<IResource>;
                if (resources == null)
                    return null;

                // find first available resource
                var resource = resources
                    .FirstOrDefault(i => _.Item1.MatchesWithParameters(MediaRange.FromString(i.ContentType)));
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

                return Tuple.Create(stream, new Cogito.MediaType(requestedMediaRange.ToString()));
            });
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return GetItem(requestedMediaRange, (object)model, context) != null ? onMatch : noMatch;
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var item = GetItem(requestedMediaRange, (object)model, context);

            return new StreamResponse(() => item.Item1, item.Item2.ToString());
        }

    }

}
