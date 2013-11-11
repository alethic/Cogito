using System;
using System.Diagnostics.Contracts;
using System.IO;

using Nancy;

namespace Cogito.Nancy.Responses
{

    /// <summary>
    /// Represents an error result.
    /// </summary>
    public class ErrorResponse : Response
    {

        /// <summary>
        /// Returns a new <see cref="ErrorResponse"/> with the specified message.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ErrorResponse FromMessage(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            return new ErrorResponse(statusCode)
            {
                Message = message,
            };
        }

        /// <summary>
        /// Returns a new <see cref="ErrorResponse"/> derived from the specified <see cref="Exception"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static ErrorResponse FromException(Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            Contract.Requires<ArgumentNullException>(exception != null);

            return new ErrorResponse(statusCode)
            {
                Message = exception.Message,
                Exception = exception,
            };
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        public ErrorResponse(HttpStatusCode statusCode)
            : base()
        {
            StatusCode = statusCode;
            Contents = RenderContents;
        }

        /// <summary>
        /// Gets or sets the message to be returned with the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Exception"/> to be returned with the error.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns></returns>
        void RenderContents(Stream output)
        {
            using (var wrt = new StreamWriter(output))
            {
                wrt.WriteLine(Message);
                wrt.WriteLine();
                wrt.WriteLine(Exception);
            }
        }

    }

}
