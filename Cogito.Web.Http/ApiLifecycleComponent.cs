using Cogito.Application.Lifecycle;

namespace Cogito.Web.Http
{

    /// <summary>
    /// Base WebApi lifecycle component that only fires events if WebApi is enabled.
    /// </summary>
    public abstract class ApiLifecycleComponent : LifecycleComponent
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configuration"></param>
        public ApiLifecycleComponent(
            IApiConfiguration configuration)
            : base(() => configuration.Configured)
        {

        }

    }

}
