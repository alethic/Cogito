using System;
using System.Reflection;

namespace Cogito.Web.UI.Razor
{

    /// <summary>
    /// Describes the Razor template of a server control. By default a .cshtml file with the same name as the control
    /// being rendered is used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RazorTemplateAttribute : Attribute
    {

        /// <summary>
        /// initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="resourceName"></param>
        public RazorTemplateAttribute(Assembly assembly, string resourceName)
        {
            Assembly = assembly;
            ResourceName = resourceName;
        }

        /// <summary>
        /// Assembly in which the resource is located.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// Named of the resource.
        /// </summary>
        public string ResourceName { get; private set; }

    }

}
