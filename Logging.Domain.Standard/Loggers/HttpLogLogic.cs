using Logging.Domain.Common.Enums;
using Logging.Domain.Common.Interfaces;
using Logging.Domain.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Domain.Standard.Loggers
{
    public class HttpLogLogic : ILogLogic, IDisposable
    {
        private const string _logResultsUrl = "http://localhost:55154/api/LogResults";

        private readonly HttpClient _httpClient;

        public HttpLogLogic()
        {
            _httpClient = new HttpClient();
        }

        public void Log(object message) => Log(LogLevel.Debug, message, null);
        public void Log(Exception exception) => Log(LogLevel.Error, null, exception);

        public void Log(LogLevel logLevel, object message, Exception exception)
        {
            var logRecord = new LogRecordModel
            {
                Level = logLevel,
                Message = message,
                Exception = exception
            };

            // TODO: consider batching
            var logRecordsModel = new LogRecordsModel { LogRecords = new[] { logRecord } };

            var result = Post(_logResultsUrl, logRecordsModel).Result;

            var resultString = result.Content.ReadAsStringAsync().Result;

            //Task.Run(() => Post(_logResultsUrl, logRecords));
        }

        private Task<HttpResponseMessage> Post(string url, object data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return _httpClient.PostAsync(url, byteContent);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
