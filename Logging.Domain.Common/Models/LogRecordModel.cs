using Logging.Domain.Common.Enums;
using Logging.Domain.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Common.Models
{
    public class LogRecordModel : BaseModel
    {
        public LogLevel Level { get; set; }
        public object Message { get; set; }
        public Exception Exception { get; set; }
    }
}
