using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
