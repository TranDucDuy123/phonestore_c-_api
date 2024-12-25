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

namespace WatchWinform.Gui.Component.ImportCom
{
    public partial class ComponentImported : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private ImportLayout _layout =  new ImportLayout();
        private Panel _home = new Panel();
        private string _productId;
        private ImportDetail _importDetail;
        private bool _allowAction;

        public ComponentImported(Panel home, ImportLayout layout, string id, bool allowAction = true)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._productId = id;
            this._allowAction = allowAction;
            this._importDetail = ImportDetailGlobal.SelectedItems.FirstOrDefault(s => s.ProductId == id);
            this.LoadData(id);
            this.ControlAction();
        }

        private void ControlAction()
        {
            if(this._allowAction) {
                this.flowLayoutPanel1.Visible = true;
                this.priceIn_txt.Enabled = true;
                this.quantity_num.Enabled = true;
            }
            else
            {
                this.Controls.Remove(this.flowLayoutPanel1);
                this.priceIn_txt.Enabled = false;
                this.quantity_num.Enabled = false;
            }
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
                this.priceIn_txt.Text = this._importDetail.PriceIn?.ToString("n0");
                this.quantity_num.Value = decimal.Parse((this._importDetail.Quantity ?? 0).ToString());
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
        private void ComponentProduct_Load(object sender, EventArgs e)
        {
            
        }

        
        private void btn_delete_Click(object sender, EventArgs e)
        {
            var importItem = ImportGlobal.SelectedItems.FirstOrDefault(s => s.SelectedProduct.Id == this._productId);
            ImportGlobal.SelectedItems.Remove(importItem);
            var importDetailItem = ImportDetailGlobal.SelectedItems.FirstOrDefault(s => s.ProductId == this._productId);
            ImportDetailGlobal.SelectedItems.Remove(importDetailItem);
            this._layout.btn_selectedList.Text = $"Selected Products: {ImportGlobal.SelectedItems.Count}";
            this._layout.LoadByAction(1);
        }


        private void priceIn_txt_TextChanged(object sender, EventArgs e)
        {
            var value = decimal.Parse(!string.IsNullOrWhiteSpace(this.priceIn_txt.Text) ? this.priceIn_txt.Text : "0");
            var importDetailF = ImportDetailGlobal.SelectedItems.FirstOrDefault(s => s.ProductId == this._productId);
            importDetailF.PriceIn = value;
            importDetailF.Total = (decimal)importDetailF.Quantity * value;
        }

        private void quantity_num_ValueChanged(object sender, EventArgs e)
        {
            var value = int.Parse(this.quantity_num.Value.ToString());
            var importDetailF = ImportDetailGlobal.SelectedItems.FirstOrDefault(s => s.ProductId == this._productId);
            importDetailF.Quantity = value;
            importDetailF.Total = (decimal)importDetailF.PriceIn * value;
        }

        private void priceIn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự đã nhập có phải là số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào TextBox
            }
        }
    }
}
