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

namespace WatchWinform.Gui.Component.ProductCom
{
    public partial class ProductLayout : UserControl
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _cateogryService = new CategoryService();
        Panel _home = new Panel();
        int _action = 0;
        string _id = "";
        public ProductLayout()
        {

            InitializeComponent();
        }
        public ProductLayout(Panel home)
        {
            InitializeComponent();
            this._home = home;
        }

        public ProductLayout(Panel home, int action, string id)
        {
            InitializeComponent();
            this._home = home;
            this._action = action;
            this._id = id;
        }
        private async void ProductLayout_Load(object sender, EventArgs e)
        {
            await this.LoadCombobox();
            this.LoadByAction();
        }
        private void LoadByAction()
        {
            switch (this._action)
            {
                case 0: //View list
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_add);
                        this.title_lb.Text = "Product List";
                        this.flowLayoutSearch.Visible = true;

                        this.LoadProductList();
                        break;
                    }
                case 1: // Create
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);
                        this.flowLayoutSearch.Visible = false;

                        this.list_product_layout.Controls.Clear();
                        var createLayout = new EditLayout(this._home, "", "create");
                        this.title_lb.Text = "Create Product";
                        this.list_product_layout.Controls.Add(createLayout);
                        break;
                    }
                case 2: // Edit
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);
                        this.flowLayoutSearch.Visible = false;

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
                        this.flowLayoutSearch.Visible = false;

                        this.list_product_layout.Controls.Clear();
                        var viewLayout = new EditLayout(this._home, this._id, "view");
                        this.title_lb.Text = "Product Detail";
                        this.list_product_layout.Controls.Add(viewLayout);
                        break;
                    }
                default: break;
            }
        }
        private async Task<bool> LoadCombobox()
        {
            try
            {
                var result2 = await this._cateogryService.GetList();
                if (result2.Code == 0)
                {
                    var categories = result2.Data.OrderBy(c => c.Name).ToList();
                    categories.Insert(0, new Category()
                    {
                        Id = "",
                        Name = "Tất cả"
                    });
                    this.cat_cbb.DataBindings.Clear();
                    this.cat_cbb.DataSource = categories;
                    this.cat_cbb.DisplayMember = "Name";
                    this.cat_cbb.ValueMember = "Id";
                    this.cat_cbb.SelectedValue = "";
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
        private void btn_search_Click(object sender, EventArgs e)
        {
            this.LoadProductList();
        }
        private async void LoadProductList()
        {
            this.list_product_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._productService.GetList();
                if(result.Code == 0)
                {
                    var allProducts = result.Data.Where(p => string.IsNullOrEmpty(this.cat_cbb.SelectedValue.ToString()) || p.CategoryId == this.cat_cbb.SelectedValue.ToString()).OrderBy(p => p.Name).ToList();
                    
                    foreach (var item in allProducts)
                    {
                        this.list_product_layout.Controls.Add(new ComponentProduct(this._home, this, item));
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
            this._home.Controls.Add(new ProductLayout(_home, 1, ""));
        }

        private void btn_backList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new ProductLayout(_home, 0, ""));
        }


    }
}
