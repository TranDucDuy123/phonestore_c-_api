using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
            Reviews = new List<Review>();
            Carts = new List<Cart>();
            Notifications = new List<Notification>();
            UserRoles = new List<UserRole>();
        }

        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(255)]
        public string Password { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [StringLength(10)]
        public string Status { get; set; } = "active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
