using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Cogito.Build.Common
{

    public static class Path
    {

        const int MAX_PATH = 260;
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
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string MakeRelativePath(string from, string to)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(from));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(to));

            // ensure absolute versions
            from = System.IO.Path.GetFullPath(from);
            to = System.IO.Path.GetFullPath(to);
            
            var path = new StringBuilder(MAX_PATH);
            if (PathRelativePathTo(path, from, GetPathAttribute(from), to, GetPathAttribute(to)) == 0)
                throw new ArgumentException("Paths must have a common prefix");

            return path.ToString();
        }

    }

}
