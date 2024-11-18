namespace WatchWinform.Gui.Component.ProductCom
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
            this.product_layout = new System.Windows.Forms.Panel();
            this.upload_btn = new System.Windows.Forms.Button();
            this.brand_cbb = new System.Windows.Forms.ComboBox();
            this.cat_cbb = new System.Windows.Forms.ComboBox();
            this.quantity_num = new System.Windows.Forms.NumericUpDown();
            this.image_pic = new System.Windows.Forms.PictureBox();
            this.active_cb = new System.Windows.Forms.CheckBox();
            this.description_rtb = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.code_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.discount_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.color_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.price_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.product_layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_pic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // product_layout
            // 
            this.product_layout.Controls.Add(this.upload_btn);
            this.product_layout.Controls.Add(this.brand_cbb);
            this.product_layout.Controls.Add(this.cat_cbb);
            this.product_layout.Controls.Add(this.quantity_num);
            this.product_layout.Controls.Add(this.image_pic);
            this.product_layout.Controls.Add(this.active_cb);
            this.product_layout.Controls.Add(this.description_rtb);
            this.product_layout.Controls.Add(this.label7);
            this.product_layout.Controls.Add(this.code_txt);
            this.product_layout.Controls.Add(this.label2);
            this.product_layout.Controls.Add(this.discount_txt);
            this.product_layout.Controls.Add(this.label5);
            this.product_layout.Controls.Add(this.label11);
            this.product_layout.Controls.Add(this.color_txt);
            this.product_layout.Controls.Add(this.label9);
            this.product_layout.Controls.Add(this.label4);
            this.product_layout.Controls.Add(this.price_txt);
            this.product_layout.Controls.Add(this.label3);
            this.product_layout.Controls.Add(this.label8);
            this.product_layout.Controls.Add(this.label6);
            this.product_layout.Controls.Add(this.name_txt);
            this.product_layout.Controls.Add(this.label1);
            this.product_layout.Location = new System.Drawing.Point(0, 0);
            this.product_layout.Name = "product_layout";
            this.product_layout.Size = new System.Drawing.Size(1100, 562);
            this.product_layout.TabIndex = 0;
            // 
            // upload_btn
            // 
            this.upload_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upload_btn.BackgroundImage = global::WatchWinform.Properties.Resources.upload;
            this.upload_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upload_btn.Location = new System.Drawing.Point(985, 452);
            this.upload_btn.Name = "upload_btn";
            this.upload_btn.Size = new System.Drawing.Size(38, 34);
            this.upload_btn.TabIndex = 9;
            this.upload_btn.UseVisualStyleBackColor = true;
            this.upload_btn.Click += new System.EventHandler(this.upload_btn_Click);
            // 
            // brand_cbb
            // 
            this.brand_cbb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brand_cbb.FormattingEnabled = true;
            this.brand_cbb.Location = new System.Drawing.Point(677, 207);
            this.brand_cbb.Name = "brand_cbb";
            this.brand_cbb.Size = new System.Drawing.Size(357, 25);
            this.brand_cbb.TabIndex = 8;
            // 
            // cat_cbb
            // 
            this.cat_cbb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cat_cbb.FormattingEnabled = true;
            this.cat_cbb.Location = new System.Drawing.Point(166, 207);
            this.cat_cbb.Name = "cat_cbb";
            this.cat_cbb.Size = new System.Drawing.Size(357, 25);
            this.cat_cbb.TabIndex = 7;
            // 
            // quantity_num
            // 
            this.quantity_num.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity_num.Location = new System.Drawing.Point(545, 145);
            this.quantity_num.Name = "quantity_num";
            this.quantity_num.Size = new System.Drawing.Size(120, 23);
            this.quantity_num.TabIndex = 6;
            // 
            // image_pic
            // 
            this.image_pic.ErrorImage = global::WatchWinform.Properties.Resources._default;
            this.image_pic.Image = global::WatchWinform.Properties.Resources._default;
            this.image_pic.Location = new System.Drawing.Point(794, 271);
            this.image_pic.Name = "image_pic";
            this.image_pic.Size = new System.Drawing.Size(240, 223);
            this.image_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_pic.TabIndex = 5;
            this.image_pic.TabStop = false;
            this.image_pic.WaitOnLoad = true;
            // 
            // active_cb
            // 
            this.active_cb.AutoSize = true;
            this.active_cb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.active_cb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.active_cb.Location = new System.Drawing.Point(497, 271);
            this.active_cb.Name = "active_cb";
            this.active_cb.Size = new System.Drawing.Size(80, 21);
            this.active_cb.TabIndex = 4;
            this.active_cb.Text = "Hiệu lực";
            this.active_cb.UseVisualStyleBackColor = true;
            // 
            // description_rtb
            // 
            this.description_rtb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_rtb.Location = new System.Drawing.Point(166, 328);
            this.description_rtb.Name = "description_rtb";
            this.description_rtb.Size = new System.Drawing.Size(582, 167);
            this.description_rtb.TabIndex = 3;
            this.description_rtb.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(572, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Thương hiệu";
            // 
            // code_txt
            // 
            this.code_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_txt.Location = new System.Drawing.Point(665, 83);
            this.code_txt.Name = "code_txt";
            this.code_txt.Size = new System.Drawing.Size(369, 23);
            this.code_txt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(572, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // discount_txt
            // 
            this.discount_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount_txt.Location = new System.Drawing.Point(779, 145);
            this.discount_txt.Name = "discount_txt";
            this.discount_txt.Size = new System.Drawing.Size(255, 23);
            this.discount_txt.TabIndex = 2;
            this.discount_txt.TextChanged += new System.EventHandler(this.price_txt_TextChanged);
            this.discount_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_txt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giảm giá";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(689, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Hình ảnh";
            // 
            // color_txt
            // 
            this.color_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color_txt.Location = new System.Drawing.Point(166, 269);
            this.color_txt.Name = "color_txt";
            this.color_txt.Size = new System.Drawing.Size(267, 23);
            this.color_txt.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(67, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Màu sắc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượng";
            // 
            // price_txt
            // 
            this.price_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_txt.Location = new System.Drawing.Point(166, 145);
            this.price_txt.Name = "price_txt";
            this.price_txt.Size = new System.Drawing.Size(255, 23);
            this.price_txt.TabIndex = 2;
            this.price_txt.TextChanged += new System.EventHandler(this.price_txt_TextChanged);
            this.price_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giá";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mô tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Danh mục";
            // 
            // name_txt
            // 
            this.name_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_txt.Location = new System.Drawing.Point(166, 83);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(357, 23);
            this.name_txt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 80);
            this.panel1.TabIndex = 1;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Red;
            this.btn_exit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Image = global::WatchWinform.Properties.Resources.reject;
            this.btn_exit.Location = new System.Drawing.Point(833, 23);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(107, 30);
            this.btn_exit.TabIndex = 1;
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
            this.btn_save.Location = new System.Drawing.Point(946, 23);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(107, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // EditLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.product_layout);
            this.MaximumSize = new System.Drawing.Size(1095, 648);
            this.MinimumSize = new System.Drawing.Size(1095, 648);
            this.Name = "EditLayout";
            this.Size = new System.Drawing.Size(1095, 648);
            this.Load += new System.EventHandler(this.EditLayout_LoadAsync);
            this.product_layout.ResumeLayout(false);
            this.product_layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_pic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel product_layout;
        private System.Windows.Forms.TextBox code_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox discount_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox price_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox description_rtb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox color_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox image_pic;
        private System.Windows.Forms.CheckBox active_cb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox brand_cbb;
        private System.Windows.Forms.ComboBox cat_cbb;
        private System.Windows.Forms.NumericUpDown quantity_num;
        private System.Windows.Forms.Button upload_btn;
    }
}
