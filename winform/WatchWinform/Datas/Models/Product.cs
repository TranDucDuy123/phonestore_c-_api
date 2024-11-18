using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Feedbacks = new HashSet<Feedback>();
            ImportDetails = new HashSet<ImportDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }
        public bool? Effective { get; set; }
        public string Color { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
