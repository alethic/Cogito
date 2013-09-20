using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;

using Cogito.Build.Common;

using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;

namespace Cogito.Build.VisualStudio
{

    /// <summary>
    /// External commands for manging integration in Visual Studio.
    /// </summary>
    public static class Commands
    {

        /// <summary>
        /// Runs the actions against all projects.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dte"></param>
        public static void Invoke(ILogger log, EnvDTE.DTE dte)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(dte != null);

            // repeat for each project
            foreach (var dteProject in dte.Solution.Projects.OfType<EnvDTE.Project>())
                Invoke(log, dte, dteProject);
        }

        /// <summary>
        /// Runs the actions against a single project.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dteProject"></param>
        public static void Invoke(ILogger log, EnvDTE.DTE dte, EnvDTE.Project dteProject)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(dteProject != null);

            try
            {
                // resolve project in MSBuild environment
                var project = ProjectCollection.GlobalProjectCollection.LoadedProjects
                    .FirstOrDefault(i => i.GetName() == dteProject.Name);
                if (project != null)
                    Invoke(log, project);
            }
            catch (DebugException e)
            {
                log.WriteDebug(e.Message);
            }
            catch (InfoException e)
            {
                log.WriteInfo(e.Message);
            }
            catch (WarningException e)
            {
                log.WriteWarning(e.Message);
            }
            catch (Exception e)
            {
                log.WriteError(e.Message);
            }
        }

        /// <summary>
        /// Runs the actions against the given MSBuild project.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        public static void Invoke(ILogger log, Project project)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);

            using (log = log.EnterWithInfo(project.GetName()))
            {
                // only work with projects that have Cogito.Build installed
                if (project.GetPropertyValue("CogitoBuildEnabled") != "" &&
                    project.GetPropertyValue("CogitoBuildEnabled") != "true")
                    return;

                // remove duplicates of Cogito.Build, done indepentently because they are important
                RemoveDuplicateImports(log, project, "Cogito.Build.props");
                RemoveDuplicateImports(log, project, "Cogito.Build.targets");

                // convert imports relative to the PackagesDir to actually be relative to the PackagesDir
                MakeRelativeImportPaths(log, project);

                // takes HintPaths for references and makes them relative to the PackagesDir
                MakeRelativeHintPaths(log, project);

                // save
                project.Save();
            }
        }

        /// <summary>
        /// Removes duplicate imports for files with the specified name.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        /// <param name="fileName"></param>
        public static void RemoveDuplicateImports(ILogger log, Project project, string fileName)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName));

            using (log = log.EnterWithInfo("RemoveDuplicateImports"))
            using (log = log.EnterWithInfo(fileName))
            {
                // all imports that reference file
                var imports = project.Xml.Imports
                    .Where(i =>
                        i.Project.EndsWith(System.IO.Path.DirectorySeparatorChar + fileName) ||
                        i.Project.EndsWith(System.IO.Path.AltDirectorySeparatorChar + fileName))
                    .ToList();

                // write out debug information
                foreach (var import in imports)
                    log.WriteInfo("Import << '{0}'", import.Project);

                // first import that actually works
                var keeper = imports
                    .Where(i => File.Exists(project.MakeAbsolutePath(i.Project)))
                    .FirstOrDefault();
                if (keeper == null)
                {
                    log.WriteInfo("Keeper == None");
                    return;
                }

                log.WriteInfo("Keeper == '{0}'.", keeper.Project);

                // remove all imports other than the working one
                foreach (var import in imports.Where(i => i != keeper))
                {
                    log.WriteInfo("Remove: '{0}'.", import.Project);
                    project.Xml.RemoveChild(import);
                }

                // reload any changes
                project.ReevaluateIfNecessary();
            }
        }

        /// <summary>
        /// Converts Imports to relative paths if they fall under the package directory.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        public static void MakeRelativeImportPaths(ILogger log, Project project)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);

            using (log = log.EnterWithInfo("MakeRelativeImportPaths"))
            {
                if (project.GetPropertyValue("CogitoMakeRelativeImportPaths") == "false")
                    return;

                // process each import
                foreach (var import in project.Xml.Imports)
                    MakeRelativeImportPath(log, project, import);
            }
        }

        /// <summary>
        /// Converts the specifeid import to a path relative to the packages dir.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        /// <param name="import"></param>
        public static void MakeRelativeImportPath(ILogger log, Project project, ProjectImportElement import)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(import != null);

            // compute new path
            var computed = project.MakeRelativePackagePath(log, import.Project);
            if (computed != null &&
                computed != import.Project)
            {
                import.Project = computed;
                import.Condition = string.Format(@"Exists('{0}')", computed);
                project.ReevaluateIfNecessary();
            }
        }

        /// <summary>
        /// Makes the reference paths which are underneath the packages directory relative and calculated.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        public static void MakeRelativeHintPaths(ILogger log, Project project)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);

            using (log = log.EnterWithInfo("MakeRelativeHintPath"))
            {
                if (project.GetPropertyValue("CogitoMakeRelativeHintPaths") == "false")
                    return;

                foreach (var reference in project.GetItems("Reference"))
                    MakeRelativeHintPath(log, project, reference);
            }
        }

        /// <summary>
        /// Makes the reference path which are underneath the packages directory relative and calculated.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="project"></param>
        /// <param name="reference"></param>
        public static void MakeRelativeHintPath(ILogger log, Project project, ProjectItem reference)
        {
            Contract.Requires<ArgumentNullException>(log != null);
            Contract.Requires<ArgumentNullException>(project != null);
            Contract.Requires<ArgumentNullException>(reference != null);

            // parse assembly name from project
            var assemblyName = new AssemblyName(reference.EvaluatedInclude);
            var packagesDir = project.GetPackagesDir();

            using (log = log.EnterWithInfo("{0}", assemblyName.FullName))
            {
                // does not originate in project file
                if (reference.IsImported)
                    return;

                // metadata of hint path
                var metadata = reference.GetMetadata("HintPath");
                if (metadata == null)
                    return;

                // compute new path
                var computed = project.MakeRelativePackagePath(log, metadata.UnevaluatedValue);
                if (computed != null &&
                    computed != metadata.UnevaluatedValue)
                {
                    metadata.UnevaluatedValue = computed;
                    project.ReevaluateIfNecessary();
                }
            }
        }

    }

}
