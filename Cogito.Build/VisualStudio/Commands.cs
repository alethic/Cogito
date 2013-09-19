using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using Cogito.Build.Common;
using Microsoft.Build.Evaluation;

namespace Cogito.Build.VisualStudio
{

    /// <summary>
    /// External commands for manging integration in Visual Studio.
    /// </summary>
    public static class Commands
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dte"></param>
        public static void Invoke(ILogger log, EnvDTE.DTE dte)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(dte != null);

            foreach (var p in dte.Solution.Projects.OfType<EnvDTE.Project>())
                Invoke(log, p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dteProject"></param>
        public static void Invoke(ILogger log, EnvDTE.Project dteProject)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(dteProject != null);
            log.WriteDebug(string.Format("    {0}", dteProject.Name));

            try
            {
                var project = ProjectCollection.GlobalProjectCollection.LoadedProjects
                    .FirstOrDefault(i => System.IO.Path.GetFileNameWithoutExtension(i.Xml.FullPath) == dteProject.Name);
                if (project == null)
                    return;

                Invoke(log, project);
            }
            catch (DebugException e)
            {
                log.WriteDebug(e.Message);
            }
            catch (WarningException e)
            {
                log.WriteWarning(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        public static void Invoke(ILogger log, Project project)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);

            log.WriteInfo(project.FullPath);

            // only work with projects that have Cogito.Build installed
            if (project.GetPropertyValue("CogitoBuildEnabled") != "true")
                return;

            MakeRelativeHintPaths(log, project);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        public static void MakeRelativeHintPaths(ILogger log, Project project)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);
            log.WriteDebug("Cogito.MakeRelativeHintPath:: {0}", new FileInfo(project.FullPath).Name);

            // preferred directory of packages
            var packagesDir = project.GetPropertyValue("PackagesDir");
            log.WriteInfo("PackageDir:: {0}", packagesDir);
            if (string.IsNullOrWhiteSpace(packagesDir))
                throw new WarningException("    PackagesDir undefined.");
            else if (!Directory.Exists(packagesDir))
                throw new WarningException("    PackgesDir not found at {0}.", packagesDir);

            // can be disabled
            if (project.GetPropertyValue("CogitoMakeRelativeHintPaths") == "false")
                throw new DebugException("    disabled");

            // work each reference
            foreach (var reference in project.GetItems("Reference"))
                MakeRelativeHintPathToPackagesDir(log, project, reference, System.IO.Path.GetFullPath(packagesDir));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        /// <param name="reference"></param>
        /// <param name="packagesDir"></param>
        public static void MakeRelativeHintPathToPackagesDir(ILogger log, Project project, ProjectItem reference, string packagesDir)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(reference != null);

            // attempt to parse assembly name
            var assemblyName = new AssemblyName(reference.EvaluatedInclude);
            log.WriteDebug(string.Format("    AssemblyName: {0}", assemblyName.Name));

            // does not originate in project file
            if (reference.IsImported)
                return;

            // metadata of hint path
            var hintPath = reference.GetMetadata("HintPath");
            if (hintPath == null)
                return;

            log.WriteDebug(string.Format("    HintPath: {0} -> {1}", hintPath.UnevaluatedValue, hintPath.EvaluatedValue));

            // resolve hint path value; if relative combine with project directory
            var filePath = hintPath.EvaluatedValue;
            if (System.IO.Path.IsPathRooted(filePath) == false)
                filePath = System.IO.Path.Combine(project.DirectoryPath, filePath);

            log.WriteDebug(string.Format("      Resolved To: {0} -> {1}", filePath));

            // reference needs to be in packages dir
            if (!filePath.StartsWith(packagesDir))
                throw new DebugException("    {0} not in PackagesDir.", assemblyName.Name);

            // generate relative path
            var relativePath = Cogito.Build.Common.Path.MakeRelativePath(filePath, packagesDir);
            if (relativePath.StartsWith("." + System.IO.Path.DirectorySeparatorChar) ||
                relativePath.StartsWith("." + System.IO.Path.AltDirectorySeparatorChar))
                relativePath = relativePath.Remove(0, 2);

            // check that the two paths combined point to the proper file
            if (!File.Exists(System.IO.Path.Combine(packagesDir, relativePath)))
                throw new InfoException("    {0} does not exist.", relativePath);

            // final hint path
            var newHintPathValue = System.IO.Path.Combine("$(PackagesDir)", relativePath);
            log.WriteInfo("    {0} -> {1}", hintPath, newHintPathValue);

            // save new hint path value
            hintPath.UnevaluatedValue = newHintPathValue;
        }

    }

}
