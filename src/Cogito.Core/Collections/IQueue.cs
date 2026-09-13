namespace Cogito.Collections
{

    /// <summary>
    /// Interface for a generic queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T>
    {

        /// <summary>
        /// Gets the number of items in the queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns <c>true</c> if the queue contains this item.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(T value);

        /// <summary>
        /// Inserts the given item into the queue.
        /// </summary>
        /// <param name="value"></param>
        void Enqueue(T value);

        /// <summary>
        /// Pops an item from the queue.
        /// </summary>
        /// <returns></returns>
        T Dequeue();

        /// <summary>
        /// Observes the top item in the queue.
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Converts the queue to an array.
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

    }


}
