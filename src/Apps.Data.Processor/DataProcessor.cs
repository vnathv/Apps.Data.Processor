using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Apps.Data.Processor
{
    public class DataProcessor
    {
        [FunctionName("DataProcessor")]
        public void Run([TimerTrigger("*/2 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
