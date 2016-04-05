using System;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Provides an extension for activities to access the <see cref="ActivityActor{TActivity, TState}"/>.
    /// </summary>
    public class ActivityActorExtension :
        IWorkflowInstanceExtension
    {

        readonly IActivityActor actor;
        WorkflowInstanceProxy instance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorExtension(IActivityActor actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        /// <summary>
        /// When implemented, returns any additional extensions the implementing class requires.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetAdditionalExtensions()
        {
            yield break;
        }

        /// <summary>
        /// Sets the specified target <see cref="WorkflowInstanceProxy"/>.
        /// </summary>
        /// <param name="instance"></param>
        public void SetInstance(WorkflowInstanceProxy instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Gets a reference to the actor.
        /// </summary>
        public IActivityActor Actor
        {
            get { return actor; }
        }

    }

}
