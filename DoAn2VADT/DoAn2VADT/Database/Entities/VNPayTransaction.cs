using DoAn2VADT.Database.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.Database.Entities
{
    [Table("VNPayTransaction")]
    public class VNPayTransaction : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string OrderId { get; set; }

        public Order Order { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20)]
        [Required]
        public string PaymentStatus { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        public string ResponseCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        public string BankCode { get; set; }

        public string TransactionMessage { get; set; }
    }
}
