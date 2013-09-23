namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked when the application starts.
    /// </summary>
    public interface IOnStart<T>
        where T : class
    {

        void OnStart();

    }

}
