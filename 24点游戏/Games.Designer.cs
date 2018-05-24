namespace _24点游戏
{
    partial class Games
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.suiji = new System.Windows.Forms.Button();
            this.Input = new System.Windows.Forms.TextBox();
            this.Queding = new System.Windows.Forms.Button();
            this.jia = new System.Windows.Forms.Label();
            this.jian = new System.Windows.Forms.Label();
            this.cheng = new System.Windows.Forms.Label();
            this.chu = new System.Windows.Forms.Label();
            this.qiankuohao = new System.Windows.Forms.Label();
            this.fankuohao = new System.Windows.Forms.Label();
            this.wujie = new System.Windows.Forms.Label();
            this.mi = new System.Windows.Forms.Label();
            this.inputclera = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.s_time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // suiji
            // 
            this.suiji.Enabled = false;
            this.suiji.Font = new System.Drawing.Font("宋体", 15F);
            this.suiji.Location = new System.Drawing.Point(19, 346);
            this.suiji.Name = "suiji";
            this.suiji.Size = new System.Drawing.Size(74, 31);
            this.suiji.TabIndex = 0;
            this.suiji.Text = "随机";
            this.suiji.UseVisualStyleBackColor = true;
            this.suiji.Click += new System.EventHandler(this.suiji_Click);
            // 
            // Input
            // 
            this.Input.Font = new System.Drawing.Font("宋体", 15F);
            this.Input.Location = new System.Drawing.Point(12, 383);
            this.Input.Name = "Input";
            this.Input.ReadOnly = true;
            this.Input.Size = new System.Drawing.Size(344, 30);
            this.Input.TabIndex = 5;
            // 
            // Queding
            // 
            this.Queding.Enabled = false;
            this.Queding.Font = new System.Drawing.Font("宋体", 15F);
            this.Queding.Location = new System.Drawing.Point(382, 381);
            this.Queding.Name = "Queding";
            this.Queding.Size = new System.Drawing.Size(83, 30);
            this.Queding.TabIndex = 6;
            this.Queding.Text = "确定";
            this.Queding.UseVisualStyleBackColor = true;
            this.Queding.Click += new System.EventHandler(this.Queding_Click);
            // 
            // jia
            // 
            this.jia.AutoSize = true;
            this.jia.BackColor = System.Drawing.SystemColors.Control;
            this.jia.Font = new System.Drawing.Font("宋体", 30F);
            this.jia.ForeColor = System.Drawing.Color.Black;
            this.jia.Location = new System.Drawing.Point(31, 152);
            this.jia.Name = "jia";
            this.jia.Size = new System.Drawing.Size(37, 40);
            this.jia.TabIndex = 7;
            this.jia.Text = "+";
            this.jia.Click += new System.EventHandler(this.jia_Click);
            // 
            // jian
            // 
            this.jian.AutoSize = true;
            this.jian.BackColor = System.Drawing.Color.Transparent;
            this.jian.Font = new System.Drawing.Font("宋体", 30F);
            this.jian.ForeColor = System.Drawing.Color.Black;
            this.jian.Location = new System.Drawing.Point(160, 152);
            this.jian.Name = "jian";
            this.jian.Size = new System.Drawing.Size(37, 40);
            this.jian.TabIndex = 8;
            this.jian.Text = "-";
            this.jian.Click += new System.EventHandler(this.jian_Click);
            // 
            // cheng
            // 
            this.cheng.AutoSize = true;
            this.cheng.BackColor = System.Drawing.Color.Transparent;
            this.cheng.Font = new System.Drawing.Font("宋体", 30F);
            this.cheng.ForeColor = System.Drawing.Color.Black;
            this.cheng.Location = new System.Drawing.Point(295, 152);
            this.cheng.Name = "cheng";
            this.cheng.Size = new System.Drawing.Size(37, 40);
            this.cheng.TabIndex = 9;
            this.cheng.Text = "*";
            this.cheng.Click += new System.EventHandler(this.cheng_Click);
            // 
            // chu
            // 
            this.chu.AutoSize = true;
            this.chu.BackColor = System.Drawing.Color.Transparent;
            this.chu.Font = new System.Drawing.Font("宋体", 30F);
            this.chu.ForeColor = System.Drawing.Color.Black;
            this.chu.Location = new System.Drawing.Point(408, 152);
            this.chu.Name = "chu";
            this.chu.Size = new System.Drawing.Size(37, 40);
            this.chu.TabIndex = 10;
            this.chu.Text = "/";
            this.chu.Click += new System.EventHandler(this.chu_Click);
            // 
            // qiankuohao
            // 
            this.qiankuohao.AutoSize = true;
            this.qiankuohao.BackColor = System.Drawing.Color.Transparent;
            this.qiankuohao.Font = new System.Drawing.Font("宋体", 30F);
            this.qiankuohao.ForeColor = System.Drawing.Color.Black;
            this.qiankuohao.Location = new System.Drawing.Point(151, 250);
            this.qiankuohao.Name = "qiankuohao";
            this.qiankuohao.Size = new System.Drawing.Size(37, 40);
            this.qiankuohao.TabIndex = 11;
            this.qiankuohao.Text = "(";
            this.qiankuohao.Click += new System.EventHandler(this.qiankuohao_Click);
            // 
            // fankuohao
            // 
            this.fankuohao.AutoSize = true;
            this.fankuohao.BackColor = System.Drawing.Color.Transparent;
            this.fankuohao.Font = new System.Drawing.Font("宋体", 30F);
            this.fankuohao.ForeColor = System.Drawing.Color.Black;
            this.fankuohao.Location = new System.Drawing.Point(295, 250);
            this.fankuohao.Name = "fankuohao";
            this.fankuohao.Size = new System.Drawing.Size(37, 40);
            this.fankuohao.TabIndex = 12;
            this.fankuohao.Text = ")";
            this.fankuohao.Click += new System.EventHandler(this.fankuohao_Click);
            // 
            // wujie
            // 
            this.wujie.AutoSize = true;
            this.wujie.BackColor = System.Drawing.Color.Transparent;
            this.wujie.Font = new System.Drawing.Font("宋体", 30F);
            this.wujie.ForeColor = System.Drawing.Color.Black;
            this.wujie.Location = new System.Drawing.Point(408, 250);
            this.wujie.Name = "wujie";
            this.wujie.Size = new System.Drawing.Size(57, 40);
            this.wujie.TabIndex = 13;
            this.wujie.Text = "NO";
            this.wujie.Click += new System.EventHandler(this.wujie_Click);
            // 
            // mi
            // 
            this.mi.AutoSize = true;
            this.mi.BackColor = System.Drawing.Color.Transparent;
            this.mi.Font = new System.Drawing.Font("宋体", 30F);
            this.mi.ForeColor = System.Drawing.Color.Black;
            this.mi.Location = new System.Drawing.Point(31, 250);
            this.mi.Name = "mi";
            this.mi.Size = new System.Drawing.Size(37, 40);
            this.mi.TabIndex = 14;
            this.mi.Text = "^";
            this.mi.Click += new System.EventHandler(this.mi_Click);
            // 
            // inputclera
            // 
            this.inputclera.Font = new System.Drawing.Font("宋体", 15F);
            this.inputclera.Location = new System.Drawing.Point(123, 346);
            this.inputclera.Name = "inputclera";
            this.inputclera.Size = new System.Drawing.Size(74, 31);
            this.inputclera.TabIndex = 15;
            this.inputclera.Text = "清除";
            this.inputclera.UseVisualStyleBackColor = true;
            this.inputclera.Click += new System.EventHandler(this.inputclera_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.Font = new System.Drawing.Font("宋体", 15F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(493, 167);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 244);
            this.listBox1.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(489, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "当前耗时：";
            // 
            // s_time
            // 
            this.s_time.AutoSize = true;
            this.s_time.BackColor = System.Drawing.Color.Transparent;
            this.s_time.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.s_time.Location = new System.Drawing.Point(549, 106);
            this.s_time.Name = "s_time";
            this.s_time.Size = new System.Drawing.Size(20, 20);
            this.s_time.TabIndex = 18;
            this.s_time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(652, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "s";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Location = new System.Drawing.Point(390, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(93, 130);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "0";
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Location = new System.Drawing.Point(270, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(93, 130);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "0";
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(137, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "0";
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "0";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 425);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.s_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.inputclera);
            this.Controls.Add(this.mi);
            this.Controls.Add(this.wujie);
            this.Controls.Add(this.fankuohao);
            this.Controls.Add(this.qiankuohao);
            this.Controls.Add(this.chu);
            this.Controls.Add(this.cheng);
            this.Controls.Add(this.jian);
            this.Controls.Add(this.jia);
            this.Controls.Add(this.Queding);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.suiji);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Games";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Games_FormClosed);
            this.Load += new System.EventHandler(this.Games_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button suiji;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Button Queding;
        private System.Windows.Forms.Label jia;
        private System.Windows.Forms.Label jian;
        private System.Windows.Forms.Label cheng;
        private System.Windows.Forms.Label chu;
        private System.Windows.Forms.Label qiankuohao;
        private System.Windows.Forms.Label fankuohao;
        private System.Windows.Forms.Label wujie;
        private System.Windows.Forms.Label mi;
        private System.Windows.Forms.Button inputclera;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label s_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

