using System;
using System.Management.Automation;

using Cogito.Build.Common;

namespace Cogito.Build.PowerShell
{

    /// <summary>
    /// Enables the Cogito project support.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "CogitoProject")]
    public class InvokeCogitoProjectCommand : Cmdlet, ILogger
    {

        EnvDTE.DTE dte;
        EnvDTE.Project project;

        /// <summary>
        /// Package itself.
        /// </summary>
        [Parameter]
        public object Package { get; set; }

        /// <summary>
        /// Reference to the Project being initialized.
        /// </summary>
        [Parameter]
        public object Project { get; set; }

        /// <summary>
        /// Reference to the Project being initialized.
        /// </summary>
        [Parameter]
        public object Dte { get; set; }

        /// <summary>
        /// Executes this action.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                dte = Dte as EnvDTE.DTE;
                project = Project as EnvDTE.Project;

                if (dte == null)
                    throw new WarningException("EnvDTE not available.");

                VisualStudio.Commands.Invoke(this, dte);
            }
            catch (Exception e)
            {
                WriteWarning(e.Message);
                WriteError(new ErrorRecord(e, "Cogito", ErrorCategory.NotSpecified, null));
            }
        }

        void ILogger.WriteDebug(string message)
        {
            WriteDebug(message);
        }

        void ILogger.WriteInfo(string message)
        {
            WriteVerbose(message);
        }

        void ILogger.WriteWarning(string message)
        {
            WriteWarning(message);
        }

        void ILogger.WriteError(string message)
        {
            WriteWarning(message);
            WriteError(new ErrorRecord(new Exception(message), "Cogito", ErrorCategory.NotSpecified, this));
        }

        void ILogger.WriteDebug(string format, params object[] args)
        {
            WriteDebug(string.Format(format, args));
        }

        void ILogger.WriteInfo(string format, params object[] args)
        {
            WriteVerbose(string.Format(format, args));
        }

        void ILogger.WriteWarning(string format, params object[] args)
        {
            WriteWarning(string.Format(format, args));
        }

        void ILogger.WriteError(string format, params object[] args)
        {
            ((ILogger)this).WriteError(string.Format(format, args));
        }

    }

}
