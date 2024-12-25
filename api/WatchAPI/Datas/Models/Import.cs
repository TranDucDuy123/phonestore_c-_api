﻿using System;
using System.Collections.Generic;

namespace WatchAPI.Datas.Models
{
    public partial class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }

        public string Id { get; set; } = null!;
        public decimal? Total { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UpdateUserId { get; set; }
        public string? CreateUserId { get; set; }

        public virtual Account? CreateUser { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}