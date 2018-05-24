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
        static Hashtable clientTable = new Hashtable();  //存放在线用户名单
        static Hashtable roomTable = new Hashtable();   //存放房间名单

        public struct Tandn
        {
            public string name;
            public double time;
        }

        struct IpAndPort
        {
            public string Ip;
            public string Port;
        }

        static public Tandn[] tandn = new Tandn[10];
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
                string username = null;
                bool first = true;

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

                        if (message[1] == "注册用户" && first)
                        {
                            string sel = string.Format("select money from User where name='{0}'", message[0]);
                            MySqlCommand cmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                byte[] b = Encoding.Unicode.GetBytes("注册失败");
                                reciveStream.Write(b, 0, b.Length);
                                Thread.Sleep(100);
                                reader.Close();
                                continue;
                            }
                            else
                                reader.Close();

                            string iput = string.Format("insert into User(name,password,money) values('{0}','{1}',10);", message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(iput, mycon);
                            byte[] a;
                            if (mycmd.ExecuteNonQuery() > 0)
                                a = Encoding.Unicode.GetBytes("注册成功");
                            else
                                a = Encoding.Unicode.GetBytes("注册失败");
                            reciveStream.Write(a, 0, a.Length);
                            continue;
                        }

                        if (message[1] == "登录大厅" && first)
                        {
                            string sel = string.Format("select money from User where name='{0}' and password='{1}'", message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = mycmd.ExecuteReader();
                            if(reader.HasRows && !clientTable.Contains(message[0]))
                            {
                                reader.Read();
                                byte[] b = Encoding.Unicode.GetBytes("登录成功|" + reader[0].ToString());
                                reciveStream.Write(b, 0, b.Length);
                                Thread.Sleep(1000);
                                username = message[0];
                                first = false;
                                Console.WriteLine("客户端{0}已连接", username);
                                foreach (DictionaryEntry obj in clientTable)
                                {
                                    TcpClient tc = (TcpClient)obj.Value;
                                    NetworkStream ns = tc.GetStream();
                                    byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoShangXianDeZhiLing|" + username);
                                    byte[] c = Encoding.Unicode.GetBytes("ZheShiYiTiaoShangXianDeZhiLing不提醒|" + obj.Key.ToString());
                                    ns.Write(a, 0, a.Length);
                                    reciveStream.Write(c, 0, c.Length);
                                    Thread.Sleep(1000);
                                }
                                Thread th = new Thread(lianjie);
                                th.Start(++usercout);
                                clientTable.Add(username, client);
                            }
                            else
                            {
                                byte[] b = Encoding.Unicode.GetBytes("登录失败");
                                reciveStream.Write(b, 0, b.Length);
                                Thread.Sleep(1000);
                            }
                            reader.Close();
                            continue;
                        }

                        if (message[1] == "修改密码" && first)
                        {
                            string chp = string.Format("update User set password='{0}' where name='{1}' and password='{2}';", message[3], message[0], message[2]);
                            MySqlCommand mycmd = new MySqlCommand(chp, mycon);
                            byte[] b;
                            if (mycmd.ExecuteNonQuery() > 0)
                                b = Encoding.Unicode.GetBytes("修改成功");
                            else
                                b = Encoding.Unicode.GetBytes("修改失败");
                            reciveStream.Write(b, 0, b.Length);
                            Thread.Sleep(100);
                            continue;
                        }

                        if (message[0] == username && message[1] == "更新积分")
                        {
                            string upd = string.Format("update User set money={0} where name='{1}';", message[2], message[0]);
                            MySqlCommand mycmd = new MySqlCommand(upd, mycon);
                            mycmd.ExecuteNonQuery();
                            continue;
                        }

                        if(message[0]==username && message[1] == "更新巅峰榜")
                        {
                            
                            string sel = string.Format("select * from Jilu");
                            MySqlCommand mycmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = mycmd.ExecuteReader();
                            while (reader.Read())
                            {
                                int i = (int)reader["mingci"];
                                tandn[i - 1].name = (string)reader["name"];
                                tandn[i - 1].time = (double)reader["time"];
                            }
                            reader.Close();
                            string s = "更新巅峰榜";
                            for (int i=0;i<10;i++)
                                s = s + "|" + tandn[i].name + "|" + tandn[i].time;
                            reciveStream.Write(Encoding.Unicode.GetBytes(s), 0, Encoding.Unicode.GetBytes(s).Length);
                            Thread.Sleep(1000);
                            continue;
                        }

                        if(message[0]==username && message[1]=="进入巅峰榜")
                        {
                            string sel = string.Format("select * from Jilu order by mingci asc");
                            MySqlCommand mycmd = new MySqlCommand(sel, mycon);
                            MySqlDataReader reader = mycmd.ExecuteReader();
                            int mingci = 0;
                            while (reader.Read())
                            {
                                if (Convert.ToDouble(message[2]) > (double)reader["time"])
                                    continue;
                                if (Convert.ToDouble(message[2]) < (double)reader["time"])
                                {
                                    mingci = (int)reader["mingci"];
                                    break;
                                }
                            }
                            reader.Close();
                            if (mingci == 0)
                                continue;
                            sel = string.Format("update Jilu set mingci=mingci+1 where mingci>={0} order by mingci asc", mingci);
                            mycmd = new MySqlCommand(sel, mycon);
                            mycmd.ExecuteNonQuery();
                            sel = $"update Jilu set mingci={mingci},name='{message[0]}',time={Convert.ToDouble(message[2])} where mingci=11";
                            mycmd = new MySqlCommand(sel, mycon);
                            mycmd.ExecuteNonQuery();
                            byte[] b = Encoding.Unicode.GetBytes($"进入巅峰榜|恭喜你以{Convert.ToDouble(message[2])}s的成绩进入了巅峰榜的第{mingci}名！");
                            reciveStream.Write(b, 0, b.Length);
                            Thread.Sleep(1000);
                            continue;
                        }

                        if (msg == username + "|创建游戏")
                        {
                            roomTable.Add(username, username);
                            continue;
                        }

                        if(message[0]==username && message[1]=="加入游戏")
                        {
                            if (roomTable.ContainsValue(message[2]))
                            {
                                roomTable.Add(username, message[2]);
                                string us = null;
                                foreach (DictionaryEntry d in roomTable)
                                {
                                    if (d.Value.ToString() == message[2] && d.Key.ToString() != username)
                                    {
                                        byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoYouXiXiangGuanDeZhiLing|" + username + "|已加入游戏");
                                        TcpClient newClient = (TcpClient)clientTable[d.Key];
                                        NetworkStream nstream = newClient.GetStream();
                                        nstream.Write(a, 0, a.Length);
                                        us = us + "|" + d.Key; 
                                    }
                                }
                                byte[] b = Encoding.Unicode.GetBytes("ZheShiYiTiaoYouXiXiangGuanDeZhiLing|" + username + "|已在游戏内" + us);
                                reciveStream.Write(b, 0, b.Length);
                            }
                            else
                            {
                                byte[] b = Encoding.Unicode.GetBytes("系统通知|该用户未创建游戏");
                                reciveStream.Write(b, 0, b.Length);
                            }
                            continue;
                        }

                        if(msg == username +"|开始游戏")
                        {
                            foreach (DictionaryEntry d in roomTable)
                            {
                                if (d.Value.ToString() == roomTable[username].ToString() && d.Key.ToString() != username)
                                {
                                    byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoYouXiXiangGuanDeZhiLing|" + username + "|已开始游戏");
                                    TcpClient newClient = (TcpClient)clientTable[d.Key];
                                    NetworkStream nstream = newClient.GetStream();
                                    nstream.Write(a, 0, a.Length);
                                }
                            }
                            continue;
                        }

                        if(msg == username +"|结束游戏")
                        {
                            foreach (DictionaryEntry d in roomTable)
                            {
                                if (d.Value.ToString() == roomTable[username].ToString() && d.Key.ToString() != username)
                                {
                                    byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoYouXiXiangGuanDeZhiLing|" + username + "|已结束游戏");
                                    TcpClient newClient = (TcpClient)clientTable[d.Key];
                                    NetworkStream nstream = newClient.GetStream();
                                    nstream.Write(a, 0, a.Length);
                                }
                            }
                            continue;
                        }

                        if(msg == username +"|退出游戏")
                        {
                            foreach (DictionaryEntry d in roomTable)
                            {
                                if (d.Value.ToString() == roomTable[username].ToString() && d.Key.ToString() != username)
                                {
                                    byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoYouXiXiangGuanDeZhiLing|" + username + "|已退出游戏");
                                    TcpClient newClient = (TcpClient)clientTable[d.Key];
                                    NetworkStream nstream = newClient.GetStream();
                                    nstream.Write(a, 0, a.Length);
                                }
                            }
                            roomTable.Remove(username);
                            continue;
                        }

/*                        if (first)
                        {
                            first = false;
                            username = Encoding.Unicode.GetString(buffer, 0, bufferSize).TrimEnd('\0');
                            if (clientTable.ContainsKey(username))
                            {
 //                               reciveStream.Write(Encoding.Unicode.GetBytes("登录失败|该用户名已被使用！"), 0, Encoding.Unicode.GetBytes("登录失败：|该用户名已被使用！").Length);
                                first = true;
                                username = null;
                                break;
                            }
                            else
                            {
                                foreach(DictionaryEntry obj in clientTable)
                                {
                                    TcpClient tc = (TcpClient)obj.Value;
                                    NetworkStream ns = tc.GetStream();
                                    byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoShangXianDeZhiLing|" + username);
                                    byte[] b = Encoding.Unicode.GetBytes("ZheShiYiTiaoShangXianDeZhiLing不提醒|" + obj.Key.ToString()); 
                                    ns.Write(a, 0, a.Length);
                                    reciveStream.Write(b, 0, b.Length);
                                    Thread.Sleep(1000);
                                }
                                reciveStream.Write(Encoding.Unicode.GetBytes("登录成功|！"), 0, Encoding.Unicode.GetBytes("登录成功|！").Length);
                                Console.WriteLine("客户端{0}已连接,序号为{1}", username, userindex);
                                Thread th = new Thread(lianjie);
                                th.Start(++usercout);
                                clientTable.Add(username, client);
                            }
                        }*/

                        else
                        {
                            if(clientTable.ContainsKey(message[0]))
                            {
                                TcpClient newClient = (TcpClient)clientTable[message[0]];
                                NetworkStream nstream = newClient.GetStream();
                                nstream.Write(Encoding.Unicode.GetBytes(username + "|" + message[1]), 0, Encoding.Unicode.GetBytes(username + "|" + message[1]).Length);
                                //                                nstream.Close();
                            }
                            else
                                reciveStream.Write(Encoding.Unicode.GetBytes("系统通知|对方已下线！"), 0, Encoding.Unicode.GetBytes("系统通知：|对方已下线！").Length);
                        }

                    }
                    catch
                    {
                        if (username != null)
                        {
                            Console.WriteLine("{0}已下线", username);
                            clientTable.Remove(username);
                            foreach (DictionaryEntry obj in clientTable)
                            {
                                TcpClient tc = (TcpClient)obj.Value;
                                NetworkStream ns = tc.GetStream();
                                byte[] a = Encoding.Unicode.GetBytes("ZheShiYiTiaoXiaXianDeZhiLing|" + username);
                                ns.Write(a, 0, a.Length);
                            }
                            Thread.Sleep(1000);
                        }
                        break;
                    }
                } while (true);
            } while (true);
        }
    }
}