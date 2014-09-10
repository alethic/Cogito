namespace Cogito.Core
{

    public class Value<T>
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

        public T Item
        {
            get { return item; }
        }

    }

}
