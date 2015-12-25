namespace Cogito.Fabric.Activities
{

    public enum ActivityActorStatus
    {

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> has not yet been initialized.
        /// </summary>
        Uninitialized = 0,

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> has been initialized.
        /// </summary>
        Initialized = 1,

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> is currently executing.
        /// </summary>
        Executing = 2,

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> has been canceled.
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> has aborted.
        /// </summary>
        Faulted = 4,

        /// <summary>
        /// The <see cref="StatefulActivityActor{TActivity, TState}"/> has completed.
        /// </summary>
        Closed = 5,

    }

}
