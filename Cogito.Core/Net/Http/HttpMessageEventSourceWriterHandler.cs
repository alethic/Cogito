using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Net.Http
{

    /// <summary>
    /// Intercepts HTTP messages and writes them to the event source.
    /// </summary>
    public class HttpMessageEventSourceWriterHandler :
        DelegatingHandler
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="innerHandler"></param>
        public HttpMessageEventSourceWriterHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            if (innerHandler == null)
                throw new ArgumentNullException(nameof(innerHandler));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpMessageEventSourceWriterHandler()
            : this(new HttpClientHandler())
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessageEventSource.Current.HttpRequestStart(request);
            var response = await base.SendAsync(request, cancellationToken);
            HttpMessageEventSource.Current.HttpRequestStop(response);

            return response;
        }

    }

}
