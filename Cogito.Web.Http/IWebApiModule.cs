using System.Web.Http;

using Cogito.Application;

namespace Cogito.Web.Http
{

    public interface IWebApiModule : IModule
    {

        /// <summary>
        /// Configures the Web API framework.
        /// </summary>
        void Configure();

        /// <summary>
        /// Configures the Web API framework.
        /// </summary>
        /// <param name="http"></param>
        void Configure(HttpConfiguration http);

        /// <summary>
        /// Gets whether or not the WebApi framework is activated.
        /// </summary>
        bool IsConfigured { get; }

        /// <summary>
        /// Gets the <see cref="HttpConfiguration"/> we are configured against.
        /// </summary>
        HttpConfiguration Http { get; }

    }

}
