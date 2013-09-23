namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked before the application shuts down.
    /// </summary>
    public interface IOnBeforeShutdown<T>
        where T : class
    {

        void OnBeforeShutdown();

    }

}
