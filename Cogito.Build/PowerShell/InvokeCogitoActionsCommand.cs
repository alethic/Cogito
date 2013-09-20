using System;
using System.Management.Automation;

using Cogito.Build.Common;

namespace Cogito.Build.PowerShell
{

    /// <summary>
    /// Runs the Cogito actions against the solution. 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "CogitoActions")]
    public class InvokeCogitoActionsCommand : Cmdlet, ILogger
    {

        EnvDTE.DTE dte;
        EnvDTE.Project project;

        /// <summary>
        /// EnvDTE environment.
        /// </summary>
        [Parameter(Mandatory = true)]
        public object Dte { get; set; }

        /// <summary>
        /// Specific project being run.
        /// </summary>
        [Parameter(Mandatory = false)]
        public object Project { get; set; }

        /// <summary>
        /// Reference to the package.
        /// </summary>
        [Parameter(Mandatory = false)]
        public object Package { get; set; }

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

                if (project == null)
                    VisualStudio.Commands.Invoke(this, dte);
                else
                    VisualStudio.Commands.Invoke(this, dte, project);
            }
            catch (Exception e)
            {
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

        ILogger ILogger.Enter()
        {
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithDebug(string message)
        {
            ((ILogger)this).WriteDebug(message);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithDebug(string format, params object[] args)
        {
            ((ILogger)this).WriteDebug(format, args);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithInfo(string message)
        {
            ((ILogger)this).WriteInfo(message);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithInfo(string format, params object[] args)
        {
            ((ILogger)this).WriteInfo(format, args);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithWarning(string message)
        {
            ((ILogger)this).WriteWarning(message);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithWarning(string format, params object[] args)
        {
            ((ILogger)this).WriteWarning(format, args);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithError(string message)
        {
            ((ILogger)this).WriteError(message);
            return new LoggerIndentScope(this);
        }

        ILogger ILogger.EnterWithError(string format, params object[] args)
        {
            ((ILogger)this).WriteError(format, args);
            return new LoggerIndentScope(this);
        }

        void IDisposable.Dispose()
        {

        }

    }

}
