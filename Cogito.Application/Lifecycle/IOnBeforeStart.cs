namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked before the application starts.
    /// </summary>
    public interface IOnBeforeStart<T>
        where T : class
    {

        void OnBeforeStart();

    }

}
