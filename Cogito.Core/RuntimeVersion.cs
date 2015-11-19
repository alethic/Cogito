using System;
using System.Diagnostics.Contracts;

namespace Cogito
{

    /// <summary>
    /// Adapts a Microsoft Version object to a Cogito Version object.
    /// </summary>
    public class RuntimeVersion :
        Version
    {

        readonly System.Version version;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        public RuntimeVersion(System.Version version)
        {
            Contract.Requires<ArgumentNullException>(version != null);

            this.version = version;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        public RuntimeVersion(int major, int minor, int build, int revision)
            : this(new System.Version(major, minor, build, revision))
        {

        }

        public override string ToVersionString()
        {
            return version.ToString();
        }

    }

}
