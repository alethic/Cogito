using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Nancy;
using Nancy.Responses;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Processes responses of type <see cref="System.Uri"/>.
    /// </summary>
    [Export(typeof(IResponseProcessor))]
    public class UriProcessor :
        IResponseProcessor
    {

        static readonly ProcessorMatch noMatch = new ProcessorMatch();
        static readonly ProcessorMatch onMatch = new ProcessorMatch { ModelResult = MatchResult.ExactMatch, RequestedContentTypeResult = MatchResult.DontCare };

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public UriProcessor()
        {

        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return model is Uri ? onMatch : noMatch;
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return new RedirectResponse(((Uri)model).ToString(), RedirectResponse.RedirectType.Temporary);
        }

    }

}
