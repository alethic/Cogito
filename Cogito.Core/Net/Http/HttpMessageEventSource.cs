using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cogito.Net.Http
{

    /// <summary>
    /// Logs HTTP requests and responses.
    /// </summary>
    [EventSource(Name = "Cogito-Net-Http-Messages")]
    sealed class HttpMessageEventSource :
        EventSource
    {

        #region EventData

        [EventData]
        public class HeaderData
        {

            public string Name { get; set; }

            public IEnumerable<string> Values { get; set; }

        }

        #endregion

        /// <summary>
        /// Gets the current <see cref="HttpMessageEventSource"/>.
        /// </summary>
        public static readonly HttpMessageEventSource Current = new HttpMessageEventSource();

        #region Keywords

        public static class Keywords
        {



        }

        #endregion

        const int HttpRequestStartEventId = 1;
        const int HttpRequestStopEventId = 2;

        /// <summary>
        /// Records a <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        [NonEvent]
        public void HttpRequestStart(HttpRequestMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
                HttpRequestStart(
                    message.Method.ToString(),
                    message.RequestUri.ToString(),
                    message.Version.ToString(),
                    HeadersToXml(message.Headers),
                    HeadersToXml(message.Content?.Headers));
        }

        /// <summary>
        /// Records a <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <param name="version"></param>
        /// <param name="headers"></param>
        /// <param name="contentHeaders"></param>
        [Event(HttpRequestStartEventId, Level = EventLevel.Verbose, Message = "{0} {1}")]
        public void HttpRequestStart(
            string method,
            string requestUri,
            string version,
            IEnumerable<HeaderData> headers,
            IEnumerable<HeaderData> contentHeaders)
        {
            if (IsEnabled())
                WriteEvent(
                    HttpRequestStartEventId,
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
        public void HttpRequestStop(HttpResponseMessage message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            if (IsEnabled())
                HttpRequestStop(
                    message.RequestMessage.Method.ToString(),
                    message.RequestMessage.RequestUri.ToString(),
                    message.RequestMessage.Version.ToString(),
                    (int)message.StatusCode,
                    message.ReasonPhrase ?? "",
                    HeadersToXml(message.Headers),
                    HeadersToXml(message.Content?.Headers));
        }

        /// <summary>
        /// Records a <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <param name="version"></param>
        /// <param name="statusCode"></param>
        /// <param name="reasonPhrase"></param>
        /// <param name="responseHeaders"></param>
        /// <param name="responseContentHeaders"></param>
        [Event(HttpRequestStopEventId, Level = EventLevel.Verbose, Message = "{0} {1} {2} {4}")]
        public void HttpRequestStop(
            string method,
            string requestUri,
            string version,
            int statusCode,
            string reasonPhrase,
            IEnumerable<HeaderData> responseHeaders,
            IEnumerable<HeaderData> responseContentHeaders)
        {
            if (IsEnabled())
                WriteEvent(
                    HttpRequestStopEventId,
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
        IEnumerable<HeaderData> HeadersToXml(HttpHeaders headers)
        {
            return headers != null ? headers.Select(i => new HeaderData() { Name = i.Key, Values = i.Value }) : null;
        }

    }

}
