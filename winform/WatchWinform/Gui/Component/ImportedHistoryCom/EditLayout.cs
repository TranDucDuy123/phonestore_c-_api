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
using WatchWinform.Gui.Component.ImportCom;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Gui.Component.ProductCom;

namespace WatchWinform.Gui.Component.ImportedHistoryCom
{
    public partial class EditLayout : UserControl
    {
        private readonly ImportService _importService = new ImportService();
        private readonly ImportDetailService _importDetailService = new ImportDetailService();
        private readonly ProductService _productService = new ProductService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Import _import;

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
            //await this.LoadCombobox();
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
        /*
        private async Task<bool> LoadCombobox()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                //var result1 = await this._providerService.GetList();
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
        private async void ViewMode()
        {
            try
            {
                var result = await this._importService.GetById(this._id);
                this._import = result.Data;
                this.BindingData(this._import);
                this.ChangeMode("view");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void EditMode()
        {
            var result = await this._importService.GetById(this._id);
            this._import = result.Data;
            this.BindingData(this._import);
            this.ChangeMode("edit");
        }
        private void ChangeMode(string mode)
        {
            if (mode != "view")
            {
                this.transport_cbb.Enabled = true;
                this.provider_cbb.Enabled = true;

                this.btn_exit.Visible = true;
                this.btn_save.Visible = true;
            }
            else
            {
                this.transport_cbb.Enabled = false;
                this.provider_cbb.Enabled = false;

                this.btn_exit.Visible = false;
                this.btn_save.Visible = false;
            }
        }
        private void BindingData(Import import)
        {
            //this.provider_cbb.SelectedValue = import.ProviderId;
            //this.transport_cbb.SelectedValue = import.TransportId;
            this.total_lb.Text = import.Total?.ToString("n0") ?? "0";
            this.list_product_layout.Controls.Clear();
            try
            {
                if (import.ImportDetails.Count > 0)
                {
                    foreach (var item in import.ImportDetails)
                    {
                        this.list_product_layout.Controls.Add(new ComponentImportDetail(this._home, this, item.ProductId, item));
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
                var import = new Import
                {
                    Id = this._id,
                    //ProviderId = this.provider_cbb.SelectedValue.ToString(),
                    //TransportId = this.transport_cbb.SelectedValue.ToString(),
                    ImportDetails = this._import.ImportDetails
                };

                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _importService.Update(import);
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
            this._home.Controls.Add(new ImportedHistoryLayout(_home, 0, ""));
        }
    }
}
