namespace Cogito.Fabric.Activities
{

    /// <summary>
    /// Describes the status of a Activity actor.
    /// </summary>
    public enum ActivityActorStatus
    {

        /// <summary>
        /// The Activity actor has not yet been initialized.
        /// </summary>
        Uninitialized = 0,

        /// <summary>
        /// The Activity actor has been initialized.
        /// </summary>
        Initialized = 1,

        /// <summary>
        /// The Activity actor is currently executing.
        /// </summary>
        Executing = 2,

        /// <summary>
        /// The Activity actor has been canceled.
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// The Activity actor has aborted.
        /// </summary>
        Faulted = 4,

        /// <summary>
        /// The Activity actor has completed.
        /// </summary>
        Closed = 5,

    }

}
