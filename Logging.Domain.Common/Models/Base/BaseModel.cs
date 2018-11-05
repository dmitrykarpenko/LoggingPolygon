using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Common.Models.Base
{
    public class BaseModel
    {
        public override string ToString() => JsonConvert.SerializeObject(
            this, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
    }
}
