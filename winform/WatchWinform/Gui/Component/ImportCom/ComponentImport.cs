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
using WatchWinform.Helpers;
using WatchWinform.Service;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Datas.Models;

namespace WatchWinform.Gui.Component.ImportCom
{
    public partial class ComponentImport : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private ImportLayout _layout =  new ImportLayout();
        private Panel _home = new Panel();
        private Product _product;
        public ComponentImport(Panel home, ImportLayout layout, Product product)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._product = product;
            this.LoadData(product);
        }

        private void LoadData(Product product)
        {
            this.item_title.Text = product.Name;
            this.item_code.Text = product.Code;
            this.item_price.Text = product.Price.ToString("n0");
            this.item_quantity.Text = "Quantity: " + product.Quantity.ToString();
            this.item_brand.Text = product.Brand?.Name?.ToString();
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
        private void ComponentImport_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ImportGlobal.SelectedItems.Add(new SelectedItem
            {
                AddAt = DateTime.Now,
                SelectedProduct = this._product
            });
            ImportDetailGlobal.SelectedItems.Add(new ImportDetail
            {
                Id = Guid.NewGuid().ToString(),
                Quantity = 0,
                PriceIn = 0,
                ProductId = this._product.Id,
                Total = 0
            });
            this._layout.btn_selectedList.Text = $"Selected Products: {ImportGlobal.SelectedItems.Count}";
            this._layout.LoadByAction(0);
        }
       
    }
}
