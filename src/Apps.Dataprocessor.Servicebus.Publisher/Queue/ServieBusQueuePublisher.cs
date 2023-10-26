using Apps.Dataprocessor.Servicebus.Publisher.Interfaces;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Dataprocessor.Servicebus.Publisher.Queue
{
    public class ServieBusQueuePublisher : IServiceBusMessagePublisher
    {
        private readonly IServiceBusSenderFactory serviceBusSenderFactory;

        public ServieBusQueuePublisher(IServiceBusSenderFactory serviceBusSenderFactory)
        {
            this.serviceBusSenderFactory = serviceBusSenderFactory;
        }

        public async Task PublishMessageAsync(object payload)
        {
            var message = FormatServiceMessageFormatter(payload);

            ServiceBusSender sender = serviceBusSenderFactory.CreateServiceBusSender();

            await sender.SendMessagesAsync(new List<ServiceBusMessage> { new ServiceBusMessage(message) });

        }

        private static string FormatServiceMessageFormatter(object payload)
        {
            return JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
