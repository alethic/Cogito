using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Net.Http;

using Microsoft.ServiceFabric.Services.Communication.Client;

namespace Cogito.Fabric.Http
{

    public class HttpCommunicationClient :
        ICommunicationClient
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="address"></param>
        public HttpCommunicationClient(HttpClient client, string address)
        {
            Contract.Requires<ArgumentNullException>(client != null);
            Contract.Requires<ArgumentNullException>(address != null);

            HttpClient = client;
            Url = new Uri(address);
        }

        public HttpClient HttpClient { get; }

        public Uri Url { get; }

        ResolvedServiceEndpoint ICommunicationClient.Endpoint { get; set; }

        string ICommunicationClient.ListenerName { get; set; }

        ResolvedServicePartition ICommunicationClient.ResolvedServicePartition { get; set; }

    }


}
