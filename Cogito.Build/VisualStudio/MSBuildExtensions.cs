using System;
using System.Diagnostics.Contracts;
using System.IO;
using Cogito.Build.Common;
using Microsoft.Build.Evaluation;

namespace Cogito.Build.VisualStudio
{

    /// <summary>
    /// Various extension methods for working against the MSBuild instances.
    /// </summary>
    public static class MSBuildExtensions
    {

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static string GetName(this Project project)
        {
            Contract.Requires<ArgumentNullException>(project != null);

            return System.IO.Path.GetFileNameWithoutExtension(project.FullPath);
        }

        /// <summary>
        /// Resolves the given path to an absolute path. If the path given is relative, it is resolved from the point
        /// of view of the project directory.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MakeAbsolutePath(this Project project, string path)
        {
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(path));

            path = project.ExpandString(path);
            if (!System.IO.Path.IsPathRooted(path))
                path = System.IO.Path.Combine(project.DirectoryPath, path);

            return Cogito.Build.Common.Path.NormalizePath(path);
        }

        /// <summary>
        /// Returns the absolute path of the Project's PackagesDir.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static string GetPackagesDir(this Project project)
        {
            Contract.Requires<ArgumentNullException>(project != null);

            var packagesDir = project.GetPropertyValue("PackagesDir");
            if (!string.IsNullOrWhiteSpace(packagesDir))
            {
                packagesDir = MakeAbsolutePath(project, packagesDir);
                if (Directory.Exists(packagesDir))
                    return packagesDir;
            }

            var solutionDir = project.GetPropertyValue("SolutionDir");
            if (!string.IsNullOrWhiteSpace(solutionDir))
            {
                solutionDir = MakeAbsolutePath(project, solutionDir);
                if (Directory.Exists(solutionDir))
                {
                    packagesDir = System.IO.Path.Combine(solutionDir, "packages");
                    if (Directory.Exists(packagesDir))
                        return packagesDir;
                }
            }

            return null;
        }

        public static string MakeRelativePackagePath(this Project project, ILogger log, string path)
        {
            // expand input string
            var relative = project.ExpandString(path);
            log.WriteInfo("Original == '{0}'", path);
            log.WriteInfo("         >> '{0}'", relative);

            // resolve path to absolute
            var absolute = project.MakeAbsolutePath(relative);
            if (!File.Exists(absolute))
            {
                log.WriteInfo("         ?? '{0}'", absolute);
                return null;
            }

            // reference should be underneath packages dir
            if (!absolute.StartsWith(project.GetPackagesDir()))
            {
                log.WriteInfo("         !! '{0}'", absolute);
                return null;
            }

            // generate relative path from packages dir
            var projectPath = Cogito.Build.Common.Path.MakeRelativePath(project.GetPackagesDir(), absolute);
            if (projectPath.StartsWith("." + System.IO.Path.DirectorySeparatorChar) ||
                projectPath.StartsWith("." + System.IO.Path.AltDirectorySeparatorChar))
                projectPath = projectPath.Remove(0, 2);
            log.WriteInfo("         -> '{0}'", projectPath);

            // and finally append variable
            var variablePath = System.IO.Path.Combine("$(PackagesDir)", projectPath);
            log.WriteInfo("         -> '{0}'", projectPath);
            return variablePath;
        }

        /// <summary>
        /// Returns the given path back if it exists.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static string IfExists(string path)
        {
            return Directory.Exists(path) || File.Exists(path) ? path : null;
        }

    }

}
