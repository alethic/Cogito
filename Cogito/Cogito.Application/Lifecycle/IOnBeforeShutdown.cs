namespace Cogito.Application
{

    /// <summary>
    /// To be invoked before the application shuts down.
    /// </summary>
    public interface IOnBeforeShutdown<T>
        where T : IApplication
    {

        void OnBeforeShutdown();

    }

}
