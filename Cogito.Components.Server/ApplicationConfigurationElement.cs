using System.Configuration;

namespace Cogito.Components.Server
{

    public class ApplicationConfigurationElement :
        ConfigurationElement
    {

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Path to the directory from which to load the components.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }

        /// <summary>
        /// Gets or sets whether changes to the application directory should initiate a reload.
        /// </summary>
        [ConfigurationProperty("watch", IsRequired =  false, DefaultValue = true)]
        public bool Watch
        {
            get { return (bool)this["watch"]; }
            set { this["watch"] = value; }
        }

    }

}
