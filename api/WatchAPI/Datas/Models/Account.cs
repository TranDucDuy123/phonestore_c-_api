using System;
using System.Collections.Generic;

namespace WatchAPI.Datas.Models
{
    public partial class Account
    {
        public Account()
        {
            Imports = new HashSet<Import>();
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UpdateUserId { get; set; }
        public string? CreateUserId { get; set; }

        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
