using System.Web;

using Cogito.Application;

namespace Cogito.Web
{

    public interface IWebModule : IModule
    {

        /// <summary>
        /// Configures the web module using any available configuration methods.
        /// </summary>
        void Configure();

        /// <summary>
        /// Gets whether or not the module is configured.
        /// </summary>
        bool IsConfigured { get; }

    }

}
