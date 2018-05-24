using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24点游戏
{
    public partial class UserEnter : Form
    {
        public UserEnter()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            Common.chat = new Chatting();
            byte[] b = Encoding.Unicode.GetBytes(userinput.Text + "|登录大厅|" + passinput.Text);
            Common.sendStream.Write(b, 0, b.Length);
            Thread.Sleep(1000);
            if (Common.enterleme)
            {
                Common.username = userinput.Text;
                Visible = false;
                Common.chat.ShowDialog();
                Common.client.Client.Close();
                Environment.Exit(0);
                Dispose();
            }
        }

        private void newuser_Click(object sender, EventArgs e)
        {
            Common.nuser = new Newuser();
            Common.nuser.ShowDialog();
        }

        private void changep_Click(object sender, EventArgs e)
        {
            Common.chpw = new Changepw();
            Common.chpw.ShowDialog();
        }

        private void UserEnter_Load(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse("101.132.110.155");
                Common.client = new TcpClient();
                Common.client.Connect(ip, int.Parse("8000"));
                //获取用于发送数据的传输流
                Common.sendStream = Common.client.GetStream();
                Thread thread = new Thread(Common.ListenerServer);
                thread.Start();
            }
            catch
            {
                MessageBox.Show("服务器大概是在维护呢");
                Environment.Exit(0);
            }
        }

        private void UserEnter_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Common.client.Connected)
                Common.client.Client.Close();
            Environment.Exit(0);
        }
    }
}
