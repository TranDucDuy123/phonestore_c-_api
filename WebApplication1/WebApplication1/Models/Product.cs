using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Volume { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public string AltText { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
