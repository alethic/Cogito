namespace Cogito.Composition
{

    /// <summary>
    /// Describes a value and it's metadata.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TMetadata"></typeparam>
    public interface ILazy<out T, out TMetadata>
        : ILazy<T>
    {

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        TMetadata Metadata { get; }

    }

    public interface ILazy<out T>
    {

        /// <summary>
        /// Gets the value.
        /// </summary>
        bool IsValueCreated { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        T Value { get; }

    }

}
