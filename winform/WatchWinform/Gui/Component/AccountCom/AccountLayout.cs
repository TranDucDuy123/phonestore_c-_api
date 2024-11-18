using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchWinform.API;
using WatchWinform.Datas.Models;
using WatchWinform.Service;
using WatchWinform.Shared.GlobalVar;

namespace WatchWinform.Gui.Component.AccountCom
{
    public partial class AccountLayout : UserControl
    {
        private readonly AccountService _accountService = new AccountService();
        Panel _home = new Panel();
        int _action = 0;
        private bool isLoading = false;
        string _id = "";
        public AccountLayout()
        {

            InitializeComponent();
        }
        public AccountLayout(Panel home)
        {
            InitializeComponent();
            this._home = home;
        }

        public AccountLayout(Panel home, int action, string id)
        {
            InitializeComponent();
            this._home = home;
            this._action = action;
            this._id = id;
            
        }
        private void AccountLayout_Load(object sender, EventArgs e)
        {
            this.LoadByAction();
        }
        private void LoadByAction()
        {
            if (isLoading) return; // Exit if already loading
            isLoading = true;
            switch (this._action)
            {
                case 0: //View list
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_add);
                        this.title_lb.Text = "Account List";
                        this.LoadAccountList();

                        break;
                    }
                case 1: // Create
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_account_layout.Controls.Clear();
                        var createLayout = new EditLayout(this._home, "", "create");
                        this.title_lb.Text = "Create Account";
                        this.list_account_layout.Controls.Add(createLayout);
                        break;
                    }
                case 2: // Edit
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_account_layout.Controls.Clear();
                        var editLayout = new EditLayout(this._home, this._id, "edit");
                        this.title_lb.Text = "Update Account";
                        this.list_account_layout.Controls.Add(editLayout);
                        break;
                    }
                case 3: // View detail
                    {
                        this.flowLayoutPanelHeader.Controls.Clear();
                        this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);

                        this.list_account_layout.Controls.Clear();
                        var viewLayout = new EditLayout(this._home, this._id, "view");
                        this.title_lb.Text = "Account Detail";
                        this.list_account_layout.Controls.Add(viewLayout);
                        break;
                    }
                default: break;
            }
        }

        private async void LoadAccountList()
        {
            this.list_account_layout.Controls.Clear();
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await ApiClient.GetAsync<List<Account>>("Account");
                var userData = result.Data.Where(item => item.Role == "User");

                if (result.Code == 0)
                {
                    var allAccounts = result.Data.OrderBy(p => p.Name).ToList();
                    
                    foreach (var item in allAccounts)
                    {
                        this.list_account_layout.Controls.Add(new ComponentAccount(this._home, this, item));
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
            this._home.Controls.Add(new AccountLayout(_home, 1, ""));
        }

        private void btn_backList_Click(object sender, EventArgs e)
        {
            this._home.Controls.Clear();
            this._home.Controls.Add(new AccountLayout(_home, 0, ""));
        }


    }
}
