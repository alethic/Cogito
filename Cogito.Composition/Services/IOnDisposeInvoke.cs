namespace Cogito.Composition.Services
{

    /// <summary>
    /// Indicates a component that is instantiated and invoked by the container when the container is disposed of.
    /// </summary>
    public interface IOnDisposeInvoke
    {

        /// <summary>
        /// Invoked when the container is disposed.
        /// </summary>
        void Invoke();

    }

}
