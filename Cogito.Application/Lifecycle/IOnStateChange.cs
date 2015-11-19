namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked when a lifecycle state changes.
    /// </summary>
    public interface IOnStateChange<T>
    {

        /// <summary>
        /// Invoked when the state changes.
        /// </summary>
        /// <param name="state"></param>
        void OnStateChange(State state);

    }

}
