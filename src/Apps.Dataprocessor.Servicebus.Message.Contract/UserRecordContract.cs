using System;

namespace Apps.Dataprocessor.Servicebus.Message.Contract
{
    public class UserRecordContract
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string DataValue { get; set; }
    }
}
