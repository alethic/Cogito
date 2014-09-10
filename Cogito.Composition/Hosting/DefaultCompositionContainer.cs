namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Standard <see cref="CompositionContainer"/> that includes the entire application by default.
    /// </summary>
    public class DefaultCompositionContainer :
        CompositionContainer
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public DefaultCompositionContainer()
            : base(new ApplicationCatalog())
        {

        }

    }

}
