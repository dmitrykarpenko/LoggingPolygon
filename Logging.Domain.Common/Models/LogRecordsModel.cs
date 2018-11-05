using Logging.Domain.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Common.Models
{
    public class LogRecordsModel : BaseModel
    {
        public LogRecordModel[] LogRecords { get; set; }
    }
}
