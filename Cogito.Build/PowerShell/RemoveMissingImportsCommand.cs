using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

using Microsoft.Build.Evaluation;

using Cogito.Build.VisualStudio;

namespace Cogito.Build.PowerShell
{

    /// <summary>
    /// Runs the Cogito actions against the solution. 
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "MissingImports")]
    public class RemoveMissingImportsCommand : Cmdlet
    {

        /// <summary>
        /// Specific project being run against.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        public IEnumerable<object> Projects { get; set; }

        /// <summary>
        /// Executes this action.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (Projects == null)
                Projects = ProjectCollection.GlobalProjectCollection.LoadedProjects;

            var imports = Projects
                .Select(i => ConvertProject(i))
                .Select(i => new { Project = i, Imports = i.Xml.Imports })
                .SelectMany(i => i.Imports.Select(j => new { Project = i.Project, Import = j }));

            // no files
            var missing = imports
                .Where(i => !File.Exists(i.Project.ExpandString(i.Import.Project)))
                .ToList();

            // remove
            foreach (var i in missing)
                i.Project.Xml.RemoveChild(i.Import);
        }

        /// <summary>
        /// Attempts to convert the object into a MSBuild project.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        Project ConvertProject(object o)
        {
            var dte = o as EnvDTE.Project;
            if (dte != null)
                return ProjectCollection.GlobalProjectCollection.LoadedProjects
                    .FirstOrDefault(i => i.GetName() == dte.Name);

            var msb = o as Project;
            if (msb != null)
                return msb;

            return null;
        }

    }

}
