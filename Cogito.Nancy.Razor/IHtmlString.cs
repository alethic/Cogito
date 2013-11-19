namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Describes a raw HTML string.
    /// </summary>
    public interface IHtmlString
    {

        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>An HTML-encoded string.</returns>
        string ToHtmlString();

    }

}
