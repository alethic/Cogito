using System.Web.Http;

using Cogito.Application;

namespace Cogito.Web.Http
{

    public interface IApiApplication : IApplication
    {

        /// <summary>
        /// Activates the web application components.
        /// </summary>
        /// <param name="http"></param>
        void Activate(HttpConfiguration http);

        /// <summary>
        /// Gets whether or not the WebApi framework is activated.
        /// </summary>
        bool Activated { get; }

        /// <summary>
        /// Gets the <see cref="HttpConfiguration"/>.
        /// </summary>
        HttpConfiguration Http { get; }

    }

}
