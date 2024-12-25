using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.Database.Entities
{
    [Table("Coupons")]
    public class Coupon : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string Code { get; set; }

        [Required]
        public int Discount { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDate { get; set; }
    }
}
