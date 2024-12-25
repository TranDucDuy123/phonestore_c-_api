namespace WatchWinform.Gui.Component.AccountCom
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
            this.account_layout = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.account_layout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // account_layout
            // 
            this.account_layout.Controls.Add(this.label2);
            this.account_layout.Controls.Add(this.username_txt);
            this.account_layout.Controls.Add(this.name_txt);
            this.account_layout.Controls.Add(this.label1);
            this.account_layout.Location = new System.Drawing.Point(0, 0);
            this.account_layout.Name = "account_layout";
            this.account_layout.Size = new System.Drawing.Size(1100, 562);
            this.account_layout.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName";
            // 
            // name_txt
            // 
            this.name_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_txt.Location = new System.Drawing.Point(169, 120);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(349, 23);
            this.name_txt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // username_txt
            // 
            this.username_txt.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txt.Location = new System.Drawing.Point(654, 120);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(349, 23);
            this.username_txt.TabIndex = 6;
            // 
            // EditLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.account_layout);
            this.MaximumSize = new System.Drawing.Size(1095, 648);
            this.MinimumSize = new System.Drawing.Size(1095, 648);
            this.Name = "EditLayout";
            this.Size = new System.Drawing.Size(1095, 648);
            this.Load += new System.EventHandler(this.EditLayout_LoadAsync);
            this.account_layout.ResumeLayout(false);
            this.account_layout.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel account_layout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_txt;
    }
}
