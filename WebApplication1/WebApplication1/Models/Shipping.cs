using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string ShippingAddress { get; set; }

        [StringLength(100)]
        public string ShippingUnit { get; set; }

        public string TrackingNumber { get; set; }

        public decimal ShippingCost { get; set; }

        [StringLength(15)]
        public string Status { get; set; } = "Not Shipped";

        public DateTime? ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
