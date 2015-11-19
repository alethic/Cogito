using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Describes a media type output by a component.
    /// </summary>
    public class MediaTypeOutputContract :
        MediaTypeContract,
        IOutputContract
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="mediaType"></param>
        public MediaTypeOutputContract(Cogito.MediaType mediaType)
            : base(mediaType)
        {

        }

        public NegotiationResult Negotiate(ISourceNegotiator negotiator)
        {
            return negotiator.Contracts
                .OfType<MediaTypeSourceContract>()
                .Where(i => i.MediaType == MediaType)
                .Select(i => new NegotiationResult(0d))
                .FirstOrDefault();
        }

    }

}
