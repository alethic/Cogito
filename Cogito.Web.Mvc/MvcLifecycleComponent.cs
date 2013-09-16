using Cogito.Application.Lifecycle;

namespace Cogito.Web.Mvc
{

    /// <summary>
    /// Base MVC lifecycle component that only fires events if MVC is enabled.
    /// </summary>
    public abstract class MvcLifecycleComponent :
        LifecycleComponent<IMvcApplication>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="app"></param>
        public MvcLifecycleComponent(
            IMvcApplication app)
            : base(() => app.Activated)
        {

        }

    }

}
