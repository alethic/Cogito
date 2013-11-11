using System;
using System.Globalization;

namespace Cogito.Resources
{

    /// <summary>
    /// Represents a resource.
    /// </summary>
    public interface IResource
    {

        /// <summary>
        /// Gets the name of the package this resource belongs to.
        /// </summary>
        IResourceBundle Bundle { get; }

        /// <summary>
        /// Unique name of the resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Content type of the resource.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the culture of the resource.
        /// </summary>
        CultureInfo CultureInfo { get; }

        /// <summary>
        /// Gets whether or not the resource is available when looking for a debug resource. Debug resources should
        /// only be available in debug mode.
        /// </summary>
        bool? IsDebug { get; }

        /// <summary>
        /// A <see cref="Func"/> which is used to retrieve a new instance of the source object.
        /// </summary>
        Func<object> Source { get; }

    }

}
