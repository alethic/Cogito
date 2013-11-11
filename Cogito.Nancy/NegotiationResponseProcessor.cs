using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Negotiation;

using Nancy;
using Nancy.Responses.Negotiation;

namespace Cogito.Nancy
{

    /// <summary>
    /// Processes Nancy responses using the Cogito negotitation framework.
    /// </summary>
    public class NegotiationResponseProcessor :
        IResponseProcessor
    {

        static readonly ProcessorMatch noMatch = new ProcessorMatch();
        static readonly ProcessorMatch onMatch = new ProcessorMatch { ModelResult = MatchResult.DontCare, RequestedContentTypeResult = MatchResult.ExactMatch };

        readonly INegotiationService negotiation;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="negotiation"></param>
        [ImportingConstructor]
        public NegotiationResponseProcessor(
            INegotiationService negotiation)
        {
            this.negotiation = negotiation;
        }

        Negotiated Negotiate(MediaRange requestedMediaRange, object model, NancyContext context)
        {
            return negotiation.Negotiate(
                ((object)model).GetType(),
                typeof(Response),
                null,
                _ => _.OfContentType(requestedMediaRange.ToString()));
        }

        public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            //return Negotiate(requestedMediaRange, model, context) != null ? onMatch : noMatch;
            return noMatch;
        }

        public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings
        {
            get { yield break; }
        }

        public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return (Response)Negotiate(requestedMediaRange, (object)model, context).Invoke((object)model);
        }

    }

}
