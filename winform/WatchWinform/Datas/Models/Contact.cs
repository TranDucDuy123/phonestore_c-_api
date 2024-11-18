using System;
using System.Collections.Generic;

namespace WatchWinform.Datas.Models
{
    public partial class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string SessionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateUserId { get; set; }
    }
}
