namespace Cogito.Composition.Metadata
{

    /// <summary>
    /// Interface for an item in a <see cref="IMetadata"/>.
    /// </summary>
    public interface IMetadataItem
    {

        string Key { get; }

        object Value { get; }

    }

}
