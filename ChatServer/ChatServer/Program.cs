using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using MySql.Data.MySqlClient;

namespace 服务器端
{
    class Program
    {
        static int usercout = 0;
        static int port = 8000;  //端口号
        private const int bufferSize = 8000;//缓存空间
        static TcpClient client;
        static TcpListener server;

        struct IpAndPort
        {
            public string Ip;
            public string Port;
        }

        static public string constr = "server=101.132.110.155;User Id=root;password=lirui;Database=B15040314";
        static public MySqlConnection mycon = new MySqlConnection(constr);

        static void Main(string[] args)
        {
            mycon.Open();
            IpAndPort ipHePort = new IpAndPort();
 //           ipHePort.Ip = IPAddress.Parse("172.19.21.27").ToString();
            ipHePort.Ip = IPAddress.Parse("127.0.0.1").ToString();
            ipHePort.Port = port.ToString();
            Console.WriteLine("ip地址：{0}", ipHePort.Ip);
            Console.WriteLine("端口号：{0}", ipHePort.Port);
            Thread thread = new Thread(reciveAndListener);
            thread.Start((object)ipHePort);
        }

        static void reciveAndListener(object ipAndPort)
        {

            IpAndPort ipHePort = (IpAndPort)ipAndPort;

            IPAddress ip = IPAddress.Parse(ipHePort.Ip);
            server = new TcpListener(ip, int.Parse(ipHePort.Port));
            server.Start();//启动监听
            Console.WriteLine("服务端开启侦听....");
            lianjie(usercout++);
        }

        static void lianjie(object user)
        {
            do
            {
                //获取连接的客户端对象
                client = server.AcceptTcpClient();
                //获得流
                NetworkStream reciveStream = client.GetStream();
                NetworkStream sendStream = client.GetStream();
                string username = null;
                do
                {
                    byte[] buffer = new byte[bufferSize];
                    int msgSize;
                    try
                    {
                        lock (reciveStream)
                        {
                            msgSize = reciveStream.Read(buffer, 0, bufferSize);
                        }
                        if (msgSize == 0)
                            continue;
                        string msg = Encoding.Unicode.GetString(buffer, 0, msgSize);
                        string[] message = msg.Split('|');

                        if (message[1] == "注册用户")
                        {
                            string sel = string.Format("select money from User where name='{0}'", message[0]);
                            MySqlCommand cmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                byte[] b = Encoding.Unicode.GetBytes("注册失败");
                                sendStream.Write(b, 0, b.Length);
                                reader.Close();
                                continue;
                            }
                            else
                                reader.Close();

                            string iput = string.Format("insert into User(name,password,money,times) values('{0}','{1}',10,'0');", message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(iput, mycon);
                            byte[] a;
                            if (mycmd.ExecuteNonQuery() > 0)
                                a = Encoding.Unicode.GetBytes("注册成功");
                            else
                                a = Encoding.Unicode.GetBytes("注册失败");
                            sendStream.Write(a, 0, a.Length);
                            continue;
                        }

                        if (message[1] == "登录大厅")
                        {
                            string sel = string.Format("select money from User where name='{0}' and password='{1}'", message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = mycmd.ExecuteReader();
                            if(reader.HasRows)
                            {
                                reader.Read();
                                byte[] b = Encoding.Unicode.GetBytes("登录成功|" + reader[0].ToString());
                                sendStream.Write(b, 0, b.Length);
                                username = message[0];
//                                Console.WriteLine("客户端{0}已连接", username);
                                Thread th = new Thread(lianjie);
                                th.Start(++usercout);
                            }
                            else
                            {
                                byte[] b = Encoding.Unicode.GetBytes("登录失败");
                                sendStream.Write(b, 0, b.Length);
                            }
                            reader.Close();
                            continue;
                        }

                        if (message[1] == "修改密码")
                        {
                            string chp = string.Format("update User set password='{0}' where name='{1}' and password='{2}';", message[3], message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(chp, mycon);
                            byte[] b;
                            if (mycmd.ExecuteNonQuery() > 0)
                                b = Encoding.Unicode.GetBytes("修改成功");
                            else
                                b = Encoding.Unicode.GetBytes("修改失败");
                            sendStream.Write(b, 0, b.Length);
                            continue;
                        }

                        if (message[1] == "更新积分")
                        {
                            string upd = string.Format("update User set money={0} where name='{1}';", message[2], message[0]);
                            MySqlCommand mycmd = new MySqlCommand(upd, mycon);
                            mycmd.ExecuteNonQuery();
                            continue;
                        }

                        if (message[1] == "开始答题")
                        {
                            byte[] b = Encoding.Unicode.GetBytes("答题开始|人们常说的红白是指？|博丽灵梦|勃力灵梦|红白歌会|魔理沙|A");
                            sendStream.Write(b, 0, b.Length);
                            continue;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                } while (true);
            } while (true);
        }
    }
}