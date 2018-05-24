using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace _24点游戏
{
    public partial class Games : Form
    {
        public Games(bool flag)
        {
            InitializeComponent();
            suiji.Enabled = flag;
        }

        public int numb;   //用于记录玩家人数
        public double st = 50;    //用于游戏开始倒计时
        public double t = 0;    //用于计时
        public bool flag = false;    //标记四个随机数是否有解
        public string[] result = new string[4];   //用于存放正确表达式
        public int[] N = new int[4];   //用于存放四个随机数

        //随机出四个数
        private void suiji_Click(object sender, EventArgs e)
        {
            suiji.Enabled = false;
            byte[] a = Encoding.Unicode.GetBytes(Common.username + "|开始游戏");
            Common.sendStream.Write(a, 0, a.Length);
            Thread.Sleep(100);
            string[] s = Common.mesg.Split('|');
            if(s[0] == "ZheShiYiTiaoYouXiXiangGuanDeZhiLing")
            {
                N[0] = Convert.ToInt16(s[1]);
                N[1] = Convert.ToInt16(s[2]);
                N[2] = Convert.ToInt16(s[3]);
                N[3] = Convert.ToInt16(s[4]);
            }
            label1.Text = "游戏倒计时";
            s_time.Text = "5";
            timer1.Enabled = true;
            result[0] = N[0].ToString();
            result[1] = N[1].ToString();
            result[2] = N[2].ToString();
            result[3] = N[3].ToString();     //将四个随机数存入字符串数组用于存放计算机算出的正确结果
        }

        //计算机计算结果
        public bool Calculate(int []f,int n)
        {
            if(n==1)
            {
                if (f[0] == 24)
                    return true;
                else
                    return false;
            }
            else
            {
                for(int i=0;i<n;i++)
                {
                    for(int j=i+1;j<n;j++)
                    {
                        int a = f[i];
                        int b = f[j];
                        f[j] = f[n - 1];
                        string c = result[i];
                        string d = result[j];
                        result[j] = result[n - 1];
                        //加法
                        result[i] = "(" + c + "+" + d + ")";
                        f[i] = a + b;
                        if (Calculate(f, n - 1))
                            return true;
                        //乘法
                        result[i] = "(" + c + "*" + d + ")";
                        f[i] = a * b;
                        if (Calculate(f, n - 1))
                            return true;
                        //幂运算，结果和次序相关
                        result[i] = "(" + c + "^" + d + ")";
                        f[i] = (int)Math.Pow(a, b);
                        if (Calculate(f, n - 1))
                            return true;
                        result[i] = "(" + d + "^" + c + ")";
                        f[i] = (int)Math.Pow(b, a);
                        if (Calculate(f, n - 1))
                            return true;
                        //减法和除法，结果和次序相关，因不能出现负数与小数所以分情况讨论以减少递归消耗
                        if(a>b)
                        {
                            result[i] = "(" + c + "-" + d + ")";
                            f[i] = a - b;
                            if (Calculate(f, n - 1))
                                return true;
                            if (b != 0)      //因为不能出现小数所以筛选以减少递归消耗
                            {
                                if (a % b == 0)
                                {
                                    result[i] = "(" + c + "/" + d + ")";
                                    f[i] = a / b;
                                    if (Calculate(f, n - 1))
                                        return true;
                                }
                            }
                        }
                        else
                        {
                            result[i] = "(" + d + "-" + c + ")";
                            f[i] = b - a;
                            if (Calculate(f, n - 1))
                                return true;
                            if (a != 0)      //因为不能出现小数所以筛选以减少递归消耗
                            {
                                if (b % a == 0)
                                {
                                    result[i] = "(" + d + "/" + c + ")";
                                    f[i] = b / a;
                                    if (Calculate(f, n - 1))
                                        return true;
                                }
                            }
                        }
                        f[i] = a;
                        f[j] = b;
                        result[i] = c;
                        result[j] = d;
                    }
                }
            }

            return false;
        }

        //判断用户给出的答案是否正确
        private void Queding_Click(object sender, EventArgs e)
        {
            if (Input.Text == "NO")
            {
                if (!flag)
                {
                    timer1.Enabled = false;
                    byte[] a = Encoding.Unicode.GetBytes(Common.username + "|结束游戏|" + t.ToString("0.0"));
                    Common.sendStream.Write(a, 0, a.Length);
                    Common.money = Common.money + numb - 1;
                    t = 0;
                    st = 50;
                    MessageBox.Show("你赢了！获得积分" + (numb - 1).ToString());
                    Queding.Enabled = false;
                    timer2.Enabled = true;
                }
                else
                {
                    Common.money--;
                    MessageBox.Show("答案错误！扣一分！");
                    pictureBox1.Enabled = true;
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                }
            }
            else
            {
                int x = 0;  //存放表达式中+ - * / ^的个数从而判断用户是否将数字拼接使用
                char[] ch = Input.Text.ToArray();
                foreach (char c in ch)
                {
                    if (c == '+')
                        x++;
                    if (c == '-')
                        x++;
                    if (c == '*')
                        x++;
                    if (c == '/')
                        x++;
                    if (c == '^')
                        x++;
                }
                if (x == 3)
                {
                    try
                    {
                        int r = jsresult(Input.Text);
                        if (r == -1)
                            return;
                        if (r == 24)
                        {
                            byte[] a = Encoding.Unicode.GetBytes(Common.username + "|结束游戏|" + t.ToString("0.0"));
                            Common.sendStream.Write(a, 0, a.Length);
                            Thread.Sleep(100);
                            Common.money = Common.money + numb - 1;
                            timer1.Enabled = false;
                            st = 50;
                            MessageBox.Show("你赢了！获得积分" + (numb - 1).ToString());
                            byte[] b = Encoding.Unicode.GetBytes(Common.username + "|进入巅峰榜|" + t.ToString("0.0"));
                            Common.sendStream.Write(b, 0, b.Length);
                            t = 0;
                            Queding.Enabled = false;
                            timer2.Enabled = true;
                        }
                        else
                        {
                            Common.money--;
                            MessageBox.Show("答案错误！扣一分！");
                            pictureBox1.Enabled = true;
                            pictureBox2.Enabled = true;
                            pictureBox3.Enabled = true;
                            pictureBox4.Enabled = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("输入的表达式格式有误！请检查");
                    }
                }
                else
                {
                    MessageBox.Show("请勿将数字拼接使用！");
                }
            }
        }

        //清除文本框
        private void inputclera_Click(object sender, EventArgs e)
        {
            Input.Clear();
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
        }

        private void jia_Click(object sender, EventArgs e)
        {
            Input.AppendText(jia.Text);
        }

        private void jian_Click(object sender, EventArgs e)
        {
            Input.AppendText(jian.Text);
        }

        private void cheng_Click(object sender, EventArgs e)
        {
            Input.AppendText(cheng.Text);
        }

        private void chu_Click(object sender, EventArgs e)
        {
            Input.AppendText(chu.Text);
        }

        private void mi_Click(object sender, EventArgs e)
        {
            Input.AppendText(mi.Text);
        }


        private void qiankuohao_Click(object sender, EventArgs e)
        {
            Input.AppendText(qiankuohao.Text);
        }

        private void fankuohao_Click(object sender, EventArgs e)
        {
            Input.AppendText(fankuohao.Text);
        }

        private void wujie_Click(object sender, EventArgs e)
        {
            Input.Clear();
            Input.AppendText("NO");
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (st > 0)
            {
                st--;
                s_time.Text = (st / 10).ToString();
                numb = listBox1.Items.Count;
                return;
            }
            else if(label1.Text!= "当前耗时:")
            {
                label1.Text = "当前耗时:";
                suiji.Enabled = false;
                if (!Queding.Enabled)
                {
                    puchang(N);
                    flag = Calculate(N, 4);    //穷举法得出答案
                }
                Queding.Enabled = true;
            }
            t = t + 0.1;
            s_time.Text = t.ToString("0.0");
            string[] s = null;
            if (Common.mesg != null)
                s = Common.mesg.Split('|');
            else
                return;
            if (s[0] != "ZheShiYiTiaoYouXiXiangGuanDeZhiLing")
                return;
            else
            {
                Common.mesg = null;
                if(s[2]=="已退出游戏")
                    listBox1.Items.Remove(s[1]);
                if(s[2]=="已结束游戏")
                {
                    timer1.Enabled = false;
                    Queding.Enabled = false;
                    Common.money--;
                    MessageBox.Show("游戏结束,积分减1，" + s[1] + "胜出\n正确答案是："+result[0]);
                    t = 0;
                    st = 50;
                    timer2.Enabled = true;
                }
            }
        }

        private void Games_Load(object sender, EventArgs e)
        {
            if (suiji.Enabled == false)
            {
                string[] s = Common.mesg.Split('|');
                if (s[0] == "ZheShiYiTiaoYouXiXiangGuanDeZhiLing")
                {
                    foreach (string c in s)
                    {
                        if (c != "ZheShiYiTiaoYouXiXiangGuanDeZhiLing" && c != "已在游戏内")
                            listBox1.Items.Add(c);
                    }
                }
            }
            else
                listBox1.Items.Add(Common.username);
        }

        private void Games_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.flag = true;
            if(timer1.Enabled)
            {
                timer1.Enabled = false;
                MessageBox.Show("中途退出游戏直接扣分！");
                MessageBox.Show(result[0]);
                Common.money--;
            }
            byte[] b = Encoding.Unicode.GetBytes(Common.username + "|退出游戏|" + t.ToString("0.0"));
            Common.sendStream.Write(b, 0, b.Length);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string[] s = null;
            if (Common.mesg != null)
                s = Common.mesg.Split('|');
            else
                return;
            if (s[0] != "ZheShiYiTiaoYouXiXiangGuanDeZhiLing")
                return;
            else if (s[2] == "已开始游戏")
            {
                Common.mesg = null;
                label1.Text = "游戏倒计时";
                s_time.Text = "5";
                timer1.Enabled = true;
                timer2.Enabled = false;
                N[0] = Convert.ToInt16(s[3]);
                N[1] = Convert.ToInt16(s[4]);
                N[2] = Convert.ToInt16(s[5]);
                N[3] = Convert.ToInt16(s[6]);
                result[0] = N[0].ToString();
                result[1] = N[1].ToString();
                result[2] = N[2].ToString();
                result[3] = N[3].ToString();     //将四个随机数存入字符串数组用于存放计算机算出的正确结果
            }

            else if (s[2] == "已加入游戏")
            {
                Common.mesg = null;
                listBox1.Items.Add(s[1]);
            }

            else if (s[2] == "已退出游戏")
                listBox1.Items.Remove(s[1]);
        }

        /*计算表达式结果*/
        private int jsresult(string s)
        {
            Stack<int> st = new Stack<int>();
            List<char> c = new List<char>(s);
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i] == '(')
                    st.Push(i);
                if (c[i] == ')')
                {
                    if (st.Count == 0)
                    {
                        MessageBox.Show("表达式括号不对称");
                        return -1;
                    }
                    int j = st.Pop();
                    int m = jisuan(c, j + 1, i);
                    int u = 0;
                    while (m > 0)
                    {
                        int n = m.ToString().ToCharArray().Length - 1;
                        c[j + n] = (m % 10).ToString().ToCharArray()[0];
                        m = m / 10;
                        u++;
                    }
                    for (int k = j + u; k <= i;)
                    {
                        c.RemoveAt(k);
                        i--;
                    }
                }
            }
            return jisuan(c, 0, c.Count);
        }

        public int jisuan(List<char> ch, int a, int b)
        {
            string s = null;
            for (int i = a; i < b; i++)
                s = s + ch[i];
            List<string> str = new List<string>(s.Split('+', '-', '*', '/', '^'));
            while (str.Contains(""))
                str.Remove("");
            List<int> num = new List<int>();
            List<char> ysf = new List<char>();
            foreach (string i in str)
                num.Add(Convert.ToInt32(i));
            foreach (char c in s)
            {
                switch (c)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        ysf.Add(c);
                        break;
                }
            }
            for (int i = 0; i < ysf.Count; i++)
            {
                if (ysf[i] == '^')
                {
                    int n = num[i + 1];
                    int m = num[i];
                    while (n > 1)
                    {
                        num[i] = m * num[i];
                        n--;
                    }
                    ysf.RemoveAt(i);
                    num.RemoveAt(i + 1);
                    i--;
                }
            }
            for (int i = 0; i < ysf.Count; i++)
            {
                if (ysf[i] == '*')
                {
                    num[i] = num[i] * num[i + 1];
                    ysf.RemoveAt(i);
                    num.RemoveAt(i + 1);
                    i--;
                    continue;
                }
                if (ysf[i] == '/')
                {
                    num[i] = num[i] / num[i + 1];
                    ysf.RemoveAt(i);
                    num.RemoveAt(i + 1);
                    i--;
                }
            }
            for (int i = 0; i < ysf.Count; i++)
            {
                if (ysf[i] == '+')
                {
                    num[i] = num[i] + num[i + 1];
                    ysf.RemoveAt(i);
                    num.RemoveAt(i + 1);
                    i--;
                    continue;
                }
                if (ysf[i] == '-')
                {
                    num[i] = num[i] - num[i + 1];
                    ysf.RemoveAt(i);
                    num.RemoveAt(i + 1);
                    i--;
                }
            }
            return num[0];
        }


        public void puchang(int []N)
        {
            switch (N[0])
            {
                case 1:pictureBox1.Image = Properties.Resources._1;pictureBox1.Tag = 1;break;
                case 2: pictureBox1.Image = Properties.Resources._2; pictureBox1.Tag = 2; break;
                case 3: pictureBox1.Image = Properties.Resources._3; pictureBox1.Tag = 3; break;
                case 4: pictureBox1.Image = Properties.Resources._4; pictureBox1.Tag = 4; break;
                case 5: pictureBox1.Image = Properties.Resources._5; pictureBox1.Tag = 5; break;
                case 6: pictureBox1.Image = Properties.Resources._6; pictureBox1.Tag = 6; break;
                case 7: pictureBox1.Image = Properties.Resources._7; pictureBox1.Tag = 7; break;
                case 8: pictureBox1.Image = Properties.Resources._8; pictureBox1.Tag = 8; break;
                case 9: pictureBox1.Image = Properties.Resources._9; pictureBox1.Tag = 9; break;
                case 10: pictureBox1.Image = Properties.Resources._10; pictureBox1.Tag = 10; break;
                case 11: pictureBox1.Image = Properties.Resources._11; pictureBox1.Tag = 11; break;
                case 12: pictureBox1.Image = Properties.Resources._12; pictureBox1.Tag = 12; break;
                case 13: pictureBox1.Image = Properties.Resources._13; pictureBox1.Tag = 13; break;

            }
            switch (N[1])
            {
                case 1: pictureBox2.Image = Properties.Resources._1; pictureBox2.Tag = 1; break;
                case 2: pictureBox2.Image = Properties.Resources._2; pictureBox2.Tag = 2; break;
                case 3: pictureBox2.Image = Properties.Resources._3; pictureBox2.Tag = 3; break;
                case 4: pictureBox2.Image = Properties.Resources._4; pictureBox2.Tag = 4; break;
                case 5: pictureBox2.Image = Properties.Resources._5; pictureBox2.Tag = 5; break;
                case 6: pictureBox2.Image = Properties.Resources._6; pictureBox2.Tag = 6; break;
                case 7: pictureBox2.Image = Properties.Resources._7; pictureBox2.Tag = 7; break;
                case 8: pictureBox2.Image = Properties.Resources._8; pictureBox2.Tag = 8; break;
                case 9: pictureBox2.Image = Properties.Resources._9; pictureBox2.Tag = 9; break;
                case 10: pictureBox2.Image = Properties.Resources._10; pictureBox2.Tag = 10; break;
                case 11: pictureBox2.Image = Properties.Resources._11; pictureBox2.Tag = 11; break;
                case 12: pictureBox2.Image = Properties.Resources._12; pictureBox2.Tag = 12; break;
                case 13: pictureBox2.Image = Properties.Resources._13; pictureBox2.Tag = 13; break;


            }
            switch (N[2])
            {
                case 1: pictureBox3.Image = Properties.Resources._1; pictureBox3.Tag = 1; break;
                case 2: pictureBox3.Image = Properties.Resources._2; pictureBox3.Tag = 2; break;
                case 3: pictureBox3.Image = Properties.Resources._3; pictureBox3.Tag = 3; break;
                case 4: pictureBox3.Image = Properties.Resources._4; pictureBox3.Tag = 4; break;
                case 5: pictureBox3.Image = Properties.Resources._5; pictureBox3.Tag = 5; break;
                case 6: pictureBox3.Image = Properties.Resources._6; pictureBox3.Tag = 6; break;
                case 7: pictureBox3.Image = Properties.Resources._7; pictureBox3.Tag = 7; break;
                case 8: pictureBox3.Image = Properties.Resources._8; pictureBox3.Tag = 8; break;
                case 9: pictureBox3.Image = Properties.Resources._9; pictureBox3.Tag = 9; break;
                case 10: pictureBox3.Image = Properties.Resources._10; pictureBox3.Tag = 10; break;
                case 11: pictureBox3.Image = Properties.Resources._11; pictureBox3.Tag = 11; break;
                case 12: pictureBox3.Image = Properties.Resources._12; pictureBox3.Tag = 12; break;
                case 13: pictureBox3.Image = Properties.Resources._13; pictureBox3.Tag = 13; break;


            }
            switch (N[3])
            {
                case 1: pictureBox4.Image = Properties.Resources._1; pictureBox4.Tag = 1; break;
                case 2: pictureBox4.Image = Properties.Resources._2; pictureBox4.Tag = 2; break;
                case 3: pictureBox4.Image = Properties.Resources._3; pictureBox4.Tag = 3; break;
                case 4: pictureBox4.Image = Properties.Resources._4; pictureBox4.Tag = 4; break;
                case 5: pictureBox4.Image = Properties.Resources._5; pictureBox4.Tag = 5; break;
                case 6: pictureBox4.Image = Properties.Resources._6; pictureBox4.Tag = 6; break;
                case 7: pictureBox4.Image = Properties.Resources._7; pictureBox4.Tag = 7; break;
                case 8: pictureBox4.Image = Properties.Resources._8; pictureBox4.Tag = 8; break;
                case 9: pictureBox4.Image = Properties.Resources._9; pictureBox4.Tag = 9; break;
                case 10: pictureBox4.Image = Properties.Resources._10; pictureBox4.Tag = 10; break;
                case 11: pictureBox4.Image = Properties.Resources._11; pictureBox4.Tag = 11; break;
                case 12: pictureBox4.Image = Properties.Resources._12; pictureBox4.Tag = 12; break;
                case 13: pictureBox4.Image = Properties.Resources._13; pictureBox4.Tag = 13; break;
            }
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Input.AppendText(pictureBox1.Tag.ToString());
            pictureBox1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Input.AppendText(pictureBox2.Tag.ToString());
            pictureBox2.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Input.AppendText(pictureBox3.Tag.ToString());
            pictureBox3.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Input.AppendText(pictureBox4.Tag.ToString());
            pictureBox4.Enabled = false;
        }
    }
}
