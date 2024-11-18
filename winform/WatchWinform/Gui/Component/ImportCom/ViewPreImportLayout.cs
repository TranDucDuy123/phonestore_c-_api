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
using System.Security.Cryptography;

namespace WatchWinform.Gui.Component.ImportCom
{
    public partial class ViewPreImportLayout : UserControl
    {
        private readonly ImportService _importService = new ImportService();
        private readonly ImportDetailService _importDetailService = new ImportDetailService();
        private readonly ProductService _productService = new ProductService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Import _import;

        public ViewPreImportLayout()
        {
            InitializeComponent();
        }
        public ViewPreImportLayout(Panel home, string id, string action)
        {
            InitializeComponent();
            this._home = home;
            this._id = id;
            this._action = action;
        }

        private async void EditLayout_LoadAsync(object sender, EventArgs e)
        {
            //await this.LoadCombobox();
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
                var result = ImportDetailGlobal.SelectedItems;
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        this.list_product_layout.Controls.Add(new ComponentImported(this._home, null, item.ProductId, false));
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
        /*
        private async Task<bool> LoadCombobox()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result1 = await this._providerService.GetList();
                if (result1.Code == 0)
                {
                    var providers = result1.Data;
                    this.provider_cbb.DataBindings.Clear();
                    this.provider_cbb.DataSource = providers;
                    this.provider_cbb.DisplayMember = "Name";
                    this.provider_cbb.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(result1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result2 = await this._transportService.GetList();
                if (result2.Code == 0)
                {
                    var transports = result2.Data;
                    this.transport_cbb.DataBindings.Clear();
                    this.transport_cbb.DataSource = transports;
                    this.transport_cbb.DisplayMember = "Name";
                    this.transport_cbb.ValueMember = "Id";
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
        */
        private void CreateMode()
        {
            this.btn_selectedList.Text = $"Selected Products: {ImportGlobal.SelectedItems.Count}";
            var total = this.GetToTal(ImportDetailGlobal.SelectedItems);
            this.total_lb.Text = total.ToString("n0") ?? "0";
        }

        private decimal GetToTal(List<ImportDetail> ImportDetails)
        {
            var total = (ImportDetails.Sum(p => p.Total));
            if(total != null)
            {
                return total;
            }
            return 0;
        }
        private async Task<bool> CreateData()
        {
            try
            {
                var import = new Import
                {
                    Id = Guid.NewGuid().ToString(),
                    Total = this.GetToTal(ImportDetailGlobal.SelectedItems),
                    //ProviderId = this.provider_cbb.SelectedValue.ToString(),
                    //TransportId = this.transport_cbb.SelectedValue.ToString(),
                };
 
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _importService.Create(import);
                if (result.Code == 0)
                {
                    foreach (var item in ImportDetailGlobal.SelectedItems)
                    {
                        item.ImportId = import.Id;
                        await _importDetailService.Create(item);

                        // update product
                        var productRS = await this._productService.GetById(item.ProductId);
                        if(productRS.Code == 0)
                        {
                            var productUpd = productRS.Data;
                            productUpd.Quantity += item.Quantity.Value;
                            await _productService.Update(productRS.Data);
                        }
                        else
                        {
                            MessageBox.Show(result.Message);
                        }
                    }
                    this.ClearImportGlobal();
                    MessageBox.Show(result.Message);
                    this.BackToHistoryImport();
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

        private void ClearImportGlobal()
        {
            ImportGlobal.SelectedItems.Clear();
            ImportDetailGlobal.SelectedItems.Clear();
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
            this._home.Controls.Add(new ImportLayout(_home, 0));
        }
        private void BackToHistoryImport()/////
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ImportLayout(_home, 0));
        }

        private void btn_selectedList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ImportLayout(this._home, 1));
        }

        private void transport_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
