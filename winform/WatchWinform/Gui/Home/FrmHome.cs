using Newtonsoft.Json;
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
using WatchWinform.Gui;
using WatchWinform.Gui.Component;
using WatchWinform.Gui.Component.ProductCom;
using WatchWinform.Gui.Component.ImportCom;
using WatchWinform.Gui.Component.ImportedHistoryCom;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Constant;
using WatchWinform.Gui.Login;
using WatchWinform.Gui.Component.ExportCom;
using WatchWinform.Gui.Component.ExportedHistoryCom;
using WatchWinform.Gui.Component.BrandCom;
using WatchWinform.Gui.Component.CategoryCom;
using WatchWinform.Gui.Component.CustomerCom;
//using WatchWinform.Gui.Component.ProviderCom;
//using WatchWinform.Gui.Component.TransportCom;
using WatchWinform.Gui.Component.AboutCom;
using WatchWinform.Gui.Component.AccountCom;
//using WatchWinform.Gui.Component.ChartCom;

namespace WatchWinform
{
    public partial class FrmHome : Form
    {
        bool sidebarExpand = true;
        bool warehouseCollapse = true;
        bool exportCollapse = true;
        bool systemCollapse = true;
        int stepSizeForSubMenu = 41;
        int sizeMenu = 41;
        int quantitySubMenuWareHouse = 3;
        int quantitySubMenuExport = 2;
        int quantitySubMenuSystem = 6;
        
        public FrmHome()
        {
            InitializeComponent();
            this.LoadMenuByRole();
            this.pnl_home.Controls.Clear();
            this.pnl_home.Controls.Add(new ProductLayout(this.pnl_home, 0, ""));

            // Dybaly
            this.btn_provider.Enabled = false;
            this.btn_transporter.Enabled = false;
            this.btn_chart.Enabled= false;
        }
        private void LoadMenuByRole()
        {
            if(UserGlobal.Role == Role.Admin)
            {
                this.quantitySubMenuWareHouse = 3;
                this.quantitySubMenuExport = 2;
                this.quantitySubMenuSystem = 6;
                this.btn_export.Visible = true;
                this.btn_import.Visible = true;
                this.btn_account.Visible = true;
            }
            else if (UserGlobal.Role == Role.User)
            {
                this.quantitySubMenuWareHouse = 2;
                this.quantitySubMenuExport = 1;
                this.quantitySubMenuSystem = 5;
                this.btn_export.Visible = false;
                this.btn_import.Visible = false;
                this.btn_account.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        // animation Warehouse_collapse
        private void warehouse_collapse_Tick(object sender, EventArgs e)
        {
            if (warehouseCollapse)
            {
                if (sidebarExpand == false)
                {
                    sidebarTimer.Start();
                }
                layout_warehouse_collapse.Height += 5;
                var test = this.btn_warehouse.Height;
                if(layout_warehouse_collapse.Height >= (this.stepSizeForSubMenu * this.quantitySubMenuWareHouse) + this.sizeMenu)
                {
                    warehouseCollapse = false;
                    warehouseCollapseTimer.Stop();
                }
            }
            else
            {
                
                layout_warehouse_collapse.Height -= 5;
                if (layout_warehouse_collapse.Height <= layout_warehouse_collapse.MinimumSize.Height)
                {
                    warehouseCollapse = true;
                    warehouseCollapseTimer.Stop();
                }
            }
        }
        private void export_collapse_Tick(object sender, EventArgs e)
        {
            if (exportCollapse)
            {
                if (sidebarExpand == false)
                {
                    sidebarTimer.Start();
                }
                layout_export_collapse.Height += 5;
                if (layout_export_collapse.Height >= (this.stepSizeForSubMenu * this.quantitySubMenuExport) + this.sizeMenu)
                {
                    exportCollapse = false;
                    exportCollapseTimer.Stop();
                }
            }
            else
            {
                
                layout_export_collapse.Height -= 5;
                if (layout_export_collapse.Height <= layout_export_collapse.MinimumSize.Height)
                {
                    exportCollapse = true;
                    exportCollapseTimer.Stop();
                }
            }
        }
        private void systemCollapseTimer_Tick(object sender, EventArgs e)
        {
            if (systemCollapse)
            {
                if (sidebarExpand == false)
                {
                    sidebarTimer.Start();
                }
                layout_system.Height += 10;
                if (layout_system.Height >= (this.stepSizeForSubMenu * this.quantitySubMenuSystem) + this.sizeMenu)
                {
                    systemCollapse = false;
                    systemCollapseTimer.Stop();
                }
            }
            else
            {

                layout_system.Height -= 10;
                if (layout_system.Height <= layout_system.MinimumSize.Height)
                {
                    systemCollapse = true;
                    systemCollapseTimer.Stop();
                }
            }
        }
        // animation sidebar
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if(warehouseCollapse == false)
                {
                    warehouseCollapseTimer.Start();
                }
                if (exportCollapse == false)
                {
                    exportCollapseTimer.Start();
                }
                animateZoomOut(btn_menu);
                animateZoomOut(btn_import);
                animateZoomOut(btn_product);
                animateZoomOut(btn_import_history);
                animateZoomOut(btn_exportD);
                animateZoomOut(btn_export);
                animateZoomOut(btn_export_history);
                animateZoomOut(btn_warehouse);
                animateZoomOut(btn_provider);
                animateZoomOut(btn_transporter);
                animateZoomOut(btn_about);
                sidebar.Width -= 10;
                pnl_home.Width += 10;

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }

            }
            else
            {
                animateZoom(btn_menu, "Menu");
                animateZoom(btn_import, "Import");
                animateZoom(btn_product, "Product");
                animateZoom(btn_import_history, "Imported History");
                animateZoom(btn_exportD, "Order");
                animateZoom(btn_export_history, "Order History");
                animateZoom(btn_export, "Order");
                animateZoom(btn_warehouse, "Warehouse");
                animateZoom(btn_transporter, "Transport");
                animateZoom(btn_provider, "Provider");
                animateZoom(btn_about, "About");

                sidebar.Width += 10;
                pnl_home.Width -= 10;

                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }

        }
        private void animateZoomOut(Button T)
        {
            if (T.Width > T.MinimumSize.Width)
            {
                T.Width -= 10;
            }
            T.Text = "";
        }
        private void animateZoom(Button T, String txt)
        {
            if (T.Width < T.MaximumSize.Width)
            {
                T.Width += 10;
            }
            T.Text = txt;
        }


        private void btn_menu_Click(object sender, EventArgs e)
        {
            //sidebarTimer.Start();
        }
        private void btn_warehouse_Click(object sender, EventArgs e)
        {
            warehouseCollapseTimer.Start();
        }
        private void btn_exportD_Click(object sender, EventArgs e)
        {
            exportCollapseTimer.Start();
        }
        private void btn_Product_click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();
            this.pnl_home.Controls.Add(new ProductLayout(this.pnl_home, 0, ""));
        }
        private void btn_Import_click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new ImportLayout(this.pnl_home, 0));
        }

        private void btn_Imported_history_click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new ImportedHistoryLayout(this.pnl_home, 0,""));
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new ExportLayout(this.pnl_home, 0));
        }

        private void btn_export_history_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new ExportedHistoryLayout(this.pnl_home, 0, ""));
        }

        private void btn_warehouse_Click_1(object sender, EventArgs e)
        {

        }
        private void btn_system_Click(object sender, EventArgs e)
        {
            systemCollapseTimer.Start();
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new CategoryLayout(this.pnl_home, 0, ""));
        }

        private void btn_brand_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new BrandLayout(this.pnl_home, 0, ""));
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new CustomerLayout(this.pnl_home, 0, ""));
        }
        private void btn_provider_Click(object sender, EventArgs e)
        {
            //this.pnl_home.Controls.Clear();

            //this.pnl_home.Controls.Add(new ProviderLayout(this.pnl_home, 0, ""));
        }

        private void btn_transporter_Click(object sender, EventArgs e)
        {
            //this.pnl_home.Controls.Clear();
            //this.pnl_home.Controls.Add(new TransportLayout(this.pnl_home, 0, ""));
        }
        private void btn_account_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new AccountLayout(this.pnl_home, 0, ""));
        }
        private void btn_chart_Click(object sender, EventArgs e)
        {
           // this.pnl_home.Controls.Clear();

            //this.pnl_home.Controls.Add(new Chart());
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            this.pnl_home.Controls.Clear();

            this.pnl_home.Controls.Add(new About());
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            UserGlobal.Id = string.Empty;
            UserGlobal.Role = string.Empty;
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            // Thêm sự kiện FormClosed vào FrmHome
            frmLogin.FormClosed += (object obj, FormClosedEventArgs args) => {
                // Khi FrmHome đóng lại, đóng ứng dụng
                Application.Exit();
            };
            frmLogin.Show();
        }

       
    }
}
