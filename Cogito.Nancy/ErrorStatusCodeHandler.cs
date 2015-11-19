using System.ComponentModel.Composition;
using Cogito.Nancy.Responses;

using Nancy;
using Nancy.ErrorHandling;

namespace Cogito.Nancy
{

    /// <summary>
    /// Intercepts common error condition status codes and formulates a <see cref="ErrorResponse"/> if one isn't already present.
    /// </summary>
    [Export(typeof(IStatusCodeHandler))]
    public class ErrorStatusCodeHandler : IStatusCodeHandler
    {

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            // our custom response is already at play
            if (context.Response is ErrorResponse)
                return false;

            // Nancy usually returns a plain ol' Response, anything else and somebody has customized it
            if (context.Response.GetType() != typeof(Response))
                return false;

            // filter for supported status codes
            switch (statusCode)
            {
                case HttpStatusCode.InternalServerError:
                    return true;
            }

            return false;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var html = false;

            if (html)
            {
                context.Response = ErrorResponse
                    .FromMessage("The resource you requested was not found.", statusCode);

                return;
            }

            switch (statusCode)
            {
                case HttpStatusCode.InternalServerError:
                    break;
            }
        }

    }

}
