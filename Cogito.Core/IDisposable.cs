namespace Cogito
{

    /// <summary>
    /// Defines a method to release an allocated resource of the specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDisposable<T>
        : System.IDisposable
    {

        /// <summary>
        /// Gets the disposable resource.
        /// </summary>
        T Resource { get; }

    }

}
