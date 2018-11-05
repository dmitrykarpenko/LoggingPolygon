using Logging.Domain.Common.Interfaces;
using Logging.Domain.Loggers;
using System;

namespace Logging.Client
{
    class Program
    {
        private static readonly LogContainerLogic _logContainer = new LogContainerLogic();
        private static readonly ILogLogic _log = _logContainer.GetLog();
        private static readonly ILogLogic _httpLog = _logContainer.GetLog("HttpLogger");

        static void Main(string[] args)
        {
            _log.Log("Hello World! " + DateTime.Now);

            // TODO: test and tweak 
            _httpLog.Log("Hello World (http)! " + DateTime.Now);

            Console.WriteLine("Hello World!");
        }
    }
}