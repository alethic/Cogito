using System.Collections.Generic;

using Cogito.Web.Razor;

using Nancy.ViewEngines;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Model-associated interface for Nancy Razor views.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface INancyRazorView<TModel> :
        INancyRazorView
    {

        /// <summary>
        /// Returns <c>true</c> if the view has a model.
        /// </summary>
        new TModel Model { get; }

    }

    /// <summary>
    /// Interface for Nancy Razor views.
    /// </summary>
    public interface INancyRazorView :
        IRazorTemplate
    {

        /// <summary>
        /// Initializes the view.
        /// </summary>
        /// <param name="renderContext"></param>
        /// <param name="model"></param>
        void Initialize(INancyRazorRenderContext renderContext, object model);

        /// <summary>
        /// Executes the view with the given body and section contents.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="sectionContents"></param>
        void ExecuteView(string body, IDictionary<string, string> sectionContents);

        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns <c>true</c> if the view has a model.
        /// </summary>
        object Model { get; }

        /// <summary>
        /// Gets the produced body.
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets the produced sections.
        /// </summary>
        IDictionary<string, string> SectionContents { get; }

        /// <summary>
        /// Gets the name of the required layout.
        /// </summary>
        string Layout { get; }

        /// <summary>
        /// Renders the body.
        /// </summary>
        /// <returns></returns>
        object RenderBody();

        /// <summary>
        /// Renders the section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns></returns>
        object RenderSection(string sectionName);

        /// <summary>
        /// Renders the section.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        object RenderSection(string sectionName, bool required);

        /// <summary>
        /// Renders the specified model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        object RenderPartial<T>(T model);

        /// <summary>
        /// Renders the specified model with the view with the given name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        object RenderPartial<T>(T model, string viewName);

    }

}
