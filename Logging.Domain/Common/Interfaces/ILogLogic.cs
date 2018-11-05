using Logging.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Common.Interfaces
{
    public interface ILogLogic
    {
        void Log(Exception exception);
        void Log(LogLevel logLevel, object message, Exception exception);
        void Log(object message);
    }
}
