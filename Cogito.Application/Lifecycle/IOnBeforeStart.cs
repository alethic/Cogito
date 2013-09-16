namespace Cogito.Application
{

    /// <summary>
    /// To be invoked before the application starts.
    /// </summary>
    public interface IOnBeforeStart<T>
        where T : IApplication
    {

        void OnBeforeStart();

    }

}
