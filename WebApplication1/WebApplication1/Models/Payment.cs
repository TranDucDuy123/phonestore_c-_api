using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Amount { get; set; }

        [StringLength(10)]
        public string Status { get; set; } = "Pending";
    }
}
