using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc
{

    /// <summary>
    /// Base MVC lifecycle component that only fires events if MVC is enabled.
    /// </summary>
    public abstract class MvcLifecycleComponent : LifecycleComponent
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        public MvcLifecycleComponent(
            IMvcConfiguration configuration)
            : base(() => configuration.Configured)
        {

        }

    }

}
