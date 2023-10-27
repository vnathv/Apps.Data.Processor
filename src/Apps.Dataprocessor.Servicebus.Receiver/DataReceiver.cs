using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Apps.Dataprocessor.Servicebus.Receiver
{
    public class DataReceiver
    {
        [FunctionName("DataReceiver")]
        public void Run([ServiceBusTrigger("dataprocessqueuedevwe ", Connection = "ServiceBusDataProcessorConnection")]string myQueueItem, ILogger log)
        {
            //@Microsoft.KeyVault(VaultName=myvault;SecretName=mysecret)
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
