namespace WatchWinform.Gui.Component.ImportedHistoryCom
{
    partial class ComponentImportDetail
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
            this.item_code = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.Label();
            this.item_img = new System.Windows.Forms.PictureBox();
            this.item_title = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.priceIn_txt = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.quantity_num = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_num)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.item_code);
            this.panel1.Controls.Add(this.item_price);
            this.panel1.Controls.Add(this.item_img);
            this.panel1.Controls.Add(this.item_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 107);
            this.panel1.TabIndex = 7;
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_code.Location = new System.Drawing.Point(122, 5);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(566, 26);
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
            // item_title
            // 
            this.item_title.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_title.Location = new System.Drawing.Point(126, 60);
            this.item_title.Name = "item_title";
            this.item_title.Size = new System.Drawing.Size(489, 43);
            this.item_title.TabIndex = 6;
            this.item_title.Text = "item_title";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(736, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(334, 107);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.priceIn_txt);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(317, 47);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá nhập";
            // 
            // priceIn_txt
            // 
            this.priceIn_txt.Enabled = false;
            this.priceIn_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceIn_txt.Location = new System.Drawing.Point(87, 13);
            this.priceIn_txt.Name = "priceIn_txt";
            this.priceIn_txt.Size = new System.Drawing.Size(213, 23);
            this.priceIn_txt.TabIndex = 1;
            this.priceIn_txt.TextChanged += new System.EventHandler(this.priceIn_txt_TextChanged);
            this.priceIn_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceIn_txt_KeyPress);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.quantity_num);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 56);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(317, 46);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng";
            // 
            // quantity_num
            // 
            this.quantity_num.Enabled = false;
            this.quantity_num.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity_num.Location = new System.Drawing.Point(80, 13);
            this.quantity_num.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantity_num.Name = "quantity_num";
            this.quantity_num.Size = new System.Drawing.Size(220, 23);
            this.quantity_num.TabIndex = 1;
            // 
            // ComponentImportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1070, 107);
            this.MinimumSize = new System.Drawing.Size(1070, 107);
            this.Name = "ComponentImportDetail";
            this.Size = new System.Drawing.Size(1070, 107);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_code;
        private System.Windows.Forms.Label item_price;
        private System.Windows.Forms.PictureBox item_img;
        private System.Windows.Forms.Label item_title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox priceIn_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown quantity_num;
    }
}
