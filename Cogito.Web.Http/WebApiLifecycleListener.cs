using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http
{

    /// <summary>
    /// Base WebApi lifecycle component that only fires events if WebApi is enabled.
    /// </summary>
    public abstract class WebApiLifecycleListener :
        LifecycleListener<IWebApiModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        public WebApiLifecycleListener(
            IWebApiModule module)
            : base()
        {

        }

    }

}
