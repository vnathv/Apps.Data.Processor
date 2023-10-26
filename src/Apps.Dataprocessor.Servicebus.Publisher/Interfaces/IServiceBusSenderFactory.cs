using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apps.Dataprocessor.Servicebus.Publisher.Interfaces
{
    public interface IServiceBusSenderFactory
    {
        ServiceBusSender CreateServiceBusSender();
    }
}
