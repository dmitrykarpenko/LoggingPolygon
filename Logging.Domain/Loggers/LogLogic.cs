using log4net;
using log4net.Core;
using Logging.Domain.Common.Enums;
using Logging.Domain.Common.Interfaces;
using System;

namespace Logging.Domain.Loggers
{
    public class LogLogic : ILogLogic
    {
        private readonly ILog _log;

        public LogLogic(string repositoryName, string loggerName)
        {
            _log = LogManager.GetLogger(repositoryName, loggerName);
        }

        public void Log(object message) => Log(LogLevel.Debug, message, null);
        public void Log(Exception exception) => Log(LogLevel.Error, null, exception);

        public void Log(LogLevel logLevel, object message, Exception exception)
        {
            var level = Map(logLevel);

            _log.Logger.Log(
                null, // will internally default to typeof(Logger), thus, log all the stack
                level,
                message,
                exception);
        }

        private static Level Map(LogLevel logLevel) =>
            logLevel == LogLevel.Debug ? Level.Debug :
            logLevel == LogLevel.Info ? Level.Info :
            logLevel == LogLevel.Warn ? Level.Warn :
            logLevel == LogLevel.Error ? Level.Error :
            logLevel == LogLevel.Fatal ? Level.Fatal :
            throw new NotSupportedException(
                $"Log level {logLevel} is not supported.");
    }
}
