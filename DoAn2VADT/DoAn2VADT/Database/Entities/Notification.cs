using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn2VADT.Database.Entities
{
    [Table("Notification")]
    public class Notification : BaseEntity
    {

        [Column("UserId", TypeName = "nvarchar(450)")]
        [Required]
        public string UserId { get; set; }

        [Column("OrderId", TypeName = "nvarchar(450)")]
        [Required]
        public string OrderId { get; set; }

        [Column("Type", TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Column("Message")]
        [Required]
        public string Message { get; set; }

        [Column("Status", TypeName = "nvarchar(50)")]   
        [MaxLength(50)]
        public string Status { get; set; }

        // Các cột kế thừa từ BaseEntity:
        // CreatedAt, UpdatedAt, DeletedAt, CreateUserId, UpdateUserId
    }
}
