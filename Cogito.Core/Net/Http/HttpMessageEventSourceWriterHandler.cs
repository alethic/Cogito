﻿using System.Net.Http;
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
        public HttpEventSourceWriterHandler()
            : base(new HttpClientHandler())
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpMessageEventSource.Current.Request(request);
            var response = await base.SendAsync(request, cancellationToken);
            HttpMessageEventSource.Current.Response(response);

            return response;
        }

    }

}
