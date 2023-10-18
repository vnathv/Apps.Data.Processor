using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apps.DataProcessor.DataAccess.Entities
{
    [Table("User")]
    public class User
    {
        public int RecordId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
