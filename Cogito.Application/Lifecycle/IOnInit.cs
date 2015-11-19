namespace Cogito.Application.Lifecycle
{

    /// <summary>
    /// To be invoked on first initialization.
    /// </summary>
    public interface IOnInit<T>
    {

        void OnInit();

    }

}
