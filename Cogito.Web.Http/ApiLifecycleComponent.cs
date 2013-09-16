using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http
{

    /// <summary>
    /// Base WebApi lifecycle component that only fires events if WebApi is enabled.
    /// </summary>
    public abstract class ApiLifecycleComponent :
        LifecycleComponent<IApiApplication>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="app"></param>
        public ApiLifecycleComponent(
            IApiApplication app)
            : base(() => app.Activated)
        {

        }

    }

}
