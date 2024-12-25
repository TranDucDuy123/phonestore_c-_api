using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watch.Helpper;
using WatchWinform.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using WatchWinform.Service;
using WatchWinform.Datas.Models;

namespace WatchWinform.Gui.Component.ProductCom
{
    public partial class EditLayout : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private readonly BrandService _brandtService = new BrandService();
        private readonly CategoryService _cateogryService = new CategoryService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Product productLoaded;
        Image imageSelected;

        public EditLayout()
        {
            InitializeComponent();
        }
        public EditLayout(Panel home, string id, string action)
        {
            InitializeComponent();
            this._home = home;
            this._id = id;
            this._action = action;
        }

        private async void EditLayout_LoadAsync(object sender, EventArgs e)
        {
            await this.LoadCombobox();
            switch (this._action)
            {
                case "create":
                    this.CreateMode();
                    break;
                case "edit":
                    this.EditMode();
                    break;
                case "view":
                    this.ViewMode();
                    break;
                default:
                    this.ViewMode();
                    break;
            }
        }
        private async Task<bool> LoadCombobox()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result1 = await this._brandtService.GetList();
                if (result1.Code == 0)
                {
                    var brands = result1.Data;
                    this.brand_cbb.DataBindings.Clear();
                    this.brand_cbb.DataSource = brands;
                    this.brand_cbb.DisplayMember = "Name";
                    this.brand_cbb.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(result1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result2 = await this._cateogryService.GetList();
                if (result2.Code == 0)
                {
                    var categories = result2.Data;
                    this.cat_cbb.DataBindings.Clear();
                    this.cat_cbb.DataSource = categories;
                    this.cat_cbb.DisplayMember = "Name";
                    this.cat_cbb.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(result2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void ChangeMode(string mode)
        {
            if (mode != "view")
            {
                this.name_txt.ReadOnly = false;
                this.code_txt.ReadOnly = false;
                this.price_txt.ReadOnly = false;
                this.quantity_num.ReadOnly = false;
                this.discount_txt.ReadOnly = false;
                this.cat_cbb.Enabled = true;
                this.brand_cbb.Enabled = true;
                this.color_txt.ReadOnly = false;
                this.active_cb.Enabled = true;
                this.description_rtb.ReadOnly = false;
                this.upload_btn.Visible = true;

                this.btn_exit.Visible = true;
                this.btn_save.Visible = true;
            }
            else
            {
                this.name_txt.ReadOnly = true;
                this.code_txt.ReadOnly = true;
                this.price_txt.ReadOnly = true;
                this.quantity_num.ReadOnly = true;
                this.discount_txt.ReadOnly = true;
                this.cat_cbb.Enabled = false;
                this.brand_cbb.Enabled = false;
                this.color_txt.ReadOnly = true;
                this.active_cb.Enabled = false;
                this.description_rtb.ReadOnly = true;
                this.upload_btn.Visible = false;

                this.btn_exit.Visible = false;
                this.btn_save.Visible = false;
            }
        }
        private async void ViewMode()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._productService.GetById(this._id);
                this.productLoaded = result.Data;
                this.BindingData(productLoaded);
                this.ChangeMode("view");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void CreateMode()
        {
            this.ChangeMode("create");
        }
        private async void CreateData()
        {
            try
            {
                var product = new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = this.name_txt.Text,
                    Code = this.code_txt.Text,
                    Price = Decimal.Parse(this.price_txt.Text),
                    Quantity = Convert.ToInt32(this.quantity_num.Value),
                    Discount = Decimal.Parse(this.discount_txt.Text),
                    CategoryId = this.cat_cbb.SelectedValue.ToString(),
                    BrandId = this.brand_cbb.SelectedValue.ToString(),
                    Color = this.color_txt.Text,
                    Effective = this.active_cb.Checked,
                    Description = this.description_rtb.Text
                };
                if (this.imageSelected != null)
                {
                    // Lấy đường dẫn thư mục chứa tập tin exe của ứng dụng
                    string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                    // Lấy thư mục gốc của dự án (thư mục chứa file .sln)
                    string projectDirectory = Directory.GetParent(appDirectory).Parent.FullName;

                    product.Image = Utilities.SEOUrl(product.Name) + $"-{Guid.NewGuid()}" + ".jpeg";
                    // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh
                    string imagePath = Path.Combine(projectDirectory, "Assets/Image/Product", product.Image);
                    string extension = Path.GetExtension(imagePath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    string imagePatHD = Path.Combine(projectDirectory, "Assets/Image/FullHD/Product", product.Image);
                    if (System.IO.File.Exists(imagePatHD))
                    {
                        System.IO.File.Delete(imagePatHD);
                    }

                    await Utilities.UploadFile(imageSelected, extension, @"Product", product.Image);
                }
                else
                {
                    product.Image = await Utilities.UploadFile(imageSelected, "jpg", @"Product");
                }
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _productService.Create(product);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this.BackToList();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void EditMode()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._productService.GetById(this._id);
                this.productLoaded = result.Data;
                this.BindingData(productLoaded);
                this.ChangeMode("edit");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void EditData()
        {
            try
            {
                var product = new Product
                {
                    Id = this._id,
                    Name = this.name_txt.Text,
                    Code = this.code_txt.Text,
                    Price = Decimal.Parse(this.price_txt.Text),
                    Quantity = Convert.ToInt32(this.quantity_num.Value),
                    Discount = Decimal.Parse(this.discount_txt.Text),
                    CategoryId = this.cat_cbb.SelectedValue.ToString(),
                    BrandId = this.brand_cbb.SelectedValue.ToString(),
                    Color = this.color_txt.Text,
                    Effective = this.active_cb.Checked,
                    Description = this.description_rtb.Text
                };
                if (this.imageSelected != null)
                {
                    // Lấy đường dẫn thư mục chứa tập tin exe của ứng dụng
                    string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                    // Lấy thư mục gốc của dự án (thư mục chứa file .sln)
                    string projectDirectory = Directory.GetParent(appDirectory).Parent.FullName;


                    // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh
                    string imagePath = Path.Combine(projectDirectory, "Assets/Image/Product", this.productLoaded.Image);
                    string extension = Path.GetExtension(imagePath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    string imagePatHD = Path.Combine(projectDirectory, "Assets/Image/FullHD/Product", this.productLoaded.Image);
                    if (System.IO.File.Exists(imagePatHD))
                    {
                        System.IO.File.Delete(imagePatHD);
                    }
                    
                    product.Image = Utilities.SEOUrl(product.Name) + $"-{Guid.NewGuid()}" + ".jpeg";
                    await Utilities.UploadFile(imageSelected, extension, @"Product", product.Image);

                }
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._productService.Update(product);
                if(result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this.BackToList();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BindingData(Product product)
        {
            this.name_txt.Text = product.Name;
            this.code_txt.Text = product.Code;
            this.price_txt.Text = Convert.ToInt32(product.Price).ToString();
            this.quantity_num.Value = product.Quantity;
            this.discount_txt.Text = Convert.ToInt32(product.Discount).ToString();
            this.cat_cbb.SelectedValue = product.CategoryId;
            this.brand_cbb.SelectedValue = product.BrandId;
            this.color_txt.Text = product.Color;
            this.active_cb.Checked = (bool)product.Effective;

            // Lấy đường dẫn thư mục chứa tập tin exe của ứng dụng
            string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            // Lấy thư mục gốc của dự án (thư mục chứa file .sln)
            string projectDirectory = Directory.GetParent(appDirectory).Parent.FullName;

            // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh
            string imagePath = Path.Combine(projectDirectory, "Assets/Image/FullHD/Product", productLoaded.Image);

            // Kiểm tra xem tập tin hình ảnh có tồn tại không
            if (File.Exists(imagePath))
            {
                this.image_pic.Image.Dispose();
                this.image_pic.Image = null;
                this.imageSelected = null;
                byte[] imageData = File.ReadAllBytes(imagePath);
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                {
                    this.image_pic.Image = Image.FromStream(ms);
                }
            }

            this.description_rtb.Text = product.Description;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case "create":
                    this.CreateData();
                    break;
                case "edit":
                    this.EditData();
                    break;
                case "view":
                    break;
                default:
                    break;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.BackToList();
        }

        private void BackToList()
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ProductLayout(_home, 0, ""));
        }
        private void discount_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự đã nhập có phải là số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự được nhập vào TextBox
            }
        }
        private void price_txt_TextChanged(object sender, EventArgs e)
        {
            // Loại bỏ các ký tự không phải số sau khi dữ liệu đã được paste vào TextBox
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text) && !int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Bạn phải nhập số cho thông tin này!");
                textBox.Text = ""; // Xóa toàn bộ nội dung nếu không phải là số
            }
        }
        private void upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập filter cho OpenFileDialog
            openFileDialog.Filter = "Image Files (*.jpg,*.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            // Chỉ cho phép chọn nhiều tệp
            openFileDialog.Multiselect = false;

            // Mở OpenFileDialog và kiểm tra xem người dùng đã chọn tệp hay chưa
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến tệp đã chọn
                string selectedFilePath = openFileDialog.FileName;

                try
                {
                    // Tạo một đối tượng hình ảnh từ tệp đã chọn
                    Image selectedImage = Image.FromFile(selectedFilePath);

                    // Gán hình ảnh đã chọn cho PictureBox
                    this.image_pic.Image = selectedImage;
                    this.imageSelected = selectedImage;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có lỗi xảy ra khi đọc tệp hình ảnh
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }


    }
}
