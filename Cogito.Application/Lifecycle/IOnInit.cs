namespace Cogito.Application
{

    /// <summary>
    /// To be invoked on first initialization.
    /// </summary>
    public interface IOnInit<T>
        where T : IApplication
    {

        void OnInit();

    }

}
