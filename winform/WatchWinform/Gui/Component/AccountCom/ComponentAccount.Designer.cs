namespace WatchWinform.Gui.Component.AccountCom
{
    partial class ComponentAccount
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
            this.item_role = new System.Windows.Forms.Label();
            this.item_username = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.Label();
            this.item_img = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.item_user = new System.Windows.Forms.Label();
            this.item_date = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.panel1.Controls.Add(this.item_role);
            this.panel1.Controls.Add(this.item_username);
            this.panel1.Controls.Add(this.item_name);
            this.panel1.Controls.Add(this.item_img);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 87);
            this.panel1.TabIndex = 7;
            // 
            // item_role
            // 
            this.item_role.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_role.Location = new System.Drawing.Point(92, 58);
            this.item_role.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_role.Name = "item_role";
            this.item_role.Size = new System.Drawing.Size(370, 21);
            this.item_role.TabIndex = 9;
            this.item_role.Text = "item_role";
            this.item_role.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_username
            // 
            this.item_username.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_username.Location = new System.Drawing.Point(92, 32);
            this.item_username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_username.Name = "item_username";
            this.item_username.Size = new System.Drawing.Size(370, 21);
            this.item_username.TabIndex = 9;
            this.item_username.Text = "item_username";
            this.item_username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(92, 4);
            this.item_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(370, 21);
            this.item_name.TabIndex = 9;
            this.item_name.Text = "item_name";
            this.item_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_img
            // 
            this.item_img.BackColor = System.Drawing.Color.AntiqueWhite;
            this.item_img.ErrorImage = null;
            this.item_img.Image = global::WatchWinform.Properties.Resources.user__1_;
            this.item_img.InitialImage = null;
            this.item_img.Location = new System.Drawing.Point(2, 2);
            this.item_img.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.item_img.Name = "item_img";
            this.item_img.Size = new System.Drawing.Size(75, 81);
            this.item_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item_img.TabIndex = 7;
            this.item_img.TabStop = false;
            this.item_img.MouseLeave += new System.EventHandler(this.item_img_MouseLeave);
            this.item_img.MouseHover += new System.EventHandler(this.item_img_MouseHover);
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
            // item_user
            // 
            this.item_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_user.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_user.Location = new System.Drawing.Point(6, 49);
            this.item_user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_user.Name = "item_user";
            this.item_user.Size = new System.Drawing.Size(238, 25);
            this.item_user.TabIndex = 6;
            this.item_user.Text = "item_user";
            this.item_user.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // item_date
            // 
            this.item_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.item_date.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_date.Location = new System.Drawing.Point(2, 4);
            this.item_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.item_date.Name = "item_date";
            this.item_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.item_date.Size = new System.Drawing.Size(241, 21);
            this.item_date.TabIndex = 7;
            this.item_date.Text = "Date Created";
            this.item_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.item_date);
            this.panel2.Controls.Add(this.item_user);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(476, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 87);
            this.panel2.TabIndex = 8;
            // 
            // ComponentAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutAction);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ComponentAccount";
            this.Size = new System.Drawing.Size(802, 87);
            this.Load += new System.EventHandler(this.ComponentAccount_Load);
            this.flowLayoutAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.item_img)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutAction;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label item_name;
        private System.Windows.Forms.PictureBox item_img;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label item_user;
        private System.Windows.Forms.Label item_date;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label item_username;
        private System.Windows.Forms.Label item_role;
    }
}
