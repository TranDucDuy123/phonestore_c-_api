using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using WatchWinform.Service;
using WatchWinform.API;
using WatchWinform.Datas.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WatchWinform.Gui.Login
{
    public partial class FrmLogin : Form
    {
        private readonly AccountService _accountService;
        public FrmLogin()
        {
            this._accountService = new AccountService();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Test api - GetList Brand
            // Khởi tạo ApiClient với baseAddress của API và bearerToken
            try
            {
                
                ApiClient.Initialize();
                var user = new LoginReq
                {
                    UserName = this.username_txt.Text.Trim(),
                    Password = this.password_txt.Text.Trim(),
                };
                var result = await ApiClient.PostAsync<LoginRes>("Auth/login", JsonConvert.SerializeObject(user));

                if (result.Code == 0)
                {
                    ApiSettings.BearerToken = result.Data.AccessToken;
                    ApiClient.Initialize();
                    MessageBox.Show($"Xin chào {result.Data.User.Name}");
                    this.Hide();
                    FrmHome form2 = new FrmHome();
                    // Thêm sự kiện FormClosed vào FrmHome
                    form2.FormClosed += (object obj, FormClosedEventArgs args) => {
                        // Khi FrmHome đóng lại, đóng ứng dụng
                        Application.Exit();
                    };
                    form2.Show();
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
                // Gán danh sách thương hiệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            this.username_txt.BackColor = Color.White;
            this.pnl_username.BackColor = Color.White;
            this.password_txt.BackColor = SystemColors.Control;
            this.pnl_pass.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.username_txt.BackColor = SystemColors.Control;
            this.pnl_username.BackColor = SystemColors.Control;
            this.password_txt.BackColor = Color.White;
            this.pnl_pass.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
