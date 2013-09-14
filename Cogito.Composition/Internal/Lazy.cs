
namespace Cogito.Composition.Internal
{

    /// <summary>
    /// Internal wrapper class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Lazy<T> : System.Lazy<T>, ILazy<T>
    {

        T value;

        public Lazy(System.Lazy<T> source)
            : base(() => source.Value)
        {
            // just to ensure the field is accurate
            if (source.IsValueCreated)
                value = Value;
        }

    }

    /// <summary>
    /// Internal wrapper class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TMetadata"></typeparam>
    class Lazy<T, TMetadata> : System.Lazy<T, TMetadata>, ILazy<T, TMetadata>
    {

        T value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        public Lazy(System.Lazy<T, TMetadata> source)
            : base(() => source.Value, source.Metadata)
        {
            // just to ensure the field is accurate
            if (source.IsValueCreated)
                value = Value;
        }

    }

}
