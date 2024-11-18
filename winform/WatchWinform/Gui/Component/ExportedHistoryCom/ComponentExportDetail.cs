using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchWinform.Datas.Models;
using WatchWinform.Helpers;
using WatchWinform.Service;
using WatchWinform.Shared.GlobalVar;
using Newtonsoft.Json.Linq;
using WatchWinform.Gui.Component.ExportedHistoryCom;

namespace WatchWinform.Gui.Component.ExportedHistoryCom
{
    public partial class ComponentExportDetail : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private EditLayout _layout =  new EditLayout();
        private Panel _home = new Panel();
        private string _productId;
        private OrderDetail _orderDetail;
        private bool _allowAction;

        public ComponentExportDetail(Panel home, EditLayout layout, string id, OrderDetail orderDetail)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._productId = id;
            this._orderDetail = orderDetail;
            this.LoadData(id);
        }
        private async void LoadData(string id)
        {
            var result = await this._productService.GetById(id);
            if(result.Code == 0)
            {
                var product = result.Data;
                this.item_title.Text = product.Name;
                this.item_code.Text = product.Code;
                this.item_price.Text = product.Price.ToString("n0");
                this.priceIn_txt.Text = this._orderDetail.Product?.Price.ToString("n0");
                this.quantity_num.Value = decimal.Parse((this._orderDetail.Quantity ?? 0).ToString());
                // Lấy đường dẫn thư mục chứa tập tin exe của ứng dụng
                string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                // Lấy thư mục gốc của dự án (thư mục chứa file .sln)
                string projectDirectory = Directory.GetParent(appDirectory).Parent.FullName;

                // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh
                string imagePath = Path.Combine(projectDirectory, "Assets/Image/FullHD/Product", product.Image);

                // Kiểm tra xem tập tin hình ảnh có tồn tại không
                if (File.Exists(imagePath))
                {
                    try
                    {
                        // Kích thước mục tiêu (ví dụ: 200x200px)
                        int targetWidth = 300;
                        int targetHeight = 200;
                        byte[] imageData = File.ReadAllBytes(imagePath);
                        using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                        {
                            // Đặt hình ảnh đã resize cho ô cột "Image"
                            Image resizedImage = DataGridViewTool.ResizeImage(Image.FromStream(ms), targetWidth, targetHeight);
                            this.item_img.Image = resizedImage;
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Invalid parameter: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
            
        }

        private void priceIn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự đã nhập có phải là số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào TextBox
            }
        }

        private void priceIn_txt_TextChanged(object sender, EventArgs e)
        {
            // Loại bỏ các ký tự không phải số sau khi dữ liệu đã được paste vào TextBox
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text) && !int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Bạn phải nhập số cho thông tin này!");
                textBox.Text = ""; // Xóa toàn bộ nội dung nếu không phải là số
            }
        }
    }
}
