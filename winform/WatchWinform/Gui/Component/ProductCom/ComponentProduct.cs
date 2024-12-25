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
using WatchWinform.Shared.Constant;
using WatchWinform.Shared.GlobalVar;

namespace WatchWinform.Gui.Component.ProductCom
{
    public partial class ComponentProduct : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private ProductLayout _layout =  new ProductLayout();
        private Panel _home = new Panel();
        private Product _product;
        private Image viewImage; // Biến global để lưu trữ hình ảnh từ tài nguyên
        private Image originalImage; // Lưu trữ ảnh ban đầu
        private int timeToLoadImageHover = 0;
        private int timeToLoadImageLeave = 0;
        public ComponentProduct(Panel home, ProductLayout layout, Product product)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._product = product;
            //this.CheckRole(); 
            this.LoadPreImage();
            this.LoadData(product);
        }
        private void CheckRole()
        {
            if (UserGlobal.Role == Role.Admin)
            {
                this.flowLayoutAction.Visible = true;
            }
            else
            {
                this.flowLayoutAction.Visible = false;
            }
        }
        private void LoadPreImage()
        {
            // Tạo một ResourceManager để truy cập tài nguyên
            ResourceManager rm = new ResourceManager("WatchWinform.Properties.Resources", Assembly.GetExecutingAssembly());

            // Lấy ảnh từ tài nguyên và lưu trữ vào biến global
            this.viewImage = (Image)rm.GetObject("view");
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
        private void ComponentProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ProductLayout(this._home, 2, this._product.Id));
        }

        
        private async void btn_delete_Click(object sender, EventArgs e)
        {
            var dialogRs = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogRs == DialogResult.OK)
            {
                var result = await _productService.Delete(this._product.Id);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this._home.Controls.Clear();
                    this._home.Controls.Add(new ProductLayout(_home, 0, ""));
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void item_img_MouseHover(object sender, EventArgs e)
        {
            if (viewImage != null)
            {
                if (viewImage != this.originalImage)
                {
                    this.originalImage = this.item_img.Image;
                    this.timer1.Start();
                }
            }
            else
            {
                MessageBox.Show("View image not loaded!");
            }
        }

        private void item_img_MouseLeave(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer2.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.timeToLoadImageHover >= 1)
            {
                 // Lưu trữ ảnh ban đầu
                this.item_img.SizeMode = PictureBoxSizeMode.CenterImage;

                this.item_img.Image = viewImage;
                // Thay đổi con trỏ chuột
                this.item_img.Cursor = Cursors.Hand;
                this.item_img.Click += this.item_img_Click;
                timeToLoadImageHover = 0;
            }
            
            this.timeToLoadImageHover += 1;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.timeToLoadImageLeave >= 1)
            {
                if (this.originalImage != null && this.originalImage != viewImage)
                {
                    // Khôi phục lại ảnh ban đầu
                    this.item_img.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.item_img.Image = this.originalImage;
                    // Khôi phục lại con trỏ chuột mặc định
                    this.item_img.Cursor = Cursors.Default;
                    this.timeToLoadImageLeave = 0;
                    this.item_img.Click -= this.item_img_Click;
                }
                this.timer2.Stop();
            }

            this.timeToLoadImageLeave += 1;
        }

        private void item_img_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ProductLayout(this._home, 3, this._product.Id));
        }

        private void item_img_Click_1(object sender, EventArgs e)
        {
        }
    }
}
