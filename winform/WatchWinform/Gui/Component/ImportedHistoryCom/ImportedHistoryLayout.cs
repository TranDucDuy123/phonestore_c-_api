using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchWinform.Gui.Component.ImportCom;
using WatchWinform.Gui.Component.ProductCom;
using WatchWinform.Datas.Models;
using WatchWinform.Service;

namespace WatchWinform.Gui.Component.ImportedHistoryCom
{
    public partial class ImportedHistoryLayout : UserControl
    {
        private readonly ImportService _importService = new ImportService();
        Panel _home = new Panel();
        int _action = 0;
        string _id = "";
        public ImportedHistoryLayout()
        {

            InitializeComponent();
        }
        public ImportedHistoryLayout(Panel home)
        {
            InitializeComponent();
            this._home = home;
        }

        public ImportedHistoryLayout(Panel home, int action, string id)
        {
            InitializeComponent();
            this._home = home;
            this._action = action;
            this._id = id;
            this.LoadByAction();
        }
        private void LoadByAction()
        {
            switch (this._action)
            {
                case 0: //View list
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.title_lb.Text = "Imported List";

                        this.LoadProductList();
                        break;
                    }
                case 1: // Create
                    {
                        this._home.Controls.Clear();
                        this._home.Controls.Add(new ImportLayout(_home, 0));
                        break;
                    }
                case 2: // Edit
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_product_layout.Controls.Clear();
                        var editLayout = new EditLayout(this._home, this._id, "edit");
                        this.title_lb.Text = "Update Product";
                        this.list_product_layout.Controls.Add(editLayout);
                        break;
                    }
                case 3: // View detail
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_product_layout.Controls.Clear();
                        var viewLayout = new EditLayout(this._home, this._id, "view");
                        this.title_lb.Text = "Product Detail";
                        this.list_product_layout.Controls.Add(viewLayout);
                        break;
                    }
                default: break;
            }
        }

        private async void LoadProductList()
        {
            this.list_product_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._importService.GetList();
                if(result.Code == 0)
                {
                    var allImports = result.Data.OrderByDescending(p => p.CreatedAt).ToList();
                    foreach (var item in allImports)
                    {
                        this.list_product_layout.Controls.Add(new ComponentImportedHistory(this._home, this, item));
                    }
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ImportedHistoryLayout(_home, 1, ""));
        }

        private void btn_backList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ImportedHistoryLayout(_home, 0, ""));
        }
    }
}
