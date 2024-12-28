using DoAn2VADT.Database.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAn2VADT.Database.Entities
{
    [Table("Coupons")]
    public class Coupon : BaseEntity
    {
        public new Guid Id { get; set; } // Sửa kiểu dữ liệu thành Guid

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string Code { get; set; } // Mã giảm giá

        [Required]
        public int Discount { get; set; } // Phần trăm giảm giá

        [Column(TypeName = "date")]
        [Required]
        public DateTime ExpiryDate { get; set; } // Ngày hết hạn
    }
}
