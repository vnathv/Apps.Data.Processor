using System;
using Apps.Data.Processor.Provider.Interface;
using Apps.DataProcessor.DataAccess.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Apps.Data.Processor
{
    public class DataProcessor
    {
        private readonly IUserProvider userProvider;

        public DataProcessor(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        [FunctionName("DataProcessor")]
        public void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var users = userProvider.GetLastUpdatedUsers(DateTime.Now, -15);            
        }
    }
}
