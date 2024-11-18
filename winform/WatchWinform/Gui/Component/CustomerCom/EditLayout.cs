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

namespace WatchWinform.Gui.Component.CustomerCom
{
    public partial class EditLayout : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();
        private readonly CategoryService _cateogryService = new CategoryService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Customer customerLoaded;

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
                this.description_rtb.ReadOnly = false;

                this.btn_exit.Visible = true;
                this.btn_save.Visible = true;
            }
            else
            {
                this.name_txt.ReadOnly = true;
                this.description_rtb.ReadOnly = true;

                this.btn_exit.Visible = false;
                this.btn_save.Visible = false;
            }
        }
        private async void ViewMode()
        {
            try
            {
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._customerService.GetById(this._id);
                this.customerLoaded = result.Data;
                this.BindingData(customerLoaded);
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
                var customer = new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = this.name_txt.Text,
                    //Description = this.description_rtb.Text
                };

                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _customerService.Create(customer);
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
                var result = await this._customerService.GetById(this._id);
                this.customerLoaded = result.Data;
                this.BindingData(customerLoaded);
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
                var customer = new Customer
                {
                    Id = this._id,
                    Name = this.name_txt.Text,
                    //Description = this.description_rtb.Text
                };
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._customerService.Update(customer);
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

        private void BindingData(Customer customer)
        {
            this.name_txt.Text = customer.Name;
            //this.description_rtb.Text = customer.Description;
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
            this._home.Controls.Add(new CustomerLayout(_home, 0, ""));
        }

    }
}
