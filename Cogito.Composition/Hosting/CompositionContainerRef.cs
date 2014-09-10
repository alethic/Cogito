namespace Cogito.Composition.Hosting
{

    /// <summary>
    /// Holds a non-disposable reference to a <see cref="CompositionContainer"/>. Exported to the container by the
    /// container to make the container available.
    /// </summary>
    public class CompositionContainerRef
    {

        readonly CompositionContainer container;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="container"></param>
        public CompositionContainerRef(CompositionContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the referenced <see cref="CompositionContainer"/>.
        /// </summary>
        public CompositionContainer Container
        {
            get { return container; }
        }

    }

}
