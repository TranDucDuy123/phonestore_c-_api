using System;
using System.Collections.Generic;

namespace WatchAPI.Datas.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UpdateUserId { get; set; }
        public string? CreateUserId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
