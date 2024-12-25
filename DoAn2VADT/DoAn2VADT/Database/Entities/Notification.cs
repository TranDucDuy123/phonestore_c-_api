using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.Database.Entities
{
    [Table("Notification")]
    public class Notification : BaseEntity
    {
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string OrderId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
