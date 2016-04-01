using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Factory that creates clients that know how to communicate with services with HTTP endpoints.
    /// </summary>
    public class HttpCommunicationClientFactory :
        CommunicationClientFactoryBase<HttpCommunicationClient>
    {

        /// <summary>
        /// Appends our custom exception handler.
        /// </summary>
        /// <param name="additionalHandlers"></param>
        /// <returns></returns>
        static IEnumerable<IExceptionHandler> CreateExceptionHandlers(IEnumerable<IExceptionHandler> additionalHandlers)
        {
            return new[] { new HttpExceptionHandler() }.Union(additionalHandlers ?? Enumerable.Empty<IExceptionHandler>());
        }

        readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="exceptionHandlers"></param>
        public HttpCommunicationClientFactory(IServicePartitionResolver resolver = null, IEnumerable<IExceptionHandler> exceptionHandlers = null)
            : base(resolver, CreateExceptionHandlers(exceptionHandlers))
        {
            this.httpClient = new HttpClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpCommunicationClient> CreateClientAsync(string endpoint, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpCommunicationClient(httpClient, endpoint));
        }

        /// <summary>
        /// Returns <c>true</c> if the client is still connected.
        /// </summary>
        /// <param name="clientChannel"></param>
        /// <returns></returns>
        protected override bool ValidateClient(HttpCommunicationClient clientChannel)
        {
            return true;
        }

        /// <summary>
        /// Returns <c>true</c> if the client is still connected.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        protected override bool ValidateClient(string endpoint, HttpCommunicationClient client)
        {
            return true;
        }

        /// <summary>
        /// Aborts the given client.
        /// </summary>
        /// <param name="client"></param>
        protected override void AbortClient(HttpCommunicationClient client)
        {
            // HTTP doesn't maintain a communication channel, so nothing to abort
        }

    }

}
