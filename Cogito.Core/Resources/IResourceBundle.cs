using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cogito.Resources
{

    /// <summary>
    /// Represents a named and version set of resources.
    /// </summary>
    public interface IResourceBundle :
        IQueryable<IResource>
    {

        /// <summary>
        /// Unique ID of the resource package.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Version of the resource package.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Specifies the dependencies of this bundle.
        /// </summary>
        IEnumerable<Expression<Func<IResourceBundle, bool>>> Dependencies { get; }

    }

}
