using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class ImportDetail
    {
        public string Id { get; set; }
        public decimal? PriceIn { get; set; }
        public int? Quantity { get; set; }
        public decimal Total { get; set; }
        public string ImportId { get; set; }
        public string ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }

        public virtual Import Import { get; set; }
        public virtual Product Product { get; set; }
    }
}
