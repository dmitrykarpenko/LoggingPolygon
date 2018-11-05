using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Common.Enums
{
    public enum LogLevel : byte
    {
        Debug = 1,
        Info,
        Warn,
        Error,
        Fatal,
    }
}
