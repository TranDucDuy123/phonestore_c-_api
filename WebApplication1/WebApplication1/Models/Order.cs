using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalAmount { get; set; }

        [StringLength(15)]
        public string Status { get; set; } = "Pending";

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Coupon")]
        public int? CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public int? ShippingId { get; set; }
    }
}
