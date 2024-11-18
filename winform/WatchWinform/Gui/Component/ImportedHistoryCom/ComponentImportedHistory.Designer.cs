namespace WatchWinform.Gui.Component.ImportedHistoryCom
{
    partial class ComponentImportedHistory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.item_transport = new System.Windows.Forms.Label();
            this.item_provider = new System.Windows.Forms.Label();
            this.item_total = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.item_createUser = new System.Windows.Forms.Label();
            this.item_createdAt = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.item_img = new System.Windows.Forms.PictureBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.flowLayoutAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutAction
            // 
            this.flowLayoutAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutAction.Controls.Add(this.btn_edit);
            this.flowLayoutAction.Controls.Add(this.btn_delete);
            this.flowLayoutAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutAction.Location = new System.Drawing.Point(967, 0);
            this.flowLayoutAction.Name = "flowLayoutAction";
            this.flowLayoutAction.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.flowLayoutAction.Size = new System.Drawing.Size(103, 107);
            this.flowLayoutAction.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.item_transport);
            this.panel1.Controls.Add(this.item_provider);
            this.panel1.Controls.Add(this.item_total);
            this.panel1.Controls.Add(this.item_img);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 107);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total";
            // 
            // item_transport
            // 
            this.item_transport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_transport.Location = new System.Drawing.Point(122, 75);
            this.item_transport.Name = "item_transport";
            this.item_transport.Size = new System.Drawing.Size(341, 26);
            this.item_transport.TabIndex = 9;
            this.item_transport.Text = "Transport";
            this.item_transport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_provider
            // 
            this.item_provider.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_provider.Location = new System.Drawing.Point(122, 40);
            this.item_provider.Name = "item_provider";
            this.item_provider.Size = new System.Drawing.Size(341, 26);
            this.item_provider.TabIndex = 9;
            this.item_provider.Text = "Provider";
            this.item_provider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_total
            // 
            this.item_total.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_total.Location = new System.Drawing.Point(208, 5);
            this.item_total.Name = "item_total";
            this.item_total.Size = new System.Drawing.Size(407, 26);
            this.item_total.TabIndex = 9;
            this.item_total.Text = "Total";
            this.item_total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.item_createUser);
            this.panel2.Controls.Add(this.item_createdAt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(684, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 107);
            this.panel2.TabIndex = 8;
            // 
            // item_createUser
            // 
            this.item_createUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_createUser.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_createUser.Location = new System.Drawing.Point(25, 63);
            this.item_createUser.Name = "item_createUser";
            this.item_createUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.item_createUser.Size = new System.Drawing.Size(252, 26);
            this.item_createUser.TabIndex = 7;
            this.item_createUser.Text = "item_user";
            this.item_createUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // item_createdAt
            // 
            this.item_createdAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_createdAt.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_createdAt.Location = new System.Drawing.Point(25, 16);
            this.item_createdAt.Name = "item_createdAt";
            this.item_createdAt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.item_createdAt.Size = new System.Drawing.Size(252, 26);
            this.item_createdAt.TabIndex = 7;
            this.item_createdAt.Text = "item_date";
            this.item_createdAt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // item_img
            // 
            this.item_img.BackColor = System.Drawing.Color.AntiqueWhite;
            this.item_img.ErrorImage = null;
            this.item_img.Image = global::WatchWinform.Properties.Resources.import__2_;
            this.item_img.InitialImage = null;
            this.item_img.Location = new System.Drawing.Point(3, 3);
            this.item_img.Name = "item_img";
            this.item_img.Padding = new System.Windows.Forms.Padding(10);
            this.item_img.Size = new System.Drawing.Size(100, 100);
            this.item_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item_img.TabIndex = 7;
            this.item_img.TabStop = false;
            this.item_img.MouseLeave += new System.EventHandler(this.item_img_MouseLeave);
            this.item_img.MouseHover += new System.EventHandler(this.item_img_MouseHover);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Yellow;
            this.btn_edit.BackgroundImage = global::WatchWinform.Properties.Resources.edit;
            this.btn_edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Location = new System.Drawing.Point(3, 23);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(42, 41);
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
            this.btn_delete.Location = new System.Drawing.Point(51, 23);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(44, 41);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // ComponentImportedHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutAction);
            this.MaximumSize = new System.Drawing.Size(1070, 107);
            this.MinimumSize = new System.Drawing.Size(1070, 107);
            this.Name = "ComponentImportedHistory";
            this.Size = new System.Drawing.Size(1070, 107);
            this.Load += new System.EventHandler(this.ComponentImportedHistory_Load);
            this.flowLayoutAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutAction;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_total;
        private System.Windows.Forms.PictureBox item_img;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label item_createdAt;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label item_transport;
        private System.Windows.Forms.Label item_provider;
        private System.Windows.Forms.Label item_createUser;
    }
}
