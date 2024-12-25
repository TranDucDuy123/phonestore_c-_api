namespace WatchWinform.Gui.Component.ExportCom
{
    partial class ComponentExport
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.item_code = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.Label();
            this.item_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.item_brand = new System.Windows.Forms.Label();
            this.item_quantity = new System.Windows.Forms.Label();
            this.item_img = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btn_delete);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(967, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(103, 107);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.item_code);
            this.panel1.Controls.Add(this.item_price);
            this.panel1.Controls.Add(this.item_img);
            this.panel1.Controls.Add(this.item_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 107);
            this.panel1.TabIndex = 7;
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_code.Location = new System.Drawing.Point(122, 5);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(493, 26);
            this.item_code.TabIndex = 9;
            this.item_code.Text = "item_code";
            this.item_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_price
            // 
            this.item_price.AutoSize = true;
            this.item_price.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_price.ForeColor = System.Drawing.Color.Red;
            this.item_price.Location = new System.Drawing.Point(122, 31);
            this.item_price.Name = "item_price";
            this.item_price.Size = new System.Drawing.Size(97, 21);
            this.item_price.TabIndex = 8;
            this.item_price.Text = "item_price";
            // 
            // item_title
            // 
            this.item_title.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_title.Location = new System.Drawing.Point(126, 60);
            this.item_title.Name = "item_title";
            this.item_title.Size = new System.Drawing.Size(489, 43);
            this.item_title.TabIndex = 6;
            this.item_title.Text = "item_title";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.item_brand);
            this.panel2.Controls.Add(this.item_quantity);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(634, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 107);
            this.panel2.TabIndex = 8;
            // 
            // item_brand
            // 
            this.item_brand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_brand.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_brand.Location = new System.Drawing.Point(43, 5);
            this.item_brand.Name = "item_brand";
            this.item_brand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.item_brand.Size = new System.Drawing.Size(284, 26);
            this.item_brand.TabIndex = 7;
            this.item_brand.Text = "item_brand";
            this.item_brand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // item_quantity
            // 
            this.item_quantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_quantity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_quantity.Location = new System.Drawing.Point(39, 60);
            this.item_quantity.Name = "item_quantity";
            this.item_quantity.Size = new System.Drawing.Size(288, 31);
            this.item_quantity.TabIndex = 6;
            this.item_quantity.Text = "item_quantity";
            this.item_quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // item_img
            // 
            this.item_img.BackColor = System.Drawing.Color.AntiqueWhite;
            this.item_img.ErrorImage = null;
            this.item_img.Image = global::WatchWinform.Properties.Resources._default;
            this.item_img.InitialImage = null;
            this.item_img.Location = new System.Drawing.Point(3, 3);
            this.item_img.Name = "item_img";
            this.item_img.Size = new System.Drawing.Size(100, 100);
            this.item_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item_img.TabIndex = 7;
            this.item_img.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_delete.BackgroundImage = global::WatchWinform.Properties.Resources.plus;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(25, 23);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(44, 41);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // ComponentExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ComponentExport";
            this.Size = new System.Drawing.Size(1070, 107);
            this.Load += new System.EventHandler(this.ComponentExport_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_code;
        private System.Windows.Forms.Label item_price;
        private System.Windows.Forms.PictureBox item_img;
        private System.Windows.Forms.Label item_title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label item_brand;
        private System.Windows.Forms.Label item_quantity;
    }
}
