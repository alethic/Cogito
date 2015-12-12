using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;

namespace Cogito.Fabric.Http
{

    /// <summary>
    /// Factory that creates clients that know to communicate with the WordCount service.
    /// Contains a service partition resolver that resolves a partition key
    /// and sets BaseAddress to the address of the replica that should serve a request.
    /// </summary>
    public class HttpCommunicationClientFactory :
        CommunicationClientFactoryBase<HttpCommunicationClient>
    {

        static readonly Lazy<HttpCommunicationClientFactory> default_ = new Lazy<HttpCommunicationClientFactory>(() => CreateDefault(), true);

        /// <summary>
        /// Creates the default <see cref="HttpCommunicationClientFactory"/> instance.
        /// </summary>
        /// <returns></returns>
        static HttpCommunicationClientFactory CreateDefault()
        {
            return new HttpCommunicationClientFactory(ServicePartitionResolver.GetDefault(), TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Gets the default <see cref="HttpCommunicationClientFactory"/>.
        /// </summary>
        public static HttpCommunicationClientFactory Default
        {
            get { return default_.Value; }
        }

        static TimeSpan MaxRetryBackoffIntervalOnNonTransientErrors = TimeSpan.FromSeconds(3);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="timeout"></param>
        public HttpCommunicationClientFactory(ServicePartitionResolver resolver, TimeSpan timeout)
            : base(resolver, null, null)
        {
            Contract.Requires<ArgumentNullException>(resolver != null);

            Timeout = timeout;
        }

        /// <summary>
        /// Represents the value for operation timeout. Passed to clients.
        /// </summary>
        public TimeSpan Timeout { get; set; }

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
        /// Returns <c>true</c> if the client is still connected.
        /// </summary>
        /// <param name="clientChannel"></param>
        /// <returns></returns>
        protected override bool ValidateClient(HttpCommunicationClient clientChannel)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        protected override void AbortClient(HttpCommunicationClient client)
        {
            // HTTP  doesn't maintain a communication channel, so nothing to abort
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpCommunicationClient> CreateClientAsync(string endpoint, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(endpoint) || !endpoint.StartsWith("http"))
                throw new InvalidOperationException("The endpoint address is not valid. Please resolve again.");

            if (!endpoint.EndsWith("/"))
                endpoint = endpoint + "/";

            // generate new communication client
            return Task.FromResult(new HttpCommunicationClient(
                new Uri(endpoint),
                Timeout));
        }

        /// <summary>
        /// Handles specified exceptions from the communication client.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override bool OnHandleException(Exception e, out ExceptionHandlingResult result)
        {
            if (e is TaskCanceledException)
            {
                return CreateExceptionHandlingResult(true, out result);
            }

            if (e is HttpRequestException)
            {
                var we = e as HttpRequestException;
                return CreateExceptionHandlingResult(false, out result);
            }

            return base.OnHandleException(e, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTransient"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool CreateExceptionHandlingResult(bool isTransient, out ExceptionHandlingResult result)
        {
            result = new ExceptionHandlingRetryResult()
            {
                IsTransient = isTransient,
                RetryDelay = TimeSpan.FromMilliseconds(MaxRetryBackoffIntervalOnNonTransientErrors.TotalMilliseconds),
            };

            return true;
        }

    }

}
