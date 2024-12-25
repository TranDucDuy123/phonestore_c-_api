namespace WatchWinform
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.warehouseCollapseTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_home = new System.Windows.Forms.Panel();
            this.exportCollapseTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_sidebar = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_menu = new System.Windows.Forms.Button();
            this.layout_warehouse_collapse = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_warehouse = new System.Windows.Forms.Button();
            this.btn_product = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_import_history = new System.Windows.Forms.Button();
            this.layout_export_collapse = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_exportD = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_export_history = new System.Windows.Forms.Button();
            this.layout_system = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_system = new System.Windows.Forms.Button();
            this.btn_customer = new System.Windows.Forms.Button();
            this.btn_transporter = new System.Windows.Forms.Button();
            this.btn_provider = new System.Windows.Forms.Button();
            this.btn_category = new System.Windows.Forms.Button();
            this.btn_brand = new System.Windows.Forms.Button();
            this.btn_account = new System.Windows.Forms.Button();
            this.btn_chart = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.systemCollapseTimer = new System.Windows.Forms.Timer(this.components);
            this.pnl_sidebar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.layout_warehouse_collapse.SuspendLayout();
            this.layout_export_collapse.SuspendLayout();
            this.layout_system.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // warehouseCollapseTimer
            // 
            this.warehouseCollapseTimer.Interval = 5;
            this.warehouseCollapseTimer.Tick += new System.EventHandler(this.warehouse_collapse_Tick);
            // 
            // pnl_home
            // 
            this.pnl_home.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_home.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_home.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_home.Location = new System.Drawing.Point(304, 0);
            this.pnl_home.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.pnl_home.MinimumSize = new System.Drawing.Size(1098, 769);
            this.pnl_home.Name = "pnl_home";
            this.pnl_home.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.pnl_home.Size = new System.Drawing.Size(1098, 769);
            this.pnl_home.TabIndex = 2;
            // 
            // exportCollapseTimer
            // 
            this.exportCollapseTimer.Interval = 5;
            this.exportCollapseTimer.Tick += new System.EventHandler(this.export_collapse_Tick);
            // 
            // pnl_sidebar
            // 
            this.pnl_sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnl_sidebar.Controls.Add(this.flowLayoutPanel1);
            this.pnl_sidebar.Controls.Add(this.sidebar);
            this.pnl_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_sidebar.Location = new System.Drawing.Point(0, 0);
            this.pnl_sidebar.Name = "pnl_sidebar";
            this.pnl_sidebar.Size = new System.Drawing.Size(296, 769);
            this.pnl_sidebar.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_logout);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 707);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 62);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btn_logout
            // 
            this.btn_logout.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.Image = global::WatchWinform.Properties.Resources.leave;
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(3, 9);
            this.btn_logout.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_logout.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_logout.Size = new System.Drawing.Size(285, 50);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // sidebar
            // 
            this.sidebar.AutoScroll = true;
            this.sidebar.BackColor = System.Drawing.Color.Transparent;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.layout_warehouse_collapse);
            this.sidebar.Controls.Add(this.layout_export_collapse);
            this.sidebar.Controls.Add(this.layout_system);
            this.sidebar.Controls.Add(this.btn_chart);
            this.sidebar.Controls.Add(this.btn_about);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MinimumSize = new System.Drawing.Size(100, 400);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(296, 701);
            this.sidebar.TabIndex = 2;
            this.sidebar.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_menu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 109);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // btn_menu
            // 
            this.btn_menu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_menu.BackColor = System.Drawing.Color.Transparent;
            this.btn_menu.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_menu.Image = global::WatchWinform.Properties.Resources.list;
            this.btn_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_menu.Location = new System.Drawing.Point(0, 0);
            this.btn_menu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu.MaximumSize = new System.Drawing.Size(290, 112);
            this.btn_menu.MinimumSize = new System.Drawing.Size(96, 112);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_menu.Size = new System.Drawing.Size(290, 112);
            this.btn_menu.TabIndex = 2;
            this.btn_menu.Text = "Menu";
            this.btn_menu.UseVisualStyleBackColor = false;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // layout_warehouse_collapse
            // 
            this.layout_warehouse_collapse.Controls.Add(this.btn_warehouse);
            this.layout_warehouse_collapse.Controls.Add(this.btn_product);
            this.layout_warehouse_collapse.Controls.Add(this.btn_import);
            this.layout_warehouse_collapse.Controls.Add(this.btn_import_history);
            this.layout_warehouse_collapse.Location = new System.Drawing.Point(3, 118);
            this.layout_warehouse_collapse.MinimumSize = new System.Drawing.Size(96, 50);
            this.layout_warehouse_collapse.Name = "layout_warehouse_collapse";
            this.layout_warehouse_collapse.Size = new System.Drawing.Size(290, 50);
            this.layout_warehouse_collapse.TabIndex = 6;
            // 
            // btn_warehouse
            // 
            this.btn_warehouse.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_warehouse.Image = ((System.Drawing.Image)(resources.GetObject("btn_warehouse.Image")));
            this.btn_warehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_warehouse.Location = new System.Drawing.Point(0, 0);
            this.btn_warehouse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_warehouse.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_warehouse.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_warehouse.Name = "btn_warehouse";
            this.btn_warehouse.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_warehouse.Size = new System.Drawing.Size(285, 50);
            this.btn_warehouse.TabIndex = 4;
            this.btn_warehouse.Text = "Warehouse";
            this.btn_warehouse.UseVisualStyleBackColor = true;
            this.btn_warehouse.Click += new System.EventHandler(this.btn_warehouse_Click);
            // 
            // btn_product
            // 
            this.btn_product.BackColor = System.Drawing.Color.White;
            this.btn_product.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btn_product.Image = global::WatchWinform.Properties.Resources.responsive;
            this.btn_product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_product.Location = new System.Drawing.Point(15, 50);
            this.btn_product.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_product.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_product.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_product.Name = "btn_product";
            this.btn_product.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_product.Size = new System.Drawing.Size(270, 51);
            this.btn_product.TabIndex = 5;
            this.btn_product.Text = "Product";
            this.btn_product.UseVisualStyleBackColor = false;
            this.btn_product.Click += new System.EventHandler(this.btn_Product_click);
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.White;
            this.btn_import.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btn_import.Image = global::WatchWinform.Properties.Resources.import;
            this.btn_import.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_import.Location = new System.Drawing.Point(15, 101);
            this.btn_import.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_import.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_import.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_import.Name = "btn_import";
            this.btn_import.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_import.Size = new System.Drawing.Size(270, 51);
            this.btn_import.TabIndex = 5;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_Import_click);
            // 
            // btn_import_history
            // 
            this.btn_import_history.BackColor = System.Drawing.Color.White;
            this.btn_import_history.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btn_import_history.Image = global::WatchWinform.Properties.Resources.history;
            this.btn_import_history.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_import_history.Location = new System.Drawing.Point(15, 152);
            this.btn_import_history.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_import_history.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_import_history.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_import_history.Name = "btn_import_history";
            this.btn_import_history.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_import_history.Size = new System.Drawing.Size(270, 51);
            this.btn_import_history.TabIndex = 5;
            this.btn_import_history.Text = "Imported History";
            this.btn_import_history.UseVisualStyleBackColor = false;
            this.btn_import_history.Click += new System.EventHandler(this.btn_Imported_history_click);
            // 
            // layout_export_collapse
            // 
            this.layout_export_collapse.Controls.Add(this.btn_exportD);
            this.layout_export_collapse.Controls.Add(this.btn_export);
            this.layout_export_collapse.Controls.Add(this.btn_export_history);
            this.layout_export_collapse.Location = new System.Drawing.Point(3, 174);
            this.layout_export_collapse.MinimumSize = new System.Drawing.Size(96, 50);
            this.layout_export_collapse.Name = "layout_export_collapse";
            this.layout_export_collapse.Size = new System.Drawing.Size(290, 50);
            this.layout_export_collapse.TabIndex = 7;
            // 
            // btn_exportD
            // 
            this.btn_exportD.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportD.Image = global::WatchWinform.Properties.Resources.upload1;
            this.btn_exportD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exportD.Location = new System.Drawing.Point(0, 0);
            this.btn_exportD.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exportD.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_exportD.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_exportD.Name = "btn_exportD";
            this.btn_exportD.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_exportD.Size = new System.Drawing.Size(285, 50);
            this.btn_exportD.TabIndex = 6;
            this.btn_exportD.Text = "Order";
            this.btn_exportD.UseVisualStyleBackColor = true;
            this.btn_exportD.Click += new System.EventHandler(this.btn_exportD_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.White;
            this.btn_export.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Image = global::WatchWinform.Properties.Resources.export;
            this.btn_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_export.Location = new System.Drawing.Point(15, 50);
            this.btn_export.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_export.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_export.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_export.Name = "btn_export";
            this.btn_export.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_export.Size = new System.Drawing.Size(270, 51);
            this.btn_export.TabIndex = 7;
            this.btn_export.Text = "Order";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_export_history
            // 
            this.btn_export_history.BackColor = System.Drawing.Color.White;
            this.btn_export_history.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export_history.Image = global::WatchWinform.Properties.Resources.history;
            this.btn_export_history.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_export_history.Location = new System.Drawing.Point(15, 101);
            this.btn_export_history.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_export_history.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_export_history.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_export_history.Name = "btn_export_history";
            this.btn_export_history.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_export_history.Size = new System.Drawing.Size(270, 51);
            this.btn_export_history.TabIndex = 7;
            this.btn_export_history.Text = "Ordered History";
            this.btn_export_history.UseVisualStyleBackColor = false;
            this.btn_export_history.Click += new System.EventHandler(this.btn_export_history_Click);
            // 
            // layout_system
            // 
            this.layout_system.Controls.Add(this.btn_system);
            this.layout_system.Controls.Add(this.btn_customer);
            this.layout_system.Controls.Add(this.btn_transporter);
            this.layout_system.Controls.Add(this.btn_provider);
            this.layout_system.Controls.Add(this.btn_category);
            this.layout_system.Controls.Add(this.btn_brand);
            this.layout_system.Controls.Add(this.btn_account);
            this.layout_system.Location = new System.Drawing.Point(3, 230);
            this.layout_system.MinimumSize = new System.Drawing.Size(96, 50);
            this.layout_system.Name = "layout_system";
            this.layout_system.Size = new System.Drawing.Size(290, 50);
            this.layout_system.TabIndex = 8;
            // 
            // btn_system
            // 
            this.btn_system.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_system.Image = global::WatchWinform.Properties.Resources.system_update;
            this.btn_system.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_system.Location = new System.Drawing.Point(0, 0);
            this.btn_system.Margin = new System.Windows.Forms.Padding(0);
            this.btn_system.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_system.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_system.Name = "btn_system";
            this.btn_system.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_system.Size = new System.Drawing.Size(285, 50);
            this.btn_system.TabIndex = 6;
            this.btn_system.Text = "System";
            this.btn_system.UseVisualStyleBackColor = true;
            this.btn_system.Click += new System.EventHandler(this.btn_system_Click);
            // 
            // btn_customer
            // 
            this.btn_customer.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer.Image = global::WatchWinform.Properties.Resources.customer_review__2_;
            this.btn_customer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_customer.Location = new System.Drawing.Point(15, 50);
            this.btn_customer.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_customer.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_customer.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_customer.Name = "btn_customer";
            this.btn_customer.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_customer.Size = new System.Drawing.Size(270, 51);
            this.btn_customer.TabIndex = 6;
            this.btn_customer.Text = "Customer";
            this.btn_customer.UseVisualStyleBackColor = true;
            this.btn_customer.Click += new System.EventHandler(this.btn_customer_Click);
            // 
            // btn_transporter
            // 
            this.btn_transporter.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btn_transporter.Image = global::WatchWinform.Properties.Resources.truck;
            this.btn_transporter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_transporter.Location = new System.Drawing.Point(15, 101);
            this.btn_transporter.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_transporter.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_transporter.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_transporter.Name = "btn_transporter";
            this.btn_transporter.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_transporter.Size = new System.Drawing.Size(270, 51);
            this.btn_transporter.TabIndex = 6;
            this.btn_transporter.Text = "Transport";
            this.btn_transporter.UseVisualStyleBackColor = true;
            this.btn_transporter.Click += new System.EventHandler(this.btn_transporter_Click);
            // 
            // btn_provider
            // 
            this.btn_provider.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btn_provider.Image = global::WatchWinform.Properties.Resources.provider__1_;
            this.btn_provider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_provider.Location = new System.Drawing.Point(15, 152);
            this.btn_provider.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_provider.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_provider.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_provider.Name = "btn_provider";
            this.btn_provider.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_provider.Size = new System.Drawing.Size(270, 51);
            this.btn_provider.TabIndex = 5;
            this.btn_provider.Text = "Provider";
            this.btn_provider.UseVisualStyleBackColor = true;
            this.btn_provider.Click += new System.EventHandler(this.btn_provider_Click);
            // 
            // btn_category
            // 
            this.btn_category.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_category.Image = global::WatchWinform.Properties.Resources.categories;
            this.btn_category.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_category.Location = new System.Drawing.Point(15, 203);
            this.btn_category.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_category.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_category.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_category.Name = "btn_category";
            this.btn_category.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_category.Size = new System.Drawing.Size(270, 51);
            this.btn_category.TabIndex = 5;
            this.btn_category.Text = "Category";
            this.btn_category.UseVisualStyleBackColor = true;
            this.btn_category.Click += new System.EventHandler(this.btn_category_Click);
            // 
            // btn_brand
            // 
            this.btn_brand.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_brand.Image = global::WatchWinform.Properties.Resources.brand;
            this.btn_brand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_brand.Location = new System.Drawing.Point(15, 254);
            this.btn_brand.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_brand.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_brand.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_brand.Name = "btn_brand";
            this.btn_brand.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_brand.Size = new System.Drawing.Size(270, 51);
            this.btn_brand.TabIndex = 6;
            this.btn_brand.Text = "Brand";
            this.btn_brand.UseVisualStyleBackColor = true;
            this.btn_brand.Click += new System.EventHandler(this.btn_brand_Click);
            // 
            // btn_account
            // 
            this.btn_account.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_account.Image = global::WatchWinform.Properties.Resources.crm;
            this.btn_account.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_account.Location = new System.Drawing.Point(15, 305);
            this.btn_account.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_account.MaximumSize = new System.Drawing.Size(270, 112);
            this.btn_account.MinimumSize = new System.Drawing.Size(70, 40);
            this.btn_account.Name = "btn_account";
            this.btn_account.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_account.Size = new System.Drawing.Size(270, 51);
            this.btn_account.TabIndex = 6;
            this.btn_account.Text = "Employees";
            this.btn_account.UseVisualStyleBackColor = true;
            this.btn_account.Click += new System.EventHandler(this.btn_account_Click);
            // 
            // btn_chart
            // 
            this.btn_chart.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chart.Image = global::WatchWinform.Properties.Resources.pie_chart;
            this.btn_chart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chart.Location = new System.Drawing.Point(3, 286);
            this.btn_chart.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_chart.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_chart.Name = "btn_chart";
            this.btn_chart.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_chart.Size = new System.Drawing.Size(285, 50);
            this.btn_chart.TabIndex = 6;
            this.btn_chart.Text = "Chart";
            this.btn_chart.UseVisualStyleBackColor = true;
            this.btn_chart.Click += new System.EventHandler(this.btn_chart_Click);
            // 
            // btn_about
            // 
            this.btn_about.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_about.Image = global::WatchWinform.Properties.Resources.information_button;
            this.btn_about.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_about.Location = new System.Drawing.Point(3, 342);
            this.btn_about.MaximumSize = new System.Drawing.Size(285, 112);
            this.btn_about.MinimumSize = new System.Drawing.Size(96, 50);
            this.btn_about.Name = "btn_about";
            this.btn_about.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btn_about.Size = new System.Drawing.Size(285, 50);
            this.btn_about.TabIndex = 6;
            this.btn_about.Text = "About";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // systemCollapseTimer
            // 
            this.systemCollapseTimer.Interval = 5;
            this.systemCollapseTimer.Tick += new System.EventHandler(this.systemCollapseTimer_Tick);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 769);
            this.Controls.Add(this.pnl_sidebar);
            this.Controls.Add(this.pnl_home);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1430, 816);
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.pnl_sidebar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.layout_warehouse_collapse.ResumeLayout(false);
            this.layout_export_collapse.ResumeLayout(false);
            this.layout_system.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Timer warehouseCollapseTimer;
        private System.Windows.Forms.Panel pnl_home;
        private System.Windows.Forms.Timer exportCollapseTimer;
        private System.Windows.Forms.Panel pnl_sidebar;
        public System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.FlowLayoutPanel layout_warehouse_collapse;
        private System.Windows.Forms.Button btn_product;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_import_history;
        private System.Windows.Forms.FlowLayoutPanel layout_export_collapse;
        private System.Windows.Forms.Button btn_exportD;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_export_history;
        private System.Windows.Forms.Button btn_provider;
        private System.Windows.Forms.Button btn_transporter;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_warehouse;
        private System.Windows.Forms.Button btn_system;
        private System.Windows.Forms.FlowLayoutPanel layout_system;
        private System.Windows.Forms.Button btn_category;
        private System.Windows.Forms.Button btn_brand;
        private System.Windows.Forms.Button btn_customer;
        private System.Windows.Forms.Timer systemCollapseTimer;
        private System.Windows.Forms.Button btn_account;
        private System.Windows.Forms.Button btn_chart;
    }
}