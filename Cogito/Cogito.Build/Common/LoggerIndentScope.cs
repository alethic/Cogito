namespace Cogito.Build.Common
{

    class LoggerIndentScope : ILogger
    {

        ILogger log;

        public LoggerIndentScope(ILogger log)
        {
            this.log = log;
        }

        public void WriteDebug(string message)
        {
            log.WriteDebug("  " + message);
        }

        public void WriteDebug(string format, params object[] args)
        {
            log.WriteDebug("  " + format, args);
        }

        public void WriteInfo(string message)
        {
            log.WriteInfo("  " + message);
        }

        public void WriteInfo(string format, params object[] args)
        {
            log.WriteInfo("  " + format, args);
        }

        public void WriteWarning(string message)
        {
            log.WriteWarning("  " + message);
        }

        public void WriteWarning(string format, params object[] args)
        {
            log.WriteWarning("  " + format, args);
        }

        public void WriteError(string message)
        {
            log.WriteError("  " + message);
        }

        public void WriteError(string format, params object[] args)
        {
            log.WriteError("  " + format, args);
        }

        public ILogger Enter()
        {
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithDebug(string message)
        {
            WriteDebug(message);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithDebug(string format, params object[] args)
        {
            WriteDebug(format, args);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithInfo(string message)
        {
            WriteInfo(message);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithInfo(string format, params object[] args)
        {
            WriteInfo(format, args);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithWarning(string message)
        {
            WriteWarning(message);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithWarning(string format, params object[] args)
        {
            WriteWarning(format, args);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithError(string message)
        {
            WriteError(message);
            return new LoggerIndentScope(this);
        }

        public ILogger EnterWithError(string format, params object[] args)
        {
            WriteError(format, args);
            return new LoggerIndentScope(this);
        }

        public void Dispose()
        {

        }

    }

}
