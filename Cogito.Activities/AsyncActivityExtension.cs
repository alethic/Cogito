using System;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides helper services to <see cref="AsyncNativeActivity"/>.
    /// </summary>
    public class AsyncActivityExtension :
        IWorkflowInstanceExtension
    {

        readonly SynchronizationContext synchronizationContext;
        WorkflowInstanceProxy instance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="synchronizationContext"></param>
        public AsyncActivityExtension(SynchronizationContext synchronizationContext)
        {
            Contract.Requires<ArgumentNullException>(synchronizationContext != null);

            this.synchronizationContext = synchronizationContext;
        }

        /// <summary>
        /// Gets the <see cref="SynchronizationContext"/> that async operations should be scheduled on.
        /// </summary>
        public SynchronizationContext SynchronizationContext
        {
            get { return synchronizationContext; }
        }

        /// <summary>
        /// Gets the <see cref="WorkflowInstanceProxy"/>.
        /// </summary>
        public WorkflowInstanceProxy Instance
        {
            get { return instance; }
        }

        IEnumerable<object> IWorkflowInstanceExtension.GetAdditionalExtensions()
        {
            yield break;
        }

        void IWorkflowInstanceExtension.SetInstance(WorkflowInstanceProxy instance)
        {
            this.instance = instance;
        }

    }

}
