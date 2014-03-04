using Cogito.Resources;

namespace Cogito.Web.Resources
{

    /// <summary>
    /// Additional properties available to script resources.
    /// </summary>
    public interface IWebScriptResource :
         IResource
    {

        /// <summary>
        /// Gets the resource name applied to a <see cref="ScriptManager"/> definition.
        /// </summary>
        string ScriptResourceName { get; }

    }

}
