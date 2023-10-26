using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Dataprocessor.Servicebus.Publisher.Interfaces
{
    public interface IServiceBusMessagePublisher
    {
        Task PublishMessageAsync(object payload);
    }
}
