using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WatchWinform.Datas.Models;

namespace WatchWinform.Shared.GlobalVar
{
    public static class ExportGlobal
    {
        public static List<SelectedProductItem> SelectedItems { get; set; } = new List<SelectedProductItem>();
    }
    public class SelectedProductItem
    {
        public DateTime AddAt { get; set; }
        public Product SelectedProduct { get; set; }
    }
    public static class ExportDetailGlobal
    {
        public static List<OrderDetail> SelectedItems { get; set; } = new List<OrderDetail>();
    }

    
}
