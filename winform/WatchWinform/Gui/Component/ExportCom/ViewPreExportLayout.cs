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
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Gui.Component.ProductCom;
using WatchWinform.Datas.Models;

namespace WatchWinform.Gui.Component.ExportCom
{
    public partial class ViewPreExportLayout : UserControl
    {
        private readonly OrderService _exportService = new OrderService();
        private readonly OrderDetailService _exportDetailService = new OrderDetailService();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly ProductService _productService = new ProductService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        private Order _order;

        public ViewPreExportLayout()
        {
            InitializeComponent();
        }
        public ViewPreExportLayout(Panel home, string id, string action)
        {
            InitializeComponent();
            this._home = home;
            this._id = id;
            this._action = action;
        }

        private async void EditLayout_LoadAsync(object sender, EventArgs e)
        {
            await this.LoadCombobox();
            this.LoadSelectedList();
            switch (this._action)
            {
                case "create":
                    this.CreateMode();
                    break;
                default:
                    break;
            }
        }
        public void LoadSelectedList()
        {
            this.list_product_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = ExportDetailGlobal.SelectedItems;
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        this.list_product_layout.Controls.Add(new ComponentExported(this._home, null, item.ProductId, false));
                    }
                }
                else
                {
                    MessageBox.Show("Danh sách trống!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void CreateMode()
        {
            this.btn_selectedList.Text = $"Selected Products: {ExportGlobal.SelectedItems.Count}";
            var total = this.GetToTal(ExportDetailGlobal.SelectedItems);
            this.total_lb.Text = total.ToString("n0") ?? "0";
        }

        private decimal GetToTal(List<OrderDetail> OrderDetails)
        {
            var total = OrderDetails.Sum(p => p.Total);
            return total ?? 0;
        }
        private async Task<bool> CreateData()
        {
            try
            {
                var order = new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    CustomerId = this.customer_cbb.SelectedValue.ToString(),
                    Total = this.GetToTal(ExportDetailGlobal.SelectedItems),
                };
 
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _exportService.Create(order);
                if (result.Code == 0)
                {
                    foreach (var item in ExportDetailGlobal.SelectedItems)
                    {
                        item.OrderId = order.Id;
                        await _exportDetailService.Create(item);

                        // update product
                        var productRS = await this._productService.GetById(item.ProductId);
                        if(productRS.Code == 0)
                        {
                            var productUpd = productRS.Data;
                            productUpd.Quantity -= item.Quantity.Value;
                            await _productService.Update(productRS.Data);
                        }
                        else
                        {
                            MessageBox.Show(result.Message);
                        }
                    }
                    this.ClearExportGlobal();
                    MessageBox.Show(result.Message);   
                    this.BackToHistoryExport();
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

        private void ClearExportGlobal()
        {
            ExportGlobal.SelectedItems.Clear();
            ExportDetailGlobal.SelectedItems.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case "create":
                    var check = this.CreateData();
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
            this._home.Controls.Add(new ExportLayout(_home, 0));
        }
        private void BackToHistoryExport()/////
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ExportLayout(_home, 0));
        }

        private void btn_selectedList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ExportLayout(this._home, 1));
        }

        private void title_lb_Click(object sender, EventArgs e)
        {

        }
    }
}
