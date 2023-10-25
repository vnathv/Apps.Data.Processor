using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apps.DataProcessor.DataAccess.Entities
{
    [Table(nameof(UserRecord))]
    public class UserRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string DataValue { get; set; }

        public bool NotificationFlag { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }

    }
}
