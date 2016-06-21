using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

using Cogito.Collections;

using Microsoft.Diagnostics.Tracing;

namespace Cogito.Net.Http
{

    /// <summary>
    /// Logs HTTP requests and responses.
    /// </summary>
    [EventSource(Name = "Cogito-Net-Http-Messages")]
    sealed class HttpMessageEventSource :
        EventSource
    {

        const string ACTIVITY_CORRELATION_KEY = "Cogito.Net.Http.HttpMessageEventSource.ActivityId";

        /// <summary>
        /// Gets the current <see cref="HttpMessageEventSource"/>.
        /// </summary>
        public static readonly HttpMessageEventSource Current = new HttpMessageEventSource();

        #region Keywords

        public static class Keywords
        {



        }

        #endregion

        const int HttpRequestEventId = 1;
        const int HttpResponseEventId = 2;

        /// <summary>
        /// Records a <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        [NonEvent]
        public void HttpRequest(HttpRequestMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
            {
                // update message with correlation key
                message.Properties.GetOrAdd(ACTIVITY_CORRELATION_KEY, _ => Guid.NewGuid());

                HttpRequest(
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
        [Event(HttpRequestEventId, Level = EventLevel.Verbose, Message = "{0} {1} {2}")]
        public void HttpRequest(
            Guid correlationId,
            string method,
            string requestUri,
            string version,
            string headers,
            string contentHeaders)
        {
            if (IsEnabled())
                WriteEvent(
                    HttpRequestEventId,
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
        public void HttpResponse(HttpResponseMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
                HttpResponse(
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
        [Event(HttpResponseEventId, Level = EventLevel.Verbose, Message = "{0} {1} {2} {4} {5}")]
        public void HttpResponse(
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
                    HttpResponseEventId,
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
