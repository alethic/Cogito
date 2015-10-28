using System;
using System.Diagnostics.Contracts;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Describes an available application to be launched.
    /// </summary>
    public class ApplicationInfo
    {

        readonly string name;
        readonly string path;
        readonly string configurationFilePath;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="configurationFilePath"></param>
        public ApplicationInfo(string name, string path, string configurationFilePath = null)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(name));
            Contract.Requires<ArgumentNullException>(path != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(path));

            this.name = name;
            this.path = path;
            this.configurationFilePath = configurationFilePath ?? System.IO.Path.Combine(path, "Components.config");
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the path of the application.
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        public string ConfigurationFilePath
        {
            get { return configurationFilePath; }
        }

    }

}
