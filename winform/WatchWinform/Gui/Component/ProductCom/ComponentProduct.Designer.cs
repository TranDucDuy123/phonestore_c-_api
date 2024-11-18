namespace WatchWinform.Gui.Component.ProductCom
{
    partial class ComponentProduct
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.item_code = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.Label();
            this.item_img = new System.Windows.Forms.PictureBox();
            this.item_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.item_brand = new System.Windows.Forms.Label();
            this.item_quantity = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutAction.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutAction
            // 
            this.flowLayoutAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutAction.Controls.Add(this.btn_edit);
            this.flowLayoutAction.Controls.Add(this.btn_delete);
            this.flowLayoutAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutAction.Location = new System.Drawing.Point(724, 0);
            this.flowLayoutAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutAction.Name = "flowLayoutAction";
            this.flowLayoutAction.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.flowLayoutAction.Size = new System.Drawing.Size(78, 87);
            this.flowLayoutAction.TabIndex = 6;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Yellow;
            this.btn_edit.BackgroundImage = global::WatchWinform.Properties.Resources.edit;
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Location = new System.Drawing.Point(2, 18);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(32, 33);
            this.btn_edit.TabIndex = 0;
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_delete.BackgroundImage = global::WatchWinform.Properties.Resources.trash;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(38, 18);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(33, 33);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.item_code);
            this.panel1.Controls.Add(this.item_price);
            this.panel1.Controls.Add(this.item_img);
            this.panel1.Controls.Add(this.item_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 87);
            this.panel1.TabIndex = 7;
            // 
            // item_code
            // 
            this.item_code.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_code.Location = new System.Drawing.Point(92, 4);
            this.item_code.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_code.Name = "item_code";
            this.item_code.Size = new System.Drawing.Size(370, 21);
            this.item_code.TabIndex = 9;
            this.item_code.Text = "item_code";
            this.item_code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_price
            // 
            this.item_price.AutoSize = true;
            this.item_price.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_price.ForeColor = System.Drawing.Color.Red;
            this.item_price.Location = new System.Drawing.Point(92, 25);
            this.item_price.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_price.Name = "item_price";
            this.item_price.Size = new System.Drawing.Size(81, 19);
            this.item_price.TabIndex = 8;
            this.item_price.Text = "item_price";
            // 
            // item_img
            // 
            this.item_img.BackColor = System.Drawing.Color.AntiqueWhite;
            this.item_img.ErrorImage = null;
            this.item_img.Image = global::WatchWinform.Properties.Resources._default;
            this.item_img.InitialImage = null;
            this.item_img.Location = new System.Drawing.Point(2, 2);
            this.item_img.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.item_img.Name = "item_img";
            this.item_img.Size = new System.Drawing.Size(75, 81);
            this.item_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item_img.TabIndex = 7;
            this.item_img.TabStop = false;
            this.item_img.Click += new System.EventHandler(this.item_img_Click_1);
            this.item_img.MouseLeave += new System.EventHandler(this.item_img_MouseLeave);
            this.item_img.MouseHover += new System.EventHandler(this.item_img_MouseHover);
            // 
            // item_title
            // 
            this.item_title.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_title.Location = new System.Drawing.Point(94, 49);
            this.item_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_title.Name = "item_title";
            this.item_title.Size = new System.Drawing.Size(367, 35);
            this.item_title.TabIndex = 6;
            this.item_title.Text = "item_title";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.item_brand);
            this.panel2.Controls.Add(this.item_quantity);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(476, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 87);
            this.panel2.TabIndex = 8;
            // 
            // item_brand
            // 
            this.item_brand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_brand.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_brand.Location = new System.Drawing.Point(16, 4);
            this.item_brand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_brand.Name = "item_brand";
            this.item_brand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.item_brand.Size = new System.Drawing.Size(227, 21);
            this.item_brand.TabIndex = 7;
            this.item_brand.Text = "item_brand";
            this.item_brand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // item_quantity
            // 
            this.item_quantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_quantity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_quantity.Location = new System.Drawing.Point(19, 49);
            this.item_quantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_quantity.Name = "item_quantity";
            this.item_quantity.Size = new System.Drawing.Size(224, 25);
            this.item_quantity.TabIndex = 6;
            this.item_quantity.Text = "item_quantity";
            this.item_quantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ComponentProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutAction);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ComponentProduct";
            this.Size = new System.Drawing.Size(802, 87);
            this.Load += new System.EventHandler(this.ComponentProduct_Load);
            this.flowLayoutAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutAction;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_code;
        private System.Windows.Forms.Label item_price;
        private System.Windows.Forms.PictureBox item_img;
        private System.Windows.Forms.Label item_title;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label item_brand;
        private System.Windows.Forms.Label item_quantity;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
