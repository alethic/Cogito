using System;

namespace Cogito.Resources
{

    /// <summary>
    /// Appends additional descriptive information to an embedded resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyResourceAttribute :
        Attribute
    {

        readonly string resourceName;
        readonly string name;
        readonly string contentType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        public AssemblyResourceAttribute(string resourceName, string name, string contentType)
        {
            this.resourceName = resourceName;
            this.name = name;
            this.contentType = contentType;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="contentType"></param>
        public AssemblyResourceAttribute(string resourceName, string contentType)
        {
            this.resourceName = resourceName;
            this.contentType = contentType;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resourceName"></param>
        public AssemblyResourceAttribute(string resourceName)
        {
            this.resourceName = resourceName;
        }

        /// <summary>
        /// Name of the resource to provide additional information for.
        /// </summary>
        public string ResourceName
        {
            get { return resourceName; }
        }

        /// <summary>
        /// Name to export the resource as.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Content type of the resource.
        /// </summary>
        public string ContentType
        {
            get { return contentType; }
        }

    }

}
