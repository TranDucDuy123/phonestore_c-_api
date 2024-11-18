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

namespace WatchWinform.Gui.Component.CustomerCom
{
    public partial class CustomerLayout : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();
        Panel _home = new Panel();
        int _action = 0;
        string _id = "";
        public CustomerLayout()
        {

            InitializeComponent();
        }
        public CustomerLayout(Panel home)
        {
            InitializeComponent();
            this._home = home;
        }

        public CustomerLayout(Panel home, int action, string id)
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
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_add);
                        this.title_lb.Text = "Customer List";

                        this.LoadCustomerList();
                        break;
                    }
                case 1: // Create
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_customer_layout.Controls.Clear();
                        var createLayout = new EditLayout(this._home, "", "create");
                        this.title_lb.Text = "Create Customer";
                        this.list_customer_layout.Controls.Add(createLayout);
                        break;
                    }
                case 2: // Edit
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_customer_layout.Controls.Clear();
                        var editLayout = new EditLayout(this._home, this._id, "edit");
                        this.title_lb.Text = "Update Customer";
                        this.list_customer_layout.Controls.Add(editLayout);
                        break;
                    }
                case 3: // View detail
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_customer_layout.Controls.Clear();
                        var viewLayout = new EditLayout(this._home, this._id, "view");
                        this.title_lb.Text = "Customer Detail";
                        this.list_customer_layout.Controls.Add(viewLayout);
                        break;
                    }
                default: break;
            }
        }

        private async void LoadCustomerList()
        {
            this.list_customer_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._customerService.GetList();
                if(result.Code == 0)
                {
                    var allCustomers = result.Data.OrderBy(p => p.Name).ToList();
                    
                    foreach (var item in allCustomers)
                    {
                        this.list_customer_layout.Controls.Add(new ComponentCustomer(this._home, this, item));
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
            this._home.Controls.Add(new CustomerLayout(_home, 1, ""));
        }

        private void btn_backList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new CustomerLayout(_home, 0, ""));
        }
    }
}
