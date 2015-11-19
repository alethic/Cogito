using System.Linq;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Requires a certain media type.
    /// </summary>
    public class MediaTypeSourceContract :
        MediaTypeContract,
        ISourceContract
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="mediaType"></param>
        public MediaTypeSourceContract(Cogito.MediaType mediaType)
            : base(mediaType)
        {

        }

        public NegotiationResult Negotiate(IOutputNegotiator negotiator)
        {
            return negotiator.Contracts
                .OfType<MediaTypeOutputContract>()
                .Where(i => i.MediaType == MediaType)
                .Select(i => new NegotiationResult(0d))
                .FirstOrDefault();
        }

    }

}
