using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;

namespace Cogito.PowerShell
{

    [Cmdlet(VerbsCommon.Get, "RelativePath")]
    public class GetRelativePathCommand : Cmdlet
    {

        const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        const int FILE_ATTRIBUTE_NORMAL = 0x80;

        /// <summary>
        /// Finds the relative path from one absolute path to another.
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="pszFrom"></param>
        /// <param name="dwAttrFrom"></param>
        /// <param name="pszTo"></param>
        /// <param name="dwAttrTo"></param>
        /// <returns></returns>
        [DllImport("shlwapi.dll", SetLastError = true)]
        static extern int PathRelativePathTo(StringBuilder pszPath, string pszFrom, int dwAttrFrom, string pszTo, int dwAttrTo);

        /// <summary>
        /// Gets the FILE_ATTRIBUTE value for the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static int GetPathAttribute(string path)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(path));

            var di = new DirectoryInfo(path);
            if (di.Exists)
                return FILE_ATTRIBUTE_DIRECTORY;

            var fi = new FileInfo(path);
            if (fi.Exists)
                return FILE_ATTRIBUTE_NORMAL;

            throw new FileNotFoundException();
        }

        /// <summary>
        /// Finds the relative path from one absolute path to another.
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="toPath"></param>
        /// <returns></returns>
        protected static string GetRelativePath(string fromPath, string toPath)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(fromPath));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(toPath));

            var fromAttr = GetPathAttribute(fromPath);
            var toAttr = GetPathAttribute(toPath);

            var path = new StringBuilder(260); // MAX_PATH
            if (PathRelativePathTo(path, fromPath, fromAttr, toPath, toAttr) == 0)
                throw new ArgumentException("Paths must have a common prefix");

            // strip leading same-dir
            var p = path.ToString();
            if (p.StartsWith(@"." + Path.DirectorySeparatorChar) ||
                p.StartsWith(@"." + Path.AltDirectorySeparatorChar))
                p = p.Remove(0, 2);

            return p;
        }

        /// <summary>
        /// Source path.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true)]
        public string From { get; set; }

        /// <summary>
        /// Destination path.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true)]
        public string To { get; set; }

        protected override void ProcessRecord()
        {
            Contract.Requires<PSArgumentNullException>(!string.IsNullOrWhiteSpace(From));
            Contract.Requires<PSArgumentNullException>(!string.IsNullOrWhiteSpace(To));

            var from = Path.GetFullPath(From);
            var to = Path.GetFullPath(To);

            WriteObject(GetRelativePath(from, to));
        }

    }

}
