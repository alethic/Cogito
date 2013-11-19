using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;

namespace Cogito.Nancy.Razor
{

    /// <summary>
    /// Describes a Razor view.
    /// </summary>
    public struct RazorViewDefinition
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="name"></param>
        /// <param name="stream"></param>
        public RazorViewDefinition(
            string ns,
            string name,
            Stream stream,
            IEnumerable<Assembly> referencedAssemblies)
            : this()
        {
            Contract.Requires<ArgumentNullException>(ns != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(ns));
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(name));
            Contract.Requires<ArgumentNullException>(stream != null);
            Contract.Requires<ArgumentNullException>(referencedAssemblies != null);

            Namespace = ns;
            Name = name;
            Stream = stream;
            ReferencedAssemblies = referencedAssemblies;
        }

        /// <summary>
        /// Gets or sets the namespace of the resource.
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// Name of the template.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Data of the template.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Set of additional <see cref="Assembly"/>s to reference.
        /// </summary>
        public IEnumerable<Assembly> ReferencedAssemblies { get; private set; }

    }

}
