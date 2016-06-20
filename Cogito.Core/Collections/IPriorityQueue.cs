namespace Cogito.Collections
{

    /// <summary>
    /// Interface for a priority queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPriorityQueue<T> :
        IQueue<T>
    {

        void Update(T value);

    }

}
