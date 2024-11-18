using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? ShipDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
        public string CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }
        public string PayStatus { get; set; }
        public string PayWay { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string Code { get; set; }
        public decimal? ShipFee { get; set; }
        public string Reason { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Account UpdateUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
