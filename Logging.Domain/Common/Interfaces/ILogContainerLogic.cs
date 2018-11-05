using Logging.Domain.Common.Interfaces;

namespace Logging.Domain.Common.Interfaces
{
    public interface ILogContainerLogic
    {
        ILogLogic GetLog();
        ILogLogic GetLog(string loggerName);
    }
}