using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24点游戏
{
    public partial class Changepw : Form
    {
        public Changepw()
        {
            InitializeComponent();
        }

        public bool xiugaileme = false;

        private void fclose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void queding_Click(object sender, EventArgs e)
        {
            byte[] b = Encoding.Unicode.GetBytes(textBox1.Text + "|修改密码|" + textBox2.Text + "|" + textBox3.Text);
            Common.sendStream.Write(b, 0, b.Length);
            Dispose();
        }
    }
}
