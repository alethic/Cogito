using System.Activities.Hosting;
using System.Collections.Generic;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides helper services to <see cref="AsyncNativeActivity"/>.
    /// </summary>
    public class AsyncNativeActivityExtension :
        IWorkflowInstanceExtension
    {

        WorkflowInstanceProxy instance;

        IEnumerable<object> IWorkflowInstanceExtension.GetAdditionalExtensions()
        {
            yield break;
        }

        void IWorkflowInstanceExtension.SetInstance(WorkflowInstanceProxy instance)
        {
            this.instance = instance;
        }

        /// <summary>
        /// Gets the <see cref="WorkflowInstanceProxy"/>.
        /// </summary>
        public WorkflowInstanceProxy Instance
        {
            get { return instance; }
        }

    }

}
