using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;

using Cogito.Collections;

namespace Cogito.Net.Http
{

    /// <summary>
    /// Logs HTTP requests and responses.
    /// </summary>
    [EventSource(Name = "Cogito-Net-Http-Messages")]
    public class HttpMessageEventSource :
        EventSource
    {

        const string ACTIVITY_CORRELATION_KEY = "Cogito.Net.Http.HttpMessageEventSource.ActivityId";

        /// <summary>
        /// Gets the current <see cref="HttpMessageEventSource"/>.
        /// </summary>
        public static readonly HttpMessageEventSource Current = new HttpMessageEventSource();

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static HttpMessageEventSource()
        {
            Task.Run(() => { }).Wait();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        HttpMessageEventSource()
            : base()
        {

        }

        #region Keywords

        public static class Keywords
        {



        }

        #endregion

        const int RequestEventId = 1;
        const int ResponseEventId = 2;

        /// <summary>
        /// Records a <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        [NonEvent]
        public void Request(HttpRequestMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
            {
                // update message with correlation key
                message.Properties.GetOrAdd(ACTIVITY_CORRELATION_KEY, _ => Guid.NewGuid());

                Request(
                    (Guid)message.Properties[ACTIVITY_CORRELATION_KEY],
                    message.Method.ToString(),
                    message.RequestUri.ToString(),
                    message.Version.ToString(),
                    HeadersToXml(message.Headers) ?? "",
                    HeadersToXml(message.Content?.Headers) ?? "");
            }
        }

        /// <summary>
        /// Records a <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <param name="version"></param>
        /// <param name="headers"></param>
        /// <param name="contentHeaders"></param>
        [Event(RequestEventId, Level = EventLevel.Verbose, Message = "{0} {1} {2}")]
        public void Request(
            Guid correlationId,
            string method,
            string requestUri,
            string version,
            string headers,
            string contentHeaders)
        {
            if (IsEnabled())
                WriteEvent(
                    RequestEventId,
                    correlationId,
                    method,
                    requestUri,
                    version,
                    headers,
                    contentHeaders);
        }

        /// <summary>
        /// Records a <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        [NonEvent]
        public void Response(HttpResponseMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
                Response(
                    (Guid?)message.RequestMessage.Properties.GetOrDefault(ACTIVITY_CORRELATION_KEY) ?? Guid.Empty,
                    message.RequestMessage.Method.ToString(),
                    message.RequestMessage.RequestUri.ToString(),
                    message.RequestMessage.Version.ToString(),
                    (int)message.StatusCode,
                    message.ReasonPhrase ?? "",
                    HeadersToXml(message.Headers) ?? "",
                    HeadersToXml(message.Content?.Headers) ?? "");
        }

        /// <summary>
        /// Records a <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <param name="version"></param>
        /// <param name="statusCode"></param>
        /// <param name="reasonPhrase"></param>
        /// <param name="responseHeaders"></param>
        /// <param name="responseContentHeaders"></param>
        [Event(ResponseEventId, Level = EventLevel.Verbose, Message = "{0} {1} {2} {4} {5}")]
        public void Response(
            Guid correlationId,
            string method,
            string requestUri,
            string version,
            int statusCode,
            string reasonPhrase,
            string responseHeaders,
            string responseContentHeaders)
        {
            if (IsEnabled())
                WriteEvent(
                    ResponseEventId,
                    correlationId,
                    method,
                    requestUri,
                    version,
                    statusCode,
                    reasonPhrase,
                    responseHeaders,
                    responseContentHeaders);
        }

        /// <summary>
        /// Converts a set of headers into an XML representation.
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        string HeadersToXml(HttpHeaders headers)
        {
            return headers != null ? new XElement("Headers", headers.Select(i => new XElement(i.Key, i.Value))).ToString() : null;
        }

    }

}
