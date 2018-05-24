namespace _24点游戏
{
    partial class UserEnter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.userinput = new System.Windows.Forms.TextBox();
            this.passinput = new System.Windows.Forms.TextBox();
            this.newuser = new System.Windows.Forms.Button();
            this.changep = new System.Windows.Forms.Button();
            this.enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username.Location = new System.Drawing.Point(28, 25);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(120, 27);
            this.username.TabIndex = 0;
            this.username.Text = "用户名：";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("宋体", 20F);
            this.password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password.Location = new System.Drawing.Point(55, 83);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(93, 27);
            this.password.TabIndex = 1;
            this.password.Text = "密码：";
            // 
            // userinput
            // 
            this.userinput.Font = new System.Drawing.Font("宋体", 15F);
            this.userinput.Location = new System.Drawing.Point(149, 25);
            this.userinput.Name = "userinput";
            this.userinput.Size = new System.Drawing.Size(178, 30);
            this.userinput.TabIndex = 2;
            // 
            // passinput
            // 
            this.passinput.Font = new System.Drawing.Font("宋体", 15F);
            this.passinput.Location = new System.Drawing.Point(149, 83);
            this.passinput.Name = "passinput";
            this.passinput.Size = new System.Drawing.Size(178, 30);
            this.passinput.TabIndex = 3;
            this.passinput.UseSystemPasswordChar = true;
            // 
            // newuser
            // 
            this.newuser.BackColor = System.Drawing.SystemColors.Control;
            this.newuser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newuser.Font = new System.Drawing.Font("宋体", 20F);
            this.newuser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newuser.Location = new System.Drawing.Point(243, 141);
            this.newuser.Name = "newuser";
            this.newuser.Size = new System.Drawing.Size(76, 38);
            this.newuser.TabIndex = 5;
            this.newuser.Text = "注册";
            this.newuser.UseVisualStyleBackColor = false;
            this.newuser.Click += new System.EventHandler(this.newuser_Click);
            // 
            // changep
            // 
            this.changep.BackColor = System.Drawing.SystemColors.Control;
            this.changep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changep.Font = new System.Drawing.Font("宋体", 20F);
            this.changep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.changep.Location = new System.Drawing.Point(149, 141);
            this.changep.Name = "changep";
            this.changep.Size = new System.Drawing.Size(76, 38);
            this.changep.TabIndex = 6;
            this.changep.Text = "改密";
            this.changep.UseVisualStyleBackColor = false;
            this.changep.Click += new System.EventHandler(this.changep_Click);
            // 
            // enter
            // 
            this.enter.BackColor = System.Drawing.SystemColors.Control;
            this.enter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enter.Font = new System.Drawing.Font("宋体", 20F);
            this.enter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enter.Location = new System.Drawing.Point(45, 141);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(76, 38);
            this.enter.TabIndex = 4;
            this.enter.Text = "登录";
            this.enter.UseVisualStyleBackColor = false;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // UserEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(351, 197);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.changep);
            this.Controls.Add(this.newuser);
            this.Controls.Add(this.passinput);
            this.Controls.Add(this.userinput);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserEnter";
            this.Text = "UserEnter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserEnter_FormClosed);
            this.Load += new System.EventHandler(this.UserEnter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox userinput;
        private System.Windows.Forms.TextBox passinput;
        private System.Windows.Forms.Button newuser;
        private System.Windows.Forms.Button changep;
        private System.Windows.Forms.Button enter;
    }
}