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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WatchWinform.Shared.Constant;

namespace WatchWinform.Gui.Component.AccountCom
{
    public partial class EditLayout : UserControl
    {
        private readonly AccountService _accountService = new AccountService();
        private readonly CategoryService _cateogryService = new CategoryService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Account accountLoaded;

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

        private void EditLayout_LoadAsync(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case "create":
                    this.CreateMode();
                    break;
                case "edit":
                    this.EditMode();
                    break;
                case "view":
                    this.ViewMode();
                    break;
                default:
                    this.ViewMode();
                    break;
            }
        }

        private void ChangeMode(string mode)
        {
            if (mode != "view")
            {
                this.name_txt.ReadOnly = false;   
                this.username_txt.ReadOnly = false;

                this.btn_exit.Visible = true;
                this.btn_save.Visible = true;
            }
            else
            {
                this.name_txt.ReadOnly = true;
                this.username_txt.ReadOnly = true;

                this.btn_exit.Visible = false;
                this.btn_save.Visible = false;
            }
        }
        private async void ViewMode()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._accountService.GetById(this._id);
                this.accountLoaded = result.Data;
                this.BindingData(accountLoaded);
                this.ChangeMode("view");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void CreateMode()
        {
            this.ChangeMode("create");
        }
        private async void CreateData()
        {
            try
            {
                var account = new Account
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = this.name_txt.Text,
                    UserName = this.username_txt.Text,
                };

                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _accountService.Create(account);
                if (result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this.BackToList();
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
        private async void EditMode()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._accountService.GetById(this._id);
                this.accountLoaded = result.Data;
                this.BindingData(accountLoaded);
                this.ChangeMode("edit");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void EditData()
        {
            try
            {
                var account = new Account
                {
                    Id = this._id,
                    Name = this.name_txt.Text,
                    UserName = this.username_txt.Text,
                };
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._accountService.Update(account);
                if(result.Code == 0)
                {
                    MessageBox.Show(result.Message);
                    this.BackToList();
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

        private void BindingData(Account account)
        {
            this.name_txt.Text = account.Name;
            this.username_txt.Text = account.UserName;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (this._action)
            {
                case "create":
                    this.CreateData();
                    break;
                case "edit":
                    this.EditData();
                    break;
                case "view":
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
            this._home.Controls.Add(new AccountLayout(_home, 0, ""));
        }

    }
}
