namespace Cogito.Application
{

    /// <summary>
    /// To be invoked when the application shuts down.
    /// </summary>
    public interface IOnShutdown<T>
        where T : IApplication
    {

        void OnShutdown();

    }

}
