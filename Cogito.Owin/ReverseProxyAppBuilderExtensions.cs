using System;
using System.Diagnostics.Contracts;

using Owin;

namespace Cogito.Owin
{

    public static class ReverseProxyAppBuilderExtensions
    {

        /// <summary>
        /// Adds a middleware component that unpacks reverse proxy headers.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IAppBuilder UseReverseProxyRewrite(this IAppBuilder app)
        {
            Contract.Requires<ArgumentNullException>(app != null);

            app.Use((context, next) =>
            {
                // detect original client IP
                if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                    context.Request.RemoteIpAddress = context.Request.Headers["X-Forwarded-For"];

                // detect SSL offload
                if (context.Request.Headers.ContainsKey("X-Forwarded-Proto"))
                    context.Request.Scheme = context.Request.Headers["X-Forwarded-Proto"];

                // deteact IIS ARR SSL
                if (context.Request.Headers.ContainsKey("X-ARR-SSL"))
                    context.Request.Scheme = "https";

                return next();
            });

            return app;
        }

    }

}
