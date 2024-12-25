using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.Database.Entities
{
    [Table("Color")]
    public class Color : BaseEntity
    {
        public new Guid Id { get; set; } // Sửa kiểu dữ liệu thành Guid
        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        public string HexCode { get; set; }
    }
}
