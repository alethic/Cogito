namespace Cogito.Web
{

    /// <summary>
    /// Provides the ability to resolve URLs for objects.
    /// </summary>
    public interface IUrlResolver
    {

        /// <summary>
        /// Attempts to resolve a url for the given target object.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        string ResolveUrl(object target);

    }

}
