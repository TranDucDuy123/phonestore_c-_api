using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchWinform.Extension;
using WatchWinform.Datas.Models;

namespace WatchWinform.Helpers
{
    public static class DataGridViewTool
    {
        public static DataGridView AddColumndataGridView(DataGridView des, IDictionary<string, string> columns)
        {
            foreach (var column in columns)
            {
                var clmSplit = column.Key.Split('_');
                if (clmSplit[0] == "Textbox")
                {
                    DataGridViewTextBoxColumn txtColumn = new DataGridViewTextBoxColumn();
                    txtColumn.HeaderText = column.Value;
                    txtColumn.Name = !string.IsNullOrEmpty(clmSplit[1]) ? clmSplit[1] : column.Key;
                    des.Columns.Add(txtColumn);
                }
                else if (clmSplit[0] == "Button")
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.HeaderText = column.Value;
                    btnColumn.Name = !string.IsNullOrEmpty(clmSplit[2]) ? clmSplit[2] : column.Key;
                    btnColumn.Text = !string.IsNullOrEmpty(clmSplit[1]) ? clmSplit[1] : column.Key;
                    btnColumn.UseColumnTextForButtonValue = true;
                    des.Columns.Add(btnColumn);
                }   
                else if (clmSplit[0] == "Numeric")
                {
                    // Tạo một cột mới với loại cột là DataGridViewNumericUpDownColumn
                    NumericUpDownColumn numericUpDownColumn = new NumericUpDownColumn();
                    numericUpDownColumn.HeaderText = column.Value;
                    numericUpDownColumn.Name = !string.IsNullOrEmpty(clmSplit[1]) ? clmSplit[1] : column.Key;

                    // Tùy chỉnh giá trị Minimum và Maximum cho cột của bạn nếu cần
                    des.Columns.Add(numericUpDownColumn);
                }
                else if (clmSplit[0] == "Image")
                {
                    // Tạo một DataGridViewImageColumn
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.Name = !string.IsNullOrEmpty(clmSplit[1]) ? clmSplit[1] : column.Key;
                    imageColumn.HeaderText = column.Value; // Đặt tiêu đề cho cột ảnh
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Tuỳ chỉnh cách ảnh được hiển thị

                    // Thêm cột ảnh vào DataGridView
                    des.Columns.Add(imageColumn);
                }
            }
            return des;
        }
        public static DataGridView ShowSelectedColumns(DataGridView des, List<string> selectedColumns)
        {
            foreach (DataGridViewColumn column in des.Columns)
            {
                column.Visible = false;
            }

            // Hiển thị các cột đã chọn và ẩn các cột còn lại
            foreach (string columnName in selectedColumns)
            {
                if (des.Columns.Contains(columnName))
                {
                    des.Columns[columnName].Visible = true;
                }
            }
            return des;
        }
        public static DataGridView EnableEditColumns(DataGridView des, List<string> selectedColumns)
        {
            foreach (DataGridViewColumn column in des.Columns)
            {
                column.ReadOnly = true;
            }

            // Hiển thị các cột đã chọn và ẩn các cột còn lại
            foreach (string columnName in selectedColumns)
            {
                if (des.Columns.Contains(columnName))
                {
                    des.Columns[columnName].ReadOnly = false;
                }
            }
            return des;
        }
        public static DataGridView SetUpDataGridView(DataGridView des, List<Product> data, Dictionary<string, string> columnProperties)
        {
            BindingList<Product> bindingList = new BindingList<Product>(data);
            Dictionary<string, string> columnExt1 = new Dictionary<string, string>
            {
                { "Textbox_STT", "STT" },
            };
            des = DataGridViewTool.AddColumndataGridView(des, columnExt1);
           
            // Gán danh sách vào DataGridView
            des.DataSource = data;
            
            foreach (var column in columnProperties)
            {
                if (des.Columns.Contains(column.Key))
                {
                    // Đổi HeaderText của các cột
                    des.Columns[column.Key].HeaderText = column.Value;
                }
                else
                {

                    // Khởi tạo một từ điển với hai cặp key-value
                    Dictionary<string, string> columnExp2 = new Dictionary<string, string>
                    {
                        { column.Key, column.Value },
                    };
                    des = DataGridViewTool.AddColumndataGridView(des, columnExp2);
                }
            }

            // Ẩn cột "Id"
            if (des.Columns.Contains("Id"))
            {
                des.Columns["Id"].Visible = false;
            }          

            // Chọn các cột để hiển thị
            var showColumns = new List<string>
            {
                "STT","ImageView"
            };
            showColumns.AddRange(columnProperties.Keys.Where(k => !k.Contains('_')).ToList());
            showColumns.AddRange(columnProperties.Keys.Where(k => k.Contains('_')).Select(k => k.Split('_')[k.Split('_').Count() == 2 ? 1 : 2]).ToList());
            des = DataGridViewTool.ShowSelectedColumns(des, showColumns);
            return des;
        }
        public static Image ResizeImage(Image originalImage, int targetWidth, int targetHeight)
        {
            // Tạo một Bitmap mới với kích thước mục tiêu
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);

            // Tạo một Graphics từ Bitmap mới
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // Vẽ hình ảnh gốc lên Bitmap mới với kích thước mục tiêu
                graphics.DrawImage(originalImage, 0, 0, targetWidth, targetHeight);
            }

            return resizedImage;
        }
    }
}
