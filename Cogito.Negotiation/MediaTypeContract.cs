namespace Cogito.Negotiation
{

    public abstract class MediaTypeContract
    {

        readonly MediaType mediaType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="mediaType"></param>
        protected MediaTypeContract(MediaType mediaType)
        {
            this.mediaType = mediaType;
        }

        /// <summary>
        /// Gets the required <see cref="MediaType"/>.
        /// </summary>
        public MediaType MediaType
        {
            get { return mediaType; }
        }

    }

}
