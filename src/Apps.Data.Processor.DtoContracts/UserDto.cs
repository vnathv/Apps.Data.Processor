using System.ComponentModel.DataAnnotations;

namespace Apps.Data.Processor.Infrastructure
{
    public class UserDto
    {
        public int RecordId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}