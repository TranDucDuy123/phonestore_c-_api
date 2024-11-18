using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; }

        [Required, Range(0.01, 100)]
        public decimal Discount { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
