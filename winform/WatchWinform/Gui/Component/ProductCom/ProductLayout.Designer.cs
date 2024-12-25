namespace WatchWinform.Gui.Component.ProductCom
{
    partial class ProductLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.list_product_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_backList = new System.Windows.Forms.Button();
            this.title_lb = new System.Windows.Forms.Label();
            this.cat_cbb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelHeader.SuspendLayout();
            this.flowLayoutSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_product_layout
            // 
            this.list_product_layout.AutoScroll = true;
            this.list_product_layout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_product_layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.list_product_layout.Location = new System.Drawing.Point(0, 98);
            this.list_product_layout.Name = "list_product_layout";
            this.list_product_layout.Size = new System.Drawing.Size(1100, 671);
            this.list_product_layout.TabIndex = 0;
            this.list_product_layout.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.flowLayoutSearch);
            this.panel1.Controls.Add(this.flowLayoutPanelHeader);
            this.panel1.Controls.Add(this.title_lb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 100);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanelHeader
            // 
            this.flowLayoutPanelHeader.Controls.Add(this.btn_add);
            this.flowLayoutPanelHeader.Controls.Add(this.btn_backList);
            this.flowLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelHeader.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelHeader.Location = new System.Drawing.Point(820, 0);
            this.flowLayoutPanelHeader.Name = "flowLayoutPanelHeader";
            this.flowLayoutPanelHeader.Padding = new System.Windows.Forms.Padding(0, 30, 10, 0);
            this.flowLayoutPanelHeader.Size = new System.Drawing.Size(280, 100);
            this.flowLayoutPanelHeader.TabIndex = 6;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_add.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(153, 33);
            this.btn_add.Name = "btn_add";
            this.btn_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_add.Size = new System.Drawing.Size(114, 32);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "Create";
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_backList
            // 
            this.btn_backList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_backList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_backList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backList.Location = new System.Drawing.Point(33, 33);
            this.btn_backList.Name = "btn_backList";
            this.btn_backList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_backList.Size = new System.Drawing.Size(114, 32);
            this.btn_backList.TabIndex = 5;
            this.btn_backList.Text = "Back to List";
            this.btn_backList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_backList.UseVisualStyleBackColor = false;
            this.btn_backList.Click += new System.EventHandler(this.btn_backList_Click);
            // 
            // title_lb
            // 
            this.title_lb.AutoSize = true;
            this.title_lb.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_lb.Location = new System.Drawing.Point(24, 33);
            this.title_lb.Name = "title_lb";
            this.title_lb.Size = new System.Drawing.Size(39, 19);
            this.title_lb.TabIndex = 5;
            this.title_lb.Text = "Title";
            // 
            // cat_cbb
            // 
            this.cat_cbb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cat_cbb.FormattingEnabled = true;
            this.cat_cbb.Location = new System.Drawing.Point(84, 6);
            this.cat_cbb.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cat_cbb.Name = "cat_cbb";
            this.cat_cbb.Size = new System.Drawing.Size(253, 25);
            this.cat_cbb.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Danh mục";
            // 
            // flowLayoutSearch
            // 
            this.flowLayoutSearch.Controls.Add(this.label6);
            this.flowLayoutSearch.Controls.Add(this.cat_cbb);
            this.flowLayoutSearch.Controls.Add(this.btn_search);
            this.flowLayoutSearch.Location = new System.Drawing.Point(294, 20);
            this.flowLayoutSearch.Name = "flowLayoutSearch";
            this.flowLayoutSearch.Size = new System.Drawing.Size(427, 45);
            this.flowLayoutSearch.TabIndex = 10;
            // 
            // btn_search
            // 
            this.btn_search.AutoSize = true;
            this.btn_search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_search.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Image = global::WatchWinform.Properties.Resources.search__1_;
            this.btn_search.Location = new System.Drawing.Point(343, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(30, 30);
            this.btn_search.TabIndex = 10;
            this.btn_search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // ProductLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.list_product_layout);
            this.MaximumSize = new System.Drawing.Size(1100, 769);
            this.MinimumSize = new System.Drawing.Size(1100, 769);
            this.Name = "ProductLayout";
            this.Size = new System.Drawing.Size(1100, 769);
            this.Load += new System.EventHandler(this.ProductLayout_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanelHeader.ResumeLayout(false);
            this.flowLayoutSearch.ResumeLayout(false);
            this.flowLayoutSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel list_product_layout;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label title_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHeader;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_backList;
        private System.Windows.Forms.ComboBox cat_cbb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSearch;
        private System.Windows.Forms.Button btn_search;
    }
}
