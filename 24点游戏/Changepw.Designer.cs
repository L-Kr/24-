namespace _24点游戏
{
    partial class Changepw
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
            this.oldpassword = new System.Windows.Forms.Label();
            this.newpassword = new System.Windows.Forms.Label();
            this.queding = new System.Windows.Forms.Button();
            this.fclose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("宋体", 15F);
            this.username.Location = new System.Drawing.Point(12, 28);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(79, 20);
            this.username.TabIndex = 0;
            this.username.Text = "用户名:";
            // 
            // oldpassword
            // 
            this.oldpassword.AutoSize = true;
            this.oldpassword.Font = new System.Drawing.Font("宋体", 15F);
            this.oldpassword.Location = new System.Drawing.Point(12, 81);
            this.oldpassword.Name = "oldpassword";
            this.oldpassword.Size = new System.Drawing.Size(79, 20);
            this.oldpassword.TabIndex = 1;
            this.oldpassword.Text = "原密码:";
            // 
            // newpassword
            // 
            this.newpassword.AutoSize = true;
            this.newpassword.Font = new System.Drawing.Font("宋体", 15F);
            this.newpassword.Location = new System.Drawing.Point(12, 135);
            this.newpassword.Name = "newpassword";
            this.newpassword.Size = new System.Drawing.Size(79, 20);
            this.newpassword.TabIndex = 2;
            this.newpassword.Text = "新密码:";
            // 
            // queding
            // 
            this.queding.Font = new System.Drawing.Font("宋体", 15F);
            this.queding.Location = new System.Drawing.Point(178, 199);
            this.queding.Name = "queding";
            this.queding.Size = new System.Drawing.Size(70, 30);
            this.queding.TabIndex = 3;
            this.queding.Text = "确定";
            this.queding.UseVisualStyleBackColor = true;
            this.queding.Click += new System.EventHandler(this.queding_Click);
            // 
            // fclose
            // 
            this.fclose.Font = new System.Drawing.Font("宋体", 15F);
            this.fclose.Location = new System.Drawing.Point(21, 199);
            this.fclose.Name = "fclose";
            this.fclose.Size = new System.Drawing.Size(70, 30);
            this.fclose.TabIndex = 4;
            this.fclose.Text = "返回";
            this.fclose.UseVisualStyleBackColor = true;
            this.fclose.Click += new System.EventHandler(this.fclose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(110, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 26);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox2.Location = new System.Drawing.Point(110, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 26);
            this.textBox2.TabIndex = 6;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox3.Location = new System.Drawing.Point(110, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 26);
            this.textBox3.TabIndex = 7;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // Changepw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fclose);
            this.Controls.Add(this.queding);
            this.Controls.Add(this.newpassword);
            this.Controls.Add(this.oldpassword);
            this.Controls.Add(this.username);
            this.Name = "Changepw";
            this.Text = "Changepw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        public System.Windows.Forms.Label oldpassword;
        public System.Windows.Forms.Label newpassword;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Button queding;
        public System.Windows.Forms.Button fclose;
    }
}