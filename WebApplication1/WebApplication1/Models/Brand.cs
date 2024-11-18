using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required, StringLength(100)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
