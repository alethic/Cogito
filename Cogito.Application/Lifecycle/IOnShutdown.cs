namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked when the application shuts down.
    /// </summary>
    public interface IOnShutdown<T>
        where T : class
    {

        void OnShutdown();

    }

}
