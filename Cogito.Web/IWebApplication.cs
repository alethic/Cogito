using System.Web;

using Cogito.Application;

namespace Cogito.Web
{

    public interface IWebApplication : IApplication
    {

        /// <summary>
        /// Activates the web application components.
        /// </summary>
        /// <param name="application"></param>
        void Activate(HttpApplication application);

        /// <summary>
        /// Gets whether or not the application is activated.
        /// </summary>
        bool Activated { get; }

    }

}
