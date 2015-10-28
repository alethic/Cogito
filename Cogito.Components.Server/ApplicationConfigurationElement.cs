using System.Configuration;

namespace Cogito.Components.Server
{
    
    public class ApplicationConfigurationElement :
        ConfigurationElement
    {

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        [ConfigurationProperty("name", IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Path to the directory from which to load the components.
        /// </summary>
        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }

    }

}
