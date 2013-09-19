namespace Cogito.Build.Common
{

    /// <summary>
    /// Simple logging information so core logic can communicate with caller.
    /// </summary>
    public interface ILogger
    {

        void WriteDebug(string message);

        void WriteDebug(string format, params object[] args);

        void WriteInfo(string message);

        void WriteInfo(string format, params object[] args);

        void WriteWarning(string message);

        void WriteWarning(string format, params object[] args);

        void WriteError(string message);

        void WriteError(string format, params object[] args);

    }

}
