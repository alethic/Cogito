using System.Collections.Generic;

namespace Cogito.Components.Server
{

    /// <summary>
    /// Provides descriptions of applications which should be started and stopped.
    /// </summary>
    public interface IApplicationInfoProvider
    {

        /// <summary>
        /// Gets applications to be started.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ApplicationInfo> GetApplications();

    }

}
