using Logging.Domain.Common.Interfaces;
using Logging.Domain.Loggers;
using System;

namespace Logging.Client
{
    class Program
    {
        private static readonly LogContainerLogic _logContainer = new LogContainerLogic();
        private static readonly ILogLogic _log = _logContainer.GetLog();

        static void Main(string[] args)
        {
            _log.Log("Hello World! " + DateTime.Now);
            Console.WriteLine("Hello World!");
        }
    }
}
