using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Net.Http;

using Microsoft.ServiceFabric.Services.Communication.Client;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Implements a <see cref="ICommunicationClient"/> for interacting with HTTP services.
    /// </summary>
    public class HttpCommunicationClient :
        ICommunicationClient,
        IDisposable
    {

        readonly Lazy<HttpClient> http;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="timeout"></param>
        public HttpCommunicationClient(Uri baseAddress, TimeSpan timeout)
        {
            Contract.Requires<ArgumentNullException>(baseAddress != null);

            BaseAddress = baseAddress;
            Timeout = timeout;

            // generate HttpClient on demand
            http = new Lazy<HttpClient>(() => CreateHttpClient());
        }

        /// <summary>
        /// Creates the <see cref="HttpClient"/> instance to be used.
        /// </summary>
        /// <returns></returns>
        HttpClient CreateHttpClient()
        {
            return new HttpClient()
            {
                Timeout = Timeout
            };
        }

        /// <summary>
        /// The service base address.
        /// </summary>
        public Uri BaseAddress { get; private set; }

        /// <summary>
        /// Represents the timeout value for a HTTP request.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// The resolved service partition which contains the resolved service endpoints.
        /// </summary>
        public ResolvedServicePartition ResolvedServicePartition { get; set; }

        /// <summary>
        /// Gets the <see cref="HttpClient"/> instance to communicate with this service.
        /// </summary>
        public HttpClient Http
        {
            get { return http.Value; }
        }

        /// <summary>
        /// Gets a relative URI to the base address of the service.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Uri GetRelativeUri(string path)
        {
            Contract.Requires<ArgumentNullException>(path != null);

            return new Uri(BaseAddress, path);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            if (http.IsValueCreated)
                http.Value.Dispose();
        }

    }

}
