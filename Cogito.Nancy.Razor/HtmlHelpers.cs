using Nancy.Security;
using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Helpers to generate html content.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class HtmlHelpers<TModel>
    {

        readonly IRenderContext renderContext;
        readonly TModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlHelpers{T}"/> class.
        /// </summary>
        /// <param name="renderContext">The <see cref="IRenderContext"/> that the helper are being used by.</param>
        /// <param name="model">The model that is used by the page where the helpers are invoked.</param>
        public HtmlHelpers(IRenderContext renderContext, TModel model)
        {
            this.renderContext = renderContext;
            this.model = model;
        }

        /// <summary>
        /// The model that is being used by the current view.
        /// </summary>
        /// <value>An instance of the view model.</value>
        public TModel Model
        {
            get { return model; }
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
        /// Returns an html string composed of raw, non-encoded text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>An <see cref="IHtmlString"/> representation of the raw text.</returns>
        public IHtmlString Raw(string text)
        {
            return new NonEncodedHtmlString(text);
        }

        /// <summary>
        /// Creates an anti-forgery token.
        /// </summary>
        /// <returns>An <see cref="IHtmlString"/> representation of the anti forgery token.</returns>
        public IHtmlString AntiForgeryToken()
        {
            var tokenKeyValue = renderContext.GetCsrfToken();
            return new NonEncodedHtmlString(string.Format("<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/>", tokenKeyValue.Key, tokenKeyValue.Value));
        }

        /// <summary>
        /// Returns current culture name
        /// </summary>
        public string CurrentLocale
        {
            get { return renderContext.Context.Culture.Name; }
        }

        /// <summary>
        /// Returns current authenticated user name
        /// </summary>
        public IUserIdentity CurrentUser
        {
            get { return renderContext.Context.CurrentUser; }
        }

        /// <summary>
        /// Determines if current user is authenticated
        /// </summary>
        public bool IsAuthenticated
        {
            get { return renderContext.Context.CurrentUser != null; }
        }

    }

}