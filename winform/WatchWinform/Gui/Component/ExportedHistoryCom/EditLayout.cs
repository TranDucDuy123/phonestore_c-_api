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
using WatchWinform.Datas.Models;
using WatchWinform.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using WatchWinform.Service;
using WatchWinform.Gui.Component.ExportCom;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Gui.Component.ProductCom;

namespace WatchWinform.Gui.Component.ExportedHistoryCom
{
    public partial class EditLayout : UserControl
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly OrderDetailService _orderDetailService = new OrderDetailService();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly ProductService _productService = new ProductService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Order _order;

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
                case "view":
                    this.ViewMode();
                    break;
                case "edit":
                    this.EditMode();
                    break;
                default:
                    break;
            }
        }
        private async Task<bool> LoadCombobox()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result1 = await this._customerService.GetList();
                if (result1.Code == 0)
                {
                    var customers = result1.Data;
                    this.customer_cbb.DataBindings.Clear();
                    this.customer_cbb.DataSource = customers;
                    this.customer_cbb.DisplayMember = "Name";
                    this.customer_cbb.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(result1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        private async void ViewMode()
        {
            try
            {
                var result = await this._orderService.GetById(this._id);
                this._order = result.Data;
                this.BindingData(this._order);
                this.ChangeMode("view");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void EditMode()
        {
            var result = await this._orderService.GetById(this._id);
            this._order = result.Data;
            this.BindingData(this._order);
            this.ChangeMode("edit");
        }
        private void ChangeMode(string mode)
        {
            if (mode != "view")
            {
                this.customer_cbb.Enabled = true;

                this.btn_exit.Visible = true;
                this.btn_save.Visible = true;
            }
            else
            {
                this.customer_cbb.Enabled = false;

                this.btn_exit.Visible = false;
                this.btn_save.Visible = false;
            }
        }
        private void BindingData(Order order)
        {
            this.customer_cbb.SelectedValue = order.CustomerId;
            this.total_lb.Text = order.Total?.ToString("n0") ?? "0";
            this.list_product_layout.Controls.Clear();
            try
            {
                if (order.OrderDetails.Count > 0)
                {
                    foreach (var item in order.OrderDetails)
                    {
                        this.list_product_layout.Controls.Add(new ComponentExportDetail(this._home, this, item.ProductId, item));
                    }
                }
                else
                {
                    MessageBox.Show("Danh sách sản phẩm trống!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task<bool> EditData()
        {
            try
            {
                var order = new Order
                {
                    Id = this._id,
                    CustomerId = this.customer_cbb.SelectedValue.ToString(),
                    OrderDetails = this._order.OrderDetails
                };

                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _orderService.Update(order);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this.BackToList();
                    return true;
                }
                else
                {

                    MessageBox.Show(result.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case "edit":
                    await this.EditData();
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
            this._home.Controls.Add(new ExportedHistoryLayout(_home, 0, ""));
        }
    }
}
