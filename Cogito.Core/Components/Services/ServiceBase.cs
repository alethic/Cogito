using Cogito.Components;

namespace Cogito.Components.Services
{

    /// <summary>
    /// Default <see cref="IService"/> base class.
    /// </summary>
    public abstract class ServiceBase :
        ComponentBase,
        IService
    {

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }

    }

}
