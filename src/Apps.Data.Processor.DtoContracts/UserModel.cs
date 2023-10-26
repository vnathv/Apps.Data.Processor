using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apps.Data.Processor.Infrastructure
{
    public class UserModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string DataValue { get; set; }
    }
}