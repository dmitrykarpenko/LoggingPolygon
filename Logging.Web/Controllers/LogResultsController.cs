using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logging.Domain.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Web.Controllers
{
    [Route("api/[controller]")]
    public class LogResultsController
    {
        //[HttpPost]
        public ActionResult<string> Post([FromBody] LogRecordsModel logRecordsModel)
        {
            return $"preserved log records: {logRecordsModel}";
        }
    }
}
