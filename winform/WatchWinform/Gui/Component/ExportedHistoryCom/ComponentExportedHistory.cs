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
using Watch.Helpper;
using System.Globalization;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Constant;
using WatchWinform.Datas.Models;

namespace WatchWinform.Gui.Component.ExportedHistoryCom
{
    public partial class ComponentExportedHistory : UserControl
    {
        private readonly OrderService _exportService = new OrderService();
        private readonly AccountService _accountService = new AccountService();
        private ExportedHistoryLayout _layout =  new ExportedHistoryLayout();
        private Panel _home = new Panel();
        private Order _order;
        private Image viewImage; // Biến global để lưu trữ hình ảnh từ tài nguyên
        private Image originalImage; // Lưu trữ ảnh ban đầu
        private int timeToLoadImageHover = 0;
        private int timeToLoadImageLeave = 0;
        private string userName = "";
        public ComponentExportedHistory(Panel home, ExportedHistoryLayout layout, Order order)
        {
            InitializeComponent();
            this._home = home;
            this._layout = layout;
            this._order = order;
            this.LoadPreImage();
            this.LoadData(order);
            this.CheckRole();
        }
        private void LoadPreImage()
        {
            // Tạo một ResourceManager để truy cập tài nguyên
            ResourceManager rm = new ResourceManager("WatchWinform.Properties.Resources", Assembly.GetExecutingAssembly());

            // Lấy ảnh từ tài nguyên và lưu trữ vào biến global
            this.viewImage = (Image)rm.GetObject("view");
            this.originalImage = (Image)rm.GetObject("export (4)");
        }

        private async void LoadData(Order order)
        {
            this.item_total.Text = order.Total?.ToString("n0");
            item_customer.Text = Utilities.SubstringIfLonger(order.Customer?.Name, 40);
            this.item_createdAt.Text = order.CreatedAt?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
        }
        private void CheckRole()
        {
            if(UserGlobal.Role == Role.Admin)
            {
                this.flowLayoutAction.Visible = true;
            }
            else
            {
                this.flowLayoutAction.Visible = false;
            }
        }
        private void ComponentExportedHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ExportedHistoryLayout(this._home, 2, this._order.Id));
        }

        
        private async void btn_delete_Click(object sender, EventArgs e)
        {
            var dialogRs = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn nhập hàng này?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogRs == DialogResult.OK)
            {
                var result = await _exportService.Delete(this._order.Id);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this._home.Controls.Clear();
                    this._home.Controls.Add(new ExportedHistoryLayout(_home, 0, ""));
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

            // Lưu trữ ảnh ban đầu
            this.item_img.SizeMode = PictureBoxSizeMode.CenterImage;

            this.item_img.Image = viewImage;
            // Thay đổi con trỏ chuột
            this.item_img.Cursor = Cursors.Hand;
            this.item_img.Click += this.item_img_Click;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Khôi phục lại ảnh ban đầu
            this.item_img.SizeMode = PictureBoxSizeMode.StretchImage;
            this.item_img.Image = this.originalImage;
            // Khôi phục lại con trỏ chuột mặc định
            this.item_img.Cursor = Cursors.Default;
            this.timeToLoadImageLeave = 0;
            this.item_img.Click -= this.item_img_Click;
            this.timer2.Stop();
        }

        private void item_img_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ExportedHistoryLayout(this._home, 3, this._order.Id));
        }


    }
}
