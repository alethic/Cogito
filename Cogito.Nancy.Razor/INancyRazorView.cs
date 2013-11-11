using System.Collections.Generic;
using System.ComponentModel.Composition;

using Cogito.Composition.Scoping;
using Cogito.Web;

using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Model-associated interface for Nancy Razor views.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [InheritedExport(typeof(INancyRazorView<>))]
    public interface INancyRazorView<TModel> :
        INancyRazorView
    {



    }

    /// <summary>
    /// Interface for Nancy Razor views.
    /// </summary>
    public interface INancyRazorView :
        global::Nancy.ViewEngines.Razor.INancyRazorView
    {

        /// <summary>
        /// Initializes the view.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="renderContext"></param>
        /// <param name="model"></param>
        void Initialize(RazorViewEngine engine, IRenderContext renderContext, object model);

        /// <summary>
        /// Executes the view with the given body and section contents.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="sectionContents"></param>
        void ExecuteView(string body, IDictionary<string, string> sectionContents);

        /// <summary>
        /// Returns <c>true</c> if the view has a model.
        /// </summary>
        object Model { get; }

        /// <summary>
        /// Returns the rendered body of the view.
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets the rendered section contents of the view.
        /// </summary>
        IDictionary<string, string> SectionContents { get; set; }

        /// <summary>
        /// Gets the name of the specified layout.
        /// </summary>
        string Layout { get; set; }

    }

}
