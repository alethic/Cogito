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

        readonly HttpMessageEventSource eventSource;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="eventSource"></param>
        /// <param name="innerHandler"></param>
        public HttpEventSourceWriterHandler(HttpMessageEventSource eventSource, HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            Contract.Requires<ArgumentNullException>(eventSource != null);
            Contract.Requires<ArgumentNullException>(innerHandler != null);

            this.eventSource = eventSource;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="eventSource"></param>
        public HttpEventSourceWriterHandler(HttpMessageEventSource eventSource)
            : this(eventSource, new HttpClientHandler())
        {
            Contract.Requires<ArgumentNullException>(eventSource != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="innerHandler"></param>
        public HttpEventSourceWriterHandler(HttpMessageHandler innerHandler)
            : this(HttpMessageEventSource.Current, innerHandler)
        {
            Contract.Requires<ArgumentNullException>(innerHandler != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public HttpEventSourceWriterHandler()
            : this(HttpMessageEventSource.Current, new HttpClientHandler())
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            eventSource.Request(request);
            var response = await base.SendAsync(request, cancellationToken);
            eventSource.Response(response);

            return response;
        }

    }

}
