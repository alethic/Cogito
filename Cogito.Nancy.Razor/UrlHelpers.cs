using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Helpers for url related functions.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class UrlHelpers<TModel>
    {

        readonly IRenderContext renderContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlHelpers&lt;TModel&gt;"/> class.
        /// </summary>
        /// <param name="renderContext">The render context.</param>
        public UrlHelpers(IRenderContext renderContext)
        {
            this.renderContext = renderContext;
        }

        /// <summary>
        /// The context of the current render operation.
        /// </summary>
        /// <value>An <see cref="IRenderContext"/> intance.</value>
        public IRenderContext RenderContext
        {
            get { return renderContext; }
        }

        /// <summary>
        /// Retrieves the absolute url of the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public string Content(string path)
        {
            return renderContext.ParsePath(path);
        }

    }

}
