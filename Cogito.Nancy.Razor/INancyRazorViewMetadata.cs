namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Describes metadata of an exported Nancy Razor view.
    /// </summary>
    public interface INancyRazorViewMetadata
    {

        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        string Name { get; }

    }

}
