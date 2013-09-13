namespace Cogito.Application
{

    /// <summary>
    /// Provides methods to invoke lifecycle events.
    /// </summary>
    public interface IApplicationLifecycleManager
    {

        void BeforeStart();

        void Start();

        void AfterStart();

        void BeforeShutdown();

        void Shutdown();

    }

}
