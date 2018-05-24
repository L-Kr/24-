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
    public partial class Newuser : Form
    {
        public Newuser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)

        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("请输入需要注册的用户名");
                return;
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("请输入需要注册的密码");
                return;
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码输入不相同");
                return;
            }
            else
            {                
                byte[] b = Encoding.Unicode.GetBytes(textBox1.Text + "|注册用户|" + textBox2.Text);
                Common.sendStream.Write(b, 0, b.Length);
            }
            Dispose();
        }
    }
}
