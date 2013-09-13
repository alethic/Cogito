namespace Cogito.Application
{

    /// <summary>
    /// To be invoked before the application shuts down.
    /// </summary>
    public interface IApplicationBeforeShutdown
    {

        void OnBeforeShutdown();

    }

}
