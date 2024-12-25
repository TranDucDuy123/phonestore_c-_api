using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class Feedback
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string ProductId { get; set; }
        public string SessionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }
        public int? Rate { get; set; }

        public virtual Product Product { get; set; }
    }
}
