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
using WatchWinform.Datas.Models;

namespace WatchWinform.Gui.Component.BrandCom
{
    public partial class EditLayout : UserControl
    {
        private readonly BrandService _brandService = new BrandService();
        private readonly CategoryService _cateogryService = new CategoryService();
        private Panel _home = new Panel();
        string _id = "";
        string _action = "";
        Brand brandLoaded;

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
                var result = await this._brandService.GetById(this._id);
                this.brandLoaded = result.Data;
                this.BindingData(brandLoaded);
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
                var brand = new Brand
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = this.name_txt.Text,
                    Description = this.description_rtb.Text
                };

                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await _brandService.Create(brand);
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
                var result = await this._brandService.GetById(this._id);
                this.brandLoaded = result.Data;
                this.BindingData(brandLoaded);
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
                var brand = new Brand
                {
                    Id = this._id,
                    Name = this.name_txt.Text,
                    Description = this.description_rtb.Text
                };
                // Gọi API sử dụng phương thức Get và lấy kết quả
                var result = await this._brandService.Update(brand);
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

        private void BindingData(Brand brand)
        {
            this.name_txt.Text = brand.Name;
            this.description_rtb.Text = brand.Description;
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
            this._home.Controls.Add(new BrandLayout(_home, 0, ""));
        }

    }
}
