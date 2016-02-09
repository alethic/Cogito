using System.ComponentModel;
using System.Threading.Tasks;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Internal base implementation of <see cref="StatefulActivityActor"/>.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class StatelessActivityActorBase :
        Cogito.Fabric.StatelessActor
    {

        /// <summary>
        /// Overrides the <see cref="OnActivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override Task OnActivateAsync()
        {
            return OnActivateAsyncHidden();
        }

        /// <summary>
        /// New implementation of <see cref="OnActivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task OnActivateAsyncHidden();

        /// <summary>
        /// Overrides the <see cref="OnDeactivateAsync"/> method so it can be reimplemented above.
        /// </summary>
        /// <returns></returns>
        protected sealed override Task OnDeactivateAsync()
        {
            return OnDeactivateAsyncHidden();
        }

        /// <summary>
        /// New implementation of <see cref="OnDeactivateAsync"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Task OnDeactivateAsyncHidden();

    }

}
