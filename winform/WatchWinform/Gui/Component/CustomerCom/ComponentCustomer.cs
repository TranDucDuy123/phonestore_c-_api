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
using System.Globalization;

namespace WatchWinform.Gui.Component.CustomerCom
{
    public partial class ComponentCustomer : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();
        private readonly AccountService _accountService = new AccountService();
        private CustomerLayout _layout =  new CustomerLayout();
        private Panel _home = new Panel();
        private Customer _customer;
        private Image viewImage; // Biến global để lưu trữ hình ảnh từ tài nguyên
        private Image originalImage; // Lưu trữ ảnh ban đầu
        private int timeToLoadImageHover = 0;
        private int timeToLoadImageLeave = 0;
        public ComponentCustomer(Panel home, CustomerLayout layout, Customer customer)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._customer = customer;
            //this.CheckRole(); 
            this.LoadPreImage();
            this.LoadData(customer);
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
            this.originalImage = (Image)rm.GetObject("customer-feedback");
        }

        private async void LoadData(Customer customer)
        {
            var user = await this._accountService.GetById(customer.CreateUserId);
            this.item_name.Text = customer.Name;
            //this.item_des.Text = customer.Description;
            this.item_date.Text = customer.CreatedAt?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
            this.item_user.Text = user.Code == 0 ? user.Data.Name : "Không có thông tin";
           
        }
        private void ComponentCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new CustomerLayout(this._home, 2, this._customer.Id));
        }

        
        private async void btn_delete_Click(object sender, EventArgs e)
        {
            var dialogRs = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogRs == DialogResult.OK)
            {
                var result = await _customerService.Delete(this._customer.Id);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this._home.Controls.Clear();
                    this._home.Controls.Add(new CustomerLayout(_home, 0, ""));
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
                this.timer1.Start();
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
            this._home.Controls.Add(new CustomerLayout(this._home, 3, this._customer.Id));
        }


    }
}
