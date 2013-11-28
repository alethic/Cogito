using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

using Cogito.Negotiation;
using Cogito.Resources;

using Nancy;
using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy
{

    [Export(typeof(IResponseProcessor))]
    public class ResourceProcessor :
        IResponseProcessor
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

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var q = (object)model as IEnumerable<IResource>;
            if (q == null)
                return noMatch;

            var r = q
                .Where(i => requestedMediaRange.MatchesWithParameters(MediaRange.FromString(i.ContentType)))
                .FirstOrDefault();
            if (r == null)
                return noMatch;

            return onMatch;
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            var q = (object)model as IEnumerable<IResource>;
            if (q == null)
                throw new Exception();

            var r = q
                .Where(i => requestedMediaRange.MatchesWithParameters(MediaRange.FromString(i.ContentType)))
                .FirstOrDefault();
            if (r == null)
                throw new Exception();

            // return proper response
            var s = new StreamResponse(() => r.Source() as Stream, r.ContentType);

            // set last modified time based on resource, if available
            if (r.LastModifiedTimeUtc != null)
            {
                s.WithHeader("ETag", ((DateTime)r.LastModifiedTimeUtc).Ticks.ToString("x"));
                s.WithHeader("Last-Modified", ((DateTime)r.LastModifiedTimeUtc).ToString("R"));
            }

            return s;
        }

    }

}
