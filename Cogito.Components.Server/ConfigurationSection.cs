using System.Configuration;

namespace Cogito.Components.Server
{

    public class ConfigurationSection : 
        System.Configuration.ConfigurationSection
    {

        /// <summary>
        /// Returns the configuration.
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSection GetDefaultSection()
        {
            return (ConfigurationSection)ConfigurationManager.GetSection("cogito.components.server") ?? new ConfigurationSection();
        }

        /// <summary>
        /// Path to the directory from which to load the components.
        /// </summary>
        [ConfigurationProperty("binPath")]
        public string BinPath
        {
            get { return (string)this["binPath"]; }
            set { this["binPath"] = value; }
        }

        /// <summary>
        /// Path to the temporary directory for the loaded components.
        /// </summary>
        [ConfigurationProperty("tmpPath")]
        public string TmpPath
        {
            get { return (string)this["tmpPath"]; }
            set { this["tmpPath"] = value; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }

    }

}