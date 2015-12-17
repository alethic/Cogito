using System;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric.Activities
{

    public class ActivityActorExtension :
        IWorkflowInstanceExtension
    {

        readonly StatefulActorBase actor;
        WorkflowInstanceProxy instance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ActivityActorExtension(StatefulActorBase actor)
        {
            Contract.Requires<ArgumentNullException>(actor != null);

            this.actor = actor;
        }

        public IEnumerable<object> GetAdditionalExtensions()
        {
            yield break;
        }

        public void SetInstance(WorkflowInstanceProxy instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Gets a reference to the actor.
        /// </summary>
        public StatefulActorBase Actor
        {
            get { return actor; }
        }

    }

}
