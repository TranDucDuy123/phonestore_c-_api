using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WatchWinform.Datas.Models;

namespace WatchWinform.Shared.GlobalVar
{
    public static class ImportGlobal
    {
        public static List<SelectedItem> SelectedItems { get; set; } = new List<SelectedItem>();
    }
    public class SelectedItem
    {
        public DateTime AddAt { get; set; }
        public Product SelectedProduct { get; set; }
    }
    public static class ImportDetailGlobal
    {
        public static List<ImportDetail> SelectedItems { get; set; } = new List<ImportDetail>();
    }
}
