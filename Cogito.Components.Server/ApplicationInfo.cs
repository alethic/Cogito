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
        readonly bool shadowCopy;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="configurationFilePath"></param>
        /// <param name="watch"></param>
        /// <param name="shadowCopy"></param>
        public ApplicationInfo(
            string name,
            string path,
            string configurationFilePath,
            bool watch,
            bool shadowCopy)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(name));
            Contract.Requires<ArgumentNullException>(path != null);
            Contract.Requires<ArgumentOutOfRangeException>(!string.IsNullOrWhiteSpace(path));

            this.name = name;
            this.path = path;
            this.configurationFilePath = configurationFilePath ?? System.IO.Path.Combine(path, "Components.config");
            this.watch = watch;
            this.shadowCopy = shadowCopy;
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

        /// <summary>
        /// Gets the path of the configuration file.
        /// </summary>
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

        /// <summary>
        /// Gets whether or not the application should be shadow copied.
        /// </summary>
        public bool ShadowCopy
        {
            get { return shadowCopy; }
        }

    }

}
