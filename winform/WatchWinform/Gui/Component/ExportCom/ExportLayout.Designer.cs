namespace WatchWinform.Gui.Component.ExportCom
{
    partial class ExportLayout
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.title_lb = new System.Windows.Forms.Label();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.list_product_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_selectedList = new System.Windows.Forms.Button();
            this.btn_productList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelHeader.SuspendLayout();
            this.pnl_footer.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
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
            this.flowLayoutPanelHeader.Controls.Add(this.btn_selectedList);
            this.flowLayoutPanelHeader.Controls.Add(this.btn_productList);
            this.flowLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelHeader.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelHeader.Location = new System.Drawing.Point(684, 0);
            this.flowLayoutPanelHeader.Name = "flowLayoutPanelHeader";
            this.flowLayoutPanelHeader.Padding = new System.Windows.Forms.Padding(0, 30, 10, 0);
            this.flowLayoutPanelHeader.Size = new System.Drawing.Size(416, 100);
            this.flowLayoutPanelHeader.TabIndex = 6;
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
            // pnl_footer
            // 
            this.pnl_footer.Controls.Add(this.btn_reset);
            this.pnl_footer.Controls.Add(this.btn_save);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(0, 689);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Size = new System.Drawing.Size(1100, 80);
            this.pnl_footer.TabIndex = 2;
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.list_product_layout);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 100);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1100, 589);
            this.pnl_main.TabIndex = 3;
            // 
            // list_product_layout
            // 
            this.list_product_layout.AutoScroll = true;
            this.list_product_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_product_layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.list_product_layout.Location = new System.Drawing.Point(0, 0);
            this.list_product_layout.Name = "list_product_layout";
            this.list_product_layout.Size = new System.Drawing.Size(1100, 589);
            this.list_product_layout.TabIndex = 1;
            this.list_product_layout.WrapContents = false;
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.Red;
            this.btn_reset.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Image = global::WatchWinform.Properties.Resources.undo;
            this.btn_reset.Location = new System.Drawing.Point(833, 25);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(107, 30);
            this.btn_reset.TabIndex = 1;
            this.btn_reset.Text = "Reset";
            this.btn_reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_save.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = global::WatchWinform.Properties.Resources.export;
            this.btn_save.Location = new System.Drawing.Point(946, 25);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(107, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Export";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_selectedList
            // 
            this.btn_selectedList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectedList.AutoSize = true;
            this.btn_selectedList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_selectedList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_selectedList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectedList.Image = global::WatchWinform.Properties.Resources.check;
            this.btn_selectedList.Location = new System.Drawing.Point(237, 33);
            this.btn_selectedList.Name = "btn_selectedList";
            this.btn_selectedList.Padding = new System.Windows.Forms.Padding(3);
            this.btn_selectedList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_selectedList.Size = new System.Drawing.Size(166, 34);
            this.btn_selectedList.TabIndex = 5;
            this.btn_selectedList.Text = "Selected Product";
            this.btn_selectedList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_selectedList.UseVisualStyleBackColor = false;
            this.btn_selectedList.Click += new System.EventHandler(this.btn_selected_Click);
            // 
            // btn_productList
            // 
            this.btn_productList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_productList.AutoSize = true;
            this.btn_productList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_productList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_productList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_productList.Image = global::WatchWinform.Properties.Resources.arrow;
            this.btn_productList.Location = new System.Drawing.Point(110, 33);
            this.btn_productList.Name = "btn_productList";
            this.btn_productList.Padding = new System.Windows.Forms.Padding(3);
            this.btn_productList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_productList.Size = new System.Drawing.Size(121, 34);
            this.btn_productList.TabIndex = 5;
            this.btn_productList.Text = "Product List";
            this.btn_productList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_productList.UseVisualStyleBackColor = false;
            this.btn_productList.Click += new System.EventHandler(this.btn_backList_Click);
            // 
            // ExportLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.pnl_footer);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1100, 769);
            this.MinimumSize = new System.Drawing.Size(1100, 769);
            this.Name = "ExportLayout";
            this.Size = new System.Drawing.Size(1100, 769);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanelHeader.ResumeLayout(false);
            this.flowLayoutPanelHeader.PerformLayout();
            this.pnl_footer.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label title_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHeader;
        private System.Windows.Forms.Button btn_productList;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button btn_selectedList;
        private System.Windows.Forms.Panel pnl_main;
        public System.Windows.Forms.FlowLayoutPanel list_product_layout;
    }
}
