﻿using System.Threading.Tasks;

namespace Cogito.ServiceFabric.Activities
{

    /// <summary>
    /// Represents a <see cref="Actor"/> that hosts a Windows Workflow Foundation activity.
    /// </summary>
    public abstract class ActivityActorBase :
        ActivityActorCore
    {

        /// <summary>
        /// Dispatches to user method.
        /// </summary>
        /// <returns></returns>
        protected internal override sealed Task OnActivateAsyncHidden()
        {
            return OnActivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is activated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnActivateAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Dispatches to user method.
        /// </summary>
        /// <returns></returns>
        protected internal override sealed Task OnDeactivateAsyncHidden()
        {
            return OnDeactivateAsync();
        }

        /// <summary>
        /// Invoked when the actor is deactiviated.
        /// </summary>
        /// <returns></returns>
        protected new virtual Task OnDeactivateAsync()
        {
            return Task.FromResult(true);
        }

    }

}
