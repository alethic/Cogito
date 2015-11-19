namespace Cogito.Composition.Services
{

    /// <summary>
    /// Indicates a component that is instantiated and invoked by the container when it is first discovered.
    /// </summary>
    public interface IOnInitInvoke
    {

        /// <summary>
        /// Invoked when the container is initialized.
        /// </summary>
        void Invoke();

    }

}
