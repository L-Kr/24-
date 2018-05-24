using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace _24点游戏
{
    static class Common
    {
        static public Chatting chat;
        static public Newuser nuser;
        static public Changepw chpw;

        static public bool enterleme = false;  //登录成功与否的标记

        static public TcpClient client;
        static public int bufferSize = 8000;
        static public NetworkStream sendStream;
        static public string mesg;
        static public string username;
        static public int money;
        public struct Timeandname
        {
            public string name;   //用户名
            public string money;
            public string time;   //用时
        }
        static public Timeandname[] tandn = new Timeandname[10];  //记录前十名
        static public bool flag = false;   //在chatting窗体判断Games窗体是否退出

        /*监听服务器消息并统领全局*/
        static public void ListenerServer()
        {
            NetworkStream reciveStream = client.GetStream();
            do
            {
                try
                {
                    int readSize;
                    byte[] buffer = new byte[bufferSize];
                    lock (reciveStream)
                    {
                        readSize = reciveStream.Read(buffer, 0, bufferSize);
                    }
                    if (readSize == 0)
                        continue;
                    mesg = Encoding.Unicode.GetString(buffer, 0, readSize);
                    string[] message = mesg.Split('|');

                    if (message[0] == "登录成功")
                    {
                        enterleme = true;
                        money = Convert.ToInt32(message[1]);
                        MessageBox.Show("登录成功！\n您的当前积分为：" + money);
                        continue;
                    }

                    else if (mesg == "登录失败")
                    {
                        MessageBox.Show("登录失败！");
                        continue;
                    }

                    else if (mesg == "注册成功")
                    {
                        MessageBox.Show("注册成功！");
                        continue;
                    }

                    else if (mesg == "注册失败")
                    {
                        MessageBox.Show("注册失败！");
                        continue;
                    }

                    else if (mesg == "修改成功")
                    {
                        MessageBox.Show("密码修改成功！");
                        continue;
                    }

                    else if (mesg == "修改失败")
                    {
                        MessageBox.Show("密码修改失败！");
                        continue;
                    }

                    else if (message[0] == "更新时间巅峰榜")
                    {
                        int i = 0;
                        int j = 1;
                        while (i < 10)
                        {
                            tandn[i].name = message[j];
                            j++;
                            tandn[i].time = message[j];
                            j++;
                            i++;
                        }
                        chat.listBox2.Items.Clear();
                        for (i = 0; i < 10; i++)
                        {
                            chat.listBox2.Items.Add((i + 1).ToString() + " --- " + tandn[i].name + " --- " + tandn[i].time);
                        }
                        continue;
                    }

                    else if (message[0] == "更新积分巅峰榜")
                    {
                        int i = 0;
                        int j = 1;
                        while (i < 10)
                        {
                            tandn[i].name = message[j];
                            j++;
                            tandn[i].money = message[j];
                            j++;
                            tandn[i].time = message[j];
                            j++;
                            i++;
                        }
                        chat.listBox2.Items.Clear();
                        for (i = 0; i < 10; i++)
                        {
                            chat.listBox2.Items.Add((i + 1).ToString() + " -- " + tandn[i].name + " -- " + tandn[i].money + " -- " + tandn[i].time);
                        }
                        continue;
                    }

                    else if (message[0] == "进入巅峰榜")
                    {
                        MessageBox.Show(message[1]);
                        continue;
                    }

                    else if (message[0] == "ZheShiYiTiaoYouXiXiangGuanDeZhiLing")
                        continue;

                    else if (message[0] == "ZheShiYiTiaoShangXianDeZhiLing")
                    {
                        chat.listBox1.Items.Add(message[1]);
                        chat.inform.AppendText(message[1] + "已上线！\n");
                        continue;
                    }

                    else if (message[0] == "ZheShiYiTiaoXiaXianDeZhiLing")
                    {
                        chat.listBox1.Items.Remove(message[1]);
                        chat.inform.AppendText(message[1] + "已下线！\n");
                        continue;
                    }

                    else if (message[0] == "ZheShiYiTiaoShangXianDeZhiLing不提醒")
                    {
                        for(int i=1;i<message.Length;i++)
                            chat.listBox1.Items.Add(message[i]);
                        continue;
                    }

                    else
                        chat.inform.AppendText(string.Format("{0}：{1}\n", message[0], message[1]));
                }
               catch
                {
                    MessageBox.Show("未知错误");
                    return;
                }
                //将缓存中的数据写入传输流
            } while (true);
        }
    }
}
