using System;

namespace Cogito.Build.Common
{

    /// <summary>
    /// Simple logging information so core logic can communicate with caller.
    /// </summary>
    public interface ILogger : IDisposable
    {

        void WriteDebug(string message);

        void WriteDebug(string format, params object[] args);

        void WriteInfo(string message);

        void WriteInfo(string format, params object[] args);

        void WriteWarning(string message);

        void WriteWarning(string format, params object[] args);

        void WriteError(string message);

        void WriteError(string format, params object[] args);

        ILogger Enter();

        ILogger EnterWithDebug(string message);

        ILogger EnterWithDebug(string format, params object[] args);

        ILogger EnterWithInfo(string message);

        ILogger EnterWithInfo(string format, params object[] args);

        ILogger EnterWithWarning(string message);

        ILogger EnterWithWarning(string format, params object[] args);

        ILogger EnterWithError(string message);

        ILogger EnterWithError(string format, params object[] args);

    }

}
