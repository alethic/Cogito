using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Provides the application described by the configuration file.
    /// </summary>
    [Export(typeof(IApplicationInfoProvider))]
    public class ConfigurationSectionApplicationInfoProvider :
        IApplicationInfoProvider
    {

        readonly ApplicationInfo[] applications;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConfigurationSectionApplicationInfoProvider()
        {
            this.applications = ConfigurationSection.GetDefaultSection().Applications
                .OfType<ApplicationConfigurationElement>()
                .Select(i => new ApplicationInfo(i.Name, i.Path, null, i.Watch))
                .ToArray();
        }

        public IEnumerable<ApplicationInfo> GetApplications()
        {
            return applications;
        }

    }

}
