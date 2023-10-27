using Apps.Dataprocessor.Common.Interfaces;
using Apps.Dataprocessor.Servicebus.Publisher.Interfaces;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace Apps.Dataprocessor.Servicebus.Publisher.Factories
{
    public class ServiceBusSenderFactory : IServiceBusSenderFactory
    {
        private readonly IConfiguration configuration;
        private readonly ISecretReader keyvaultSecretReader;

        public ServiceBusSenderFactory(IConfiguration configuration, ISecretReader keyvaultSecretReader)
        {
            this.configuration = configuration;
            this.keyvaultSecretReader = keyvaultSecretReader;
        }
        public ServiceBusSender CreateServiceBusSender()
        {
            var clientOptions = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };

            ServiceBusClient serviceBusClient = new ServiceBusClient(keyvaultSecretReader.GetSecret(configuration["KeyVaultUrl"],configuration["ServiceBusDataProcessorConnection"]), clientOptions);

            return serviceBusClient.CreateSender(configuration["ServiceBusQueueName"]);
        }
    }
}
