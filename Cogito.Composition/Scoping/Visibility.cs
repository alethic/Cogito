namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Describes the availability of an export to children scopes of the container hosting the export.
    /// </summary>
    public enum Visibility
    {

        /// <summary>
        /// Instances of the part are available to any children scopes.
        /// </summary>
        Inherit,

        /// <summary>
        /// Instances of the part are not available to children scopes.
        /// </summary>
        Local,

    }

}
