using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.Database.Entities
{
    [Table("ProductColor")]
    public class ProductColor : BaseEntity
    {
        public new Guid Id { get; set; } // Sửa kiểu dữ liệu thành Guid

        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        public Guid ColorId { get; set; } // Đổi kiểu dữ liệu từ string sang Guid

        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsDefault { get; set; }
    }
}
