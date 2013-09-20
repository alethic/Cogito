namespace Cogito.Application.Lifecycle
{

    public enum State
    {

        Unknown,
        Init,
        BeforeStart,
        Start,
        AfterStart,
        BeforeShutdown,
        Shutdown,

    }

}
