using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchWinform.Datas.Models;
using WatchWinform.Service;
using WatchWinform.Shared.GlobalVar;

namespace WatchWinform.Gui.Component.ImportCom
{
    public partial class ImportLayout : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private readonly ImportService _importService = new ImportService();
        Panel _home = new Panel();
        int _action = 0;
        public ImportLayout()
        {
            InitializeComponent();
        }
        public ImportLayout(Panel home)
        {
            InitializeComponent();
            this._home = home;
        }

        public ImportLayout(Panel home, int action)
        {
            InitializeComponent();
            this._home = home;
            this._action = action;
            this.LoadByAction(this._action);
        }
        public void LoadByAction(int action)
        {
            switch (action)
            {
                case 0: // View Product list
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_selectedList);
                        this.title_lb.Text = "Product list";

                        this.pnl_footer.Visible = false;

                        this.btn_selectedList.Text = $"Selected Products: {ImportGlobal.SelectedItems.Count}";
                        this.LoadProductList();
                        break;
                    }
                case 1: // View selected product
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_productList);
                        this.title_lb.Text = "Product selected";

                        this.pnl_footer.Visible = true;        

                        this.LoadSelectedList();

                        //this.list_product_layout.Controls.Clear();
                        //var createLayout = new EditLayout(this._home, "","create");
                        //this.title_lb.Text = "Create product";
                        //this.list_product_layout.Controls.Add(createLayout);
                        break;
                    }
                default: break;
            }
        }

        public async void LoadProductList()
        {
            this.list_product_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._productService.GetList();
                if(result.Code == 0)
                {
                    var allProducts = result.Data.OrderBy(p => p.Name).ToList();
                    // loại bỏ các product đã chọn
                    var items = ImportGlobal.SelectedItems.Select(s => s.SelectedProduct).ToList();
                    allProducts = allProducts.Where(a => !ImportGlobal.SelectedItems.Select(s => s.SelectedProduct.Id).Contains(a.Id)).ToList();
                    foreach (var item in allProducts)
                    {
                        this.list_product_layout.Controls.Add(new ComponentImport(this._home, this, item));
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
                        this.list_product_layout.Controls.Add(new ComponentImported(this._home, this, item.ProductId));
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

        private void btn_backList_Click(object sender, EventArgs e)
        {
            this.LoadByAction(0);
        }
        private void btn_selected_Click(object sender, EventArgs e)
        {
            this.LoadByAction(1);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ImportGlobal.SelectedItems.Clear();
            ImportDetailGlobal.SelectedItems.Clear();
            this.LoadByAction(1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ViewPreImportLayout(this._home, "", "create"));
        }
    }
}
