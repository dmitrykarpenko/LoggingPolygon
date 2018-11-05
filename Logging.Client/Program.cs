using Logging.Domain.Common.Interfaces;
using Logging.Domain.Loggers;
using Logging.Domain.Standard.Loggers;
using System;

namespace Logging.Client
{
    class Program
    {
        private static readonly LogContainerLogic _logContainer = new LogContainerLogic();

        // works - writes to file
        private static readonly ILogLogic _log = _logContainer.GetLog();

        // doesn't work - probably a misuse of RemotingAppender
        private static readonly ILogLogic _httpLog = _logContainer.GetLog("HttpLogger");

        // works - makes custom HTTP calls
        private static readonly ILogLogic _customHttpLog = new HttpLogLogic();

        static void Main(string[] args)
        {
            _log.Log("Hello World! " + DateTime.Now);

            // TODO: test and tweak 
            _httpLog.Log("Hello World (http)! " + DateTime.Now);

            _customHttpLog.Log("Hello World (http, custom)! " + DateTime.Now);

            Console.WriteLine("Hello World!");

            // required to wait until a "fire and forget" HTTP request
            // will reach the endpoint and come back
            Console.ReadLine();
        }
    }
}