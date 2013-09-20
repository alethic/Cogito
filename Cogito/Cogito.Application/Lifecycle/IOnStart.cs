namespace Cogito.Application
{

    /// <summary>
    /// To be invoked when the application starts.
    /// </summary>
    public interface IOnStart<T>
        where T : IApplication
    {

        void OnStart();

    }

}
