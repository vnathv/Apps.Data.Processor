using System;
using System.Linq;
using System.Threading.Tasks;
using Apps.Data.Processor.Provider.Interface;
using Apps.Dataprocessor.Servicebus.Publisher.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Apps.Data.Processor
{
    public class DataProcessor
    {
        private readonly IUserProvider userProvider;
        private readonly IConfiguration configuration;
        private readonly IServiceBusMessagePublisher serviceBusMessagePublisher;

        public DataProcessor(IUserProvider userProvider, IConfiguration configuration, IServiceBusMessagePublisher serviceBusMessagePublisher)
        {
            this.userProvider = userProvider;
            this.configuration = configuration;
            this.serviceBusMessagePublisher = serviceBusMessagePublisher;
        }
        [FunctionName("DataProcessor")]
        public async Task Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"Data processor executed at: {DateTime.Now}");

            _ = int.TryParse(configuration["DataRetrievalWindowInMinutes"], out int dataRetrievalWindowInMinutes);

            var users = await userProvider.GetLastUpdatedUsers(dataRetrievalWindowInMinutes);

            if (users.Any())
            {
                await serviceBusMessagePublisher.PublishMessageAsync(users);
            }
            else
            {
                logger.LogInformation($"No new/updated records found with the last {dataRetrievalWindowInMinutes * -1} minutes!");
            }

        }


    }


}
