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
        readonly bool watch;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="configurationFilePath"></param>
        /// <param name="watch"></param>
        public ApplicationInfo(string name, string path, string configurationFilePath, bool watch)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(name));
            Contract.Requires<ArgumentNullException>(path != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(path));

            this.name = name;
            this.path = path;
            this.configurationFilePath = configurationFilePath ?? System.IO.Path.Combine(path, "Components.config");
            this.watch = watch;
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

        /// <summary>
        /// Gets whether or not changes should be watched for if possible.
        /// </summary>
        public bool Watch
        {
            get { return watch; }
        }

    }

}
