namespace _24点游戏
{
    partial class Chatting
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
            this.components = new System.ComponentModel.Container();
            this.inform = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sendm = new System.Windows.Forms.Button();
            this.sendt = new System.Windows.Forms.TextBox();
            this.buildroom = new System.Windows.Forms.Button();
            this.joinroom = new System.Windows.Forms.Button();
            this.Welcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roomnumber = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flushdfb = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inform
            // 
            this.inform.BackColor = System.Drawing.SystemColors.Control;
            this.inform.Font = new System.Drawing.Font("宋体", 12F);
            this.inform.Location = new System.Drawing.Point(13, 59);
            this.inform.Multiline = true;
            this.inform.Name = "inform";
            this.inform.ReadOnly = true;
            this.inform.Size = new System.Drawing.Size(369, 218);
            this.inform.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(413, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(105, 204);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // sendm
            // 
            this.sendm.Font = new System.Drawing.Font("宋体", 15F);
            this.sendm.Location = new System.Drawing.Point(413, 284);
            this.sendm.Name = "sendm";
            this.sendm.Size = new System.Drawing.Size(105, 30);
            this.sendm.TabIndex = 3;
            this.sendm.Text = "私发消息";
            this.sendm.UseVisualStyleBackColor = true;
            this.sendm.Click += new System.EventHandler(this.sendm_Click);
            // 
            // sendt
            // 
            this.sendt.Font = new System.Drawing.Font("宋体", 15F);
            this.sendt.Location = new System.Drawing.Point(13, 284);
            this.sendt.Name = "sendt";
            this.sendt.Size = new System.Drawing.Size(369, 30);
            this.sendt.TabIndex = 4;
            // 
            // buildroom
            // 
            this.buildroom.BackColor = System.Drawing.SystemColors.Control;
            this.buildroom.Font = new System.Drawing.Font("宋体", 15F);
            this.buildroom.Location = new System.Drawing.Point(527, 59);
            this.buildroom.Name = "buildroom";
            this.buildroom.Size = new System.Drawing.Size(135, 35);
            this.buildroom.TabIndex = 5;
            this.buildroom.Text = "创建游戏";
            this.buildroom.UseVisualStyleBackColor = false;
            this.buildroom.Click += new System.EventHandler(this.buildroom_Click);
            // 
            // joinroom
            // 
            this.joinroom.Font = new System.Drawing.Font("宋体", 15F);
            this.joinroom.Location = new System.Drawing.Point(527, 228);
            this.joinroom.Name = "joinroom";
            this.joinroom.Size = new System.Drawing.Size(135, 33);
            this.joinroom.TabIndex = 6;
            this.joinroom.Text = "加入游戏";
            this.joinroom.UseVisualStyleBackColor = true;
            this.joinroom.Click += new System.EventHandler(this.joinroom_Click);
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.BackColor = System.Drawing.Color.Transparent;
            this.Welcome.Font = new System.Drawing.Font("宋体", 15F);
            this.Welcome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Welcome.Location = new System.Drawing.Point(111, 19);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(169, 20);
            this.Welcome.TabIndex = 7;
            this.Welcome.Text = "数据加载中 . . .";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(523, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "房号：";
            // 
            // roomnumber
            // 
            this.roomnumber.Font = new System.Drawing.Font("宋体", 15F);
            this.roomnumber.Location = new System.Drawing.Point(578, 153);
            this.roomnumber.Name = "roomnumber";
            this.roomnumber.Size = new System.Drawing.Size(84, 30);
            this.roomnumber.TabIndex = 9;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("宋体", 15F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(692, 59);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(245, 204);
            this.listBox2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(770, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "巅峰榜";
            // 
            // flushdfb
            // 
            this.flushdfb.Font = new System.Drawing.Font("宋体", 15F);
            this.flushdfb.Location = new System.Drawing.Point(819, 269);
            this.flushdfb.Name = "flushdfb";
            this.flushdfb.Size = new System.Drawing.Size(118, 45);
            this.flushdfb.TabIndex = 12;
            this.flushdfb.Text = "时间巅峰榜";
            this.flushdfb.UseVisualStyleBackColor = true;
            this.flushdfb.Click += new System.EventHandler(this.flushdfb_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15F);
            this.button1.Location = new System.Drawing.Point(692, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "积分巅峰榜";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(949, 334);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flushdfb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.roomnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Welcome);
            this.Controls.Add(this.joinroom);
            this.Controls.Add(this.buildroom);
            this.Controls.Add(this.sendt);
            this.Controls.Add(this.sendm);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.inform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Chatting";
            this.Text = "Chatting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chatting_FormClosed);
            this.Load += new System.EventHandler(this.Chatting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox inform;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button sendm;
        public System.Windows.Forms.TextBox sendt;
        public System.Windows.Forms.Button buildroom;
        public System.Windows.Forms.Button joinroom;
        public System.Windows.Forms.Label Welcome;
        public System.Windows.Forms.TextBox roomnumber;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button flushdfb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}