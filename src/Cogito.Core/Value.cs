namespace Cogito
{

    /// <summary>
    /// Simple generic object wrapper.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Value<T>
    {

        readonly T item;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="item"></param>
        public Value(T item)
        {
            this.item = item;
        }

        /// <summary>
        /// Gets the referenced value.
        /// </summary>
        public T Item
        {
            get { return item; }
        }

    }

}
