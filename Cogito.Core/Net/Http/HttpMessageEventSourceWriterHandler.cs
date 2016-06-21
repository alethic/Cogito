using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Net.Http
{

    /// <summary>
    /// Intercepts HTTP messages and writes them to the event source.
    /// </summary>
    public class HttpEventSourceWriterHandler :
        DelegatingHandler
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="eventSource"></param>
        /// <param name="innerHandler"></param>
        public HttpEventSourceWriterHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            Contract.Requires<ArgumentNullException>(innerHandler != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpEventSourceWriterHandler()
            : this(new HttpClientHandler())
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessageEventSource.Current.HttpRequest(request);
            var response = await base.SendAsync(request, cancellationToken);
            HttpMessageEventSource.Current.HttpResponse(response);

            return response;
        }

    }

}
