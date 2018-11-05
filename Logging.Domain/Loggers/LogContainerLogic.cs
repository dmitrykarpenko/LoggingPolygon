using Logging.Domain.Common.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Loggers
{
    // should be instantiated as a singleton
    public class LogContainerLogic : ILogContainerLogic
    {
        private readonly ConcurrentDictionary<string, ILogLogic> _logs =
            new ConcurrentDictionary<string, ILogLogic>();

        private bool _isConfigured = false;

        private readonly object _lock = new object();

        private string _repositoryName;

        public LogContainerLogic()
        {
        }

        private void ConfigureIfNot()
        {
            if (!_isConfigured)
            {
                lock (_lock)
                {
                    if (!_isConfigured)
                    {
                        Configure();
                        _isConfigured = true;
                    }
                }
            }
        }

        private void Configure()
        {
            // TODO: consider injecting
            var assembly = Assembly.GetEntryAssembly();

            log4net.GlobalContext.Properties["EntryAssemblyName"] = assembly.GetName().Name;
            log4net.GlobalContext.Properties[nameof(Guid.NewGuid)] = new GuidWrapper();

            var logRepository = log4net.LogManager.GetRepository(assembly);
            _repositoryName = logRepository.Name;

            log4net.Config.XmlConfigurator.Configure(
                logRepository,
                new FileInfo("log4net.common.config"));
        }

        private class GuidWrapper
        {
            public override string ToString() => Guid.NewGuid().ToString();
        }

        public ILogLogic GetLog() => GetLog(null);

        public ILogLogic GetLog(string loggerName)
        {
            ConfigureIfNot();

            if (loggerName == null)
            {
                loggerName = "DefaultLoggerName";
            }

            return _logs.GetOrAdd(
                loggerName,
                ln => new LogLogic(_repositoryName, ln));
        }
    }
}
