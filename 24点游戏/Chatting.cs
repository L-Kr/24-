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
    public partial class Chatting : Form
    {
        public Chatting()
        {
            InitializeComponent();
        }

        Games myform;
        public int mnow = -1234567;   //如果积分发生变化则更新到数据库

        private void Chatting_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(Common.username);
        }

        //发送消息
        private void sendm_Click(object sender, EventArgs e)
        {
            if (Common.client != null)
            {
                //要发送的信息
                if (sendt.Text.Trim() == string.Empty)
                    return;
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("请在在线列表中选择接受者！");
                    return;
                }
                string msg = listBox1.SelectedItem.ToString() + "|" + sendt.Text.Trim();
                //将信息存入缓存中
                byte[] buffer = Encoding.Unicode.GetBytes(msg);
                //lock (sendStream)
                //{
                Common.sendStream.Write(buffer, 0, buffer.Length);
                //}
                inform.AppendText(string.Format("发送给{0}的数据:{1}\n", listBox1.SelectedItem.ToString(), sendt.Text.Trim()));
                sendt.Text = string.Empty;
            }
        }

        //关闭窗口释放资源
        private void Chatting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Common.client.Connected)
            {
                byte[] b = Encoding.Unicode.GetBytes(Common.username + "|退出游戏|0");
                Common.sendStream.Write(b, 0, b.Length);
                Thread.Sleep(100);   //避免消息送达前就断开连接了话说0.1秒缓冲应该够了吧
            }
            Common.client.Client.Close();
            Environment.Exit(0);
        }

        private void buildroom_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1024];
            buffer = Encoding.Unicode.GetBytes(Common.username + "|创建游戏");
            Common.sendStream.Write(buffer, 0, buffer.Length);
            myform = new Games(true);
            myform.Show();
            Common.flag = false;
            buildroom.Enabled = false;
            joinroom.Enabled = false;
        }

        private void joinroom_Click(object sender, EventArgs e)
        {
            if (roomnumber.TextLength == 0)
            {
                MessageBox.Show("请输入房间号");
                return;
            }
            byte[] buffer = new byte[8000];
            buffer = Encoding.Unicode.GetBytes(Common.username + "|" + "加入游戏" + "|" + roomnumber.Text);
            Common.sendStream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
            if (Common.mesg != "系统通知|该用户未创建游戏")
            {
                myform = new Games(false);
                myform.Show();
                Common.flag = false;
                buildroom.Enabled = false;
                joinroom.Enabled = false; 
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
                roomnumber.Text = listBox1.SelectedItem.ToString();
        }

        private void flushdfb_Click(object sender, EventArgs e)
        {
            byte[] a = Encoding.Unicode.GetBytes(Common.username + "|更新时间巅峰榜");
            Common.sendStream.Write(a, 0, a.Length);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Common.money != mnow)
            {
                Welcome.Text = string.Format("亲爱的{0},您当前积分为：{1},祝您游戏愉快！", Common.username, Common.money);
                byte[] b = Encoding.Unicode.GetBytes(Common.username + "|更新积分|" + Common.money);
                Common.sendStream.Write(b, 0, b.Length);
                mnow = Common.money;
            }
            if (Common.flag)
            {
                buildroom.Enabled = true;
                joinroom.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] a = Encoding.Unicode.GetBytes(Common.username + "|更新积分巅峰榜");
            Common.sendStream.Write(a, 0, a.Length);
        }
    }
}
