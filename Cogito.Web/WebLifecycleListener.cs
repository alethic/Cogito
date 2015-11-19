using Cogito.Application.Lifecycle;

namespace Cogito.Web
{

    /// <summary>
    /// Base Web lifecycle component that only fires events if WebApi is enabled.
    /// </summary>
    public abstract class WebLifecycleListener :
        LifecycleListener<IWebModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WebLifecycleListener()
            : base()
        {

        }

    }

}
