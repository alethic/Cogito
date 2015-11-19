using System;

namespace Cogito
{

    /// <summary>
    /// Simple event args that holds a single value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueEventArgs<T> :
        EventArgs
    {

        readonly T value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public ValueEventArgs(T value)
        {
            this.value= value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value
        {
            get { return value; }
        }

    }

}
