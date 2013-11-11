using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Cogito
{

    /// <summary>
    /// Represents a semantic version as described by http://semver.org/.
    /// </summary>
    public class SemanticVersion : Version
    {

        readonly static Regex parseEx =
            new Regex(@"^(?<major>\d+)" +
                @"(\.(?<minor>\d+))?" +
                @"(\.(?<patch>\d+))?" +
                @"(\-(?<pre>[0-9A-Za-z\-\.]+))?" +
                @"(\+(?<build>[0-9A-Za-z\-\.]+))?$",
                RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        /// <summary>
        /// Converts the <see cref="SemanticVersion"/> to a <see cref="String"/>.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static implicit operator string(SemanticVersion version)
        {
            Contract.Requires<ArgumentNullException>(version != null);
            return version.ToVersionString();
        }

        /// <summary>
        /// Converts the <see cref="String"/> to a <see cref="SemanticVersion"/>.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static implicit operator SemanticVersion(string version)
        {
            Contract.Requires<ArgumentNullException>(version != null);
            return new SemanticVersion(version);
        }

        /// <summary>
        /// The override of the equals operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is equal to right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator ==(SemanticVersion left, SemanticVersion right)
        {
            return SemanticVersion.Equals(left, right);
        }

        /// <summary>
        /// The override of the un-equal operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is not equal to right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator !=(SemanticVersion left, SemanticVersion right)
        {
            return !SemanticVersion.Equals(left, right);
        }

        /// <summary>
        /// The override of the greater operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is greater than right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator >(SemanticVersion left, SemanticVersion right)
        {
            return SemanticVersion.Compare(left, right) == 1;
        }

        /// <summary>
        /// The override of the greater than or equal operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is greater than or equal to right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator >=(SemanticVersion left, SemanticVersion right)
        {
            return left == right || left > right;
        }

        /// <summary>
        /// The override of the less operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is less than right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator <(SemanticVersion left, SemanticVersion right)
        {
            return SemanticVersion.Compare(left, right) == -1;
        }

        /// <summary>
        /// The override of the less than or equal operator. 
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>If left is less than or equal to right <c>true</c>, else <c>false</c>.</returns>
        public static bool operator <=(SemanticVersion left, SemanticVersion right)
        {
            return left == right || left < right;
        }

        /// <summary>
        /// Parses the given version string into the output semantic version fields.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="patch"></param>
        /// <param name="prerelease"></param>
        /// <param name="build"></param>
        /// <param name="strict"></param>
        static void ParseTo(string version, bool strict, out int major, out int minor, out int patch, out string prerelease, out string build)
        {
            Contract.Requires<ArgumentNullException>(version != null);

            // parse with regular expression
            var match = parseEx.Match(version);
            if (!match.Success)
                throw new ArgumentException("Invalid version.", "version");

            // extract major version
            major = Int32.Parse(match.Groups["major"].Value, CultureInfo.InvariantCulture);

            // extract minor version
            var minorMatch = match.Groups["minor"];
            minor = 0;
            if (minorMatch.Success)
                minor = Int32.Parse(minorMatch.Value, CultureInfo.InvariantCulture);
            else if (strict)
                throw new InvalidOperationException("Invalid version (no minor version given in strict mode)");

            // extract patch
            var patchMatch = match.Groups["patch"];
            patch = 0;
            if (patchMatch.Success)
                patch = Int32.Parse(patchMatch.Value, CultureInfo.InvariantCulture);
            else if (strict)
                throw new InvalidOperationException("Invalid version (no patch version given in strict mode)");

            // extract prerelease and build components
            prerelease = match.Groups["pre"].Value;
            build = match.Groups["build"].Value;
        }

        /// <summary>
        /// Parses the specified string to a semantic version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="strict"></param>
        /// <returns></returns>
        public static SemanticVersion Parse(string version, bool strict = false)
        {
            Contract.Requires<ArgumentNullException>(version != null);

            return new SemanticVersion(version, strict);
        }

        /// <summary>
        /// Parses the specified string to a semantic version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="semanticVersion"></param>
        /// <param name="strict"></param>
        /// <returns></returns>
        public static bool TryParse(string version, out SemanticVersion semanticVersion, bool strict = false)
        {
            Contract.Requires<ArgumentNullException>(version != null);

            try
            {
                semanticVersion = Parse(version, strict);
                return true;
            }
            catch (Exception e)
            {
                semanticVersion = null;
                return false;
            }
        }

        /// <summary>
        /// Compares the two <see cref="SemanticVersion"/>s for equality.
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public static bool Equals(SemanticVersion version1, SemanticVersion version2)
        {
            if (ReferenceEquals(version1, null))
                return ReferenceEquals(version2, null);

            return version1.Equals(version2);
        }

        /// <summary>
        /// Compares the two <see cref="SemanticVersion"/>s.
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public static int Compare(SemanticVersion version1, SemanticVersion version2)
        {
            if (ReferenceEquals(version1, null))
                return ReferenceEquals(version2, null) ? 0 : -1;

            return version1.CompareTo(version2);
        }

        readonly int major;
        readonly int minor;
        readonly int patch;
        readonly string prerelease;
        readonly string build;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        public SemanticVersion(string version, bool strict = false)
        {
            Contract.Requires<ArgumentNullException>(version != null);

            // parse into current instance
            ParseTo(version, strict, out major, out minor, out patch, out prerelease, out build);
            this.prerelease = string.Intern(this.prerelease);
            this.build = string.Intern(this.build);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="patch"></param>
        /// <param name="prerelease"></param>
        /// <param name="build"></param>
        public SemanticVersion(int major, int minor = 0, int patch = 0, string prerelease = "", string build = "")
        {
            this.major = major;
            this.minor = minor;
            this.patch = patch;
            this.prerelease = string.Intern(prerelease ?? "");
            this.build = string.Intern(build ?? "");
        }

        public int Major
        {
            get { return major; }
        }

        public int Minor
        {
            get { return minor; }
        }

        public int Patch
        {
            get { return patch; }
        }

        public string Prerelease
        {
            get { return prerelease; }
        }

        public string Build
        {
            get { return build; }
        }

        /// <summary>
        /// Returns a string representation of the version.
        /// </summary>
        /// <returns></returns>
        public override string ToVersionString()
        {
            var b = new StringBuilder()
                .Append(major).Append(".").Append(minor).Append(".").Append(patch);

            if (!String.IsNullOrEmpty(prerelease))
                b.Append("-").Append(prerelease);

            if (!String.IsNullOrEmpty(build))
                b.Append("+").Append(build);

            return b.ToString();
        }

        /// <summary>
        /// Compares this <see cref="SemanticVersion"/> to another <see cref="Version"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Version other)
        {
            var version = other as SemanticVersion;
            if (version == null)
                return -1;

            return CompareTo(version);
        }

        /// <summary>
        /// Compares this <see cref="SemanticVersion"/> to another <see cref="SemanticVersion"/>.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public int CompareTo(SemanticVersion version)
        {
            return Compare(this, version);
        }

        /// <summary>
        /// Compares this <see cref="SemanticVersion"/> to another <see cref="Version"/> for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Version other)
        {
            var version = other as SemanticVersion;
            if (version == null)
                return false;

            return Equals(version);
        }

        /// <summary>
        /// Compares this <see cref="SemanticVersion"/> to another <see cref="SemanticVersion"/> for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SemanticVersion other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = major.GetHashCode();
                result = result * 31 + minor.GetHashCode();
                result = result * 31 + patch.GetHashCode();
                result = result * 31 + prerelease.GetHashCode();
                result = result * 31 + build.GetHashCode();
                return result;
            }
        }

    }

}
