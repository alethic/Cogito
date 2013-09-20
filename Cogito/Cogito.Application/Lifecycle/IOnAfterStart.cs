namespace Cogito.Application
{

    /// <summary>
    /// To be invoked just after the application starts.
    /// </summary>
    public interface IOnAfterStart<T>
        where T : IApplication
    {

        void OnAfterStart();

    }

}
