namespace WatchWinform.Gui.Component.ExportedHistoryCom
{
    partial class EditLayout
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
            this.pnl_main = new System.Windows.Forms.Panel();
            this.list_product_layout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.total_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.product_layout = new System.Windows.Forms.Panel();
            this.customer_cbb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.panel3.SuspendLayout();
            this.product_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnl_main);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.product_layout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 648);
            this.panel1.TabIndex = 8;
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.list_product_layout);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 111);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1095, 457);
            this.pnl_main.TabIndex = 8;
            // 
            // list_product_layout
            // 
            this.list_product_layout.AutoScroll = true;
            this.list_product_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_product_layout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.list_product_layout.Location = new System.Drawing.Point(0, 0);
            this.list_product_layout.Name = "list_product_layout";
            this.list_product_layout.Size = new System.Drawing.Size(1095, 457);
            this.list_product_layout.TabIndex = 1;
            this.list_product_layout.WrapContents = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.total_lb);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btn_exit);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 568);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1095, 80);
            this.panel3.TabIndex = 7;
            // 
            // total_lb
            // 
            this.total_lb.AutoSize = true;
            this.total_lb.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_lb.Location = new System.Drawing.Point(130, 33);
            this.total_lb.Name = "total_lb";
            this.total_lb.Size = new System.Drawing.Size(40, 18);
            this.total_lb.TabIndex = 5;
            this.total_lb.Text = "total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Image = global::WatchWinform.Properties.Resources.reject;
            this.btn_exit.Location = new System.Drawing.Point(837, 26);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(107, 30);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Cancel";
            this.btn_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_save.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = global::WatchWinform.Properties.Resources.save;
            this.btn_save.Location = new System.Drawing.Point(950, 26);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(107, 30);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // product_layout
            // 
            this.product_layout.Controls.Add(this.customer_cbb);
            this.product_layout.Controls.Add(this.label6);
            this.product_layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.product_layout.Location = new System.Drawing.Point(0, 0);
            this.product_layout.Name = "product_layout";
            this.product_layout.Size = new System.Drawing.Size(1095, 111);
            this.product_layout.TabIndex = 6;
            // 
            // customer_cbb
            // 
            this.customer_cbb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_cbb.FormattingEnabled = true;
            this.customer_cbb.Location = new System.Drawing.Point(414, 49);
            this.customer_cbb.Name = "customer_cbb";
            this.customer_cbb.Size = new System.Drawing.Size(325, 25);
            this.customer_cbb.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(304, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Khách hàng";
            // 
            // EditLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1095, 648);
            this.MinimumSize = new System.Drawing.Size(1095, 648);
            this.Name = "EditLayout";
            this.Size = new System.Drawing.Size(1095, 648);
            this.Load += new System.EventHandler(this.EditLayout_LoadAsync);
            this.panel1.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.product_layout.ResumeLayout(false);
            this.product_layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_main;
        public System.Windows.Forms.FlowLayoutPanel list_product_layout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label total_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel product_layout;
        private System.Windows.Forms.ComboBox customer_cbb;
        private System.Windows.Forms.Label label6;
    }
}
