using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc
{

    /// <summary>
    /// Base MVC lifecycle component that only fires events if MVC is enabled.
    /// </summary>
    public abstract class MvcLifecycleListener :
        LifecycleListener<IMvcModule>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MvcLifecycleListener()
            : base()
        {

        }

    }

}
