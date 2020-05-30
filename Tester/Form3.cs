using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form3 : Form
    {
        struct tasker
        {
            public string qwest;
            public string[] ans;
            public int[] ansTrue;
        }
        tasker[] theTask;
        TextBox[] t;
        TextBox[] T;
        CheckBox[] C;
        Size sz = new Size(155, 30);
        Size Tsz = new Size(0, 0);
        const int con = 35;
        int N, N2, counter = 0;
        public void createTest()
        {
            string filename = button2.Text;
            string[] s = System.IO.File.ReadAllLines(filename);
            textBox1.Text = s[0];
            textBox2.Text = s[1];
            N = int.Parse(s[1]);
            N2 = int.Parse(s[2]);
            Tsz = new Size(panel1.Width - con * 4, 100);
            sz = new Size(panel1.Width - con * 4, 60);
            t = new TextBox[N * N2 + 1];
            T = new TextBox[N + 1];
            C = new CheckBox[N * N2 + 1];
            t[0] = new TextBox();
            T[0] = new TextBox();
            t[0].Size = sz;
            T[0].Size = Tsz;

            int u = (panel1.Size.Width - 2 * con) / (t[0].Size.Width + con / 2);
            for (int i = 0; i < N; ++i)
            {
                int l = 0;
                T[i] = new TextBox();
                T[i].Size = Tsz;
                T[i].Multiline = true;
                T[i].Location = new Point(con * 2, i * T[i].Size.Height + i * (N2 * (t[0].Size.Height + 5) + 2 * con) + con);
                for (int j = 0; j < N2; ++j)
                {
                    if (j % u == 0)
                    {
                        l = 0;
                    }
                    t[j + i * N2] = new TextBox();
                    C[j + i * N2] = new CheckBox();
                    t[j + i * N2].Size = sz;
                    t[j + i * N2].Location = new Point(l * (t[j + i * N2].Size.Width + con / 2) + con * 2, j * (t[j + i * N2].Size.Height + 5) + con + T[i].Size.Height + T[i].Location.Y);
                    C[j + i * N2].Location = new Point(con, j * (t[j + i * N2].Size.Height + 5) + con + T[i].Size.Height + T[i].Location.Y);
                    l++;
                }
            }
            panel1.AutoScroll = true;
            theTask = new tasker[N];
            for (int i = 0; i < N; ++i)
            {
                theTask[i] = new tasker();
                theTask[i].qwest = s[i * 2 * N2 + i + 3];
                theTask[i].ans = new string[N2];
                theTask[i].ansTrue = new int[N2];
                for (int j = 0; j < N2 * 2; ++j)
                {
                    if (j % 2 == 0) theTask[i].ans[j / 2] = s[i + i * 2 * N2 + j + 4];
                    else theTask[i].ansTrue[j / 2] = int.Parse(s[i + i * 2 * N2 + j + 4]);
                }
            }
            for (int i = 0; i < N; ++i)
            {
                T[i].Text = theTask[i].qwest;
                for (int j = 0; j < N2; j++)
                {
                    t[i * N2 + j].Text = theTask[i].ans[j];
                }
            }
            for(int i = 0; i < N; ++i)
            {
                panel1.Controls.Add(T[i]);
                for (int j = 0; j < N2; ++j)
                {
                    if (theTask[i].ans[j] != "")
                    {
                        panel1.Controls.Add(t[j + i * N2]);
                        panel1.Controls.Add(C[j + i * N2]);
                    }
                }
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Moker\\source\\repos\\SecondGroup\\Tester\\database.txt";
            if (System.IO.File.Exists(path))
            {
                string[] s = File.ReadAllLines(path);
                s[0] = ((int.Parse(s[0]) + 1).ToString());
                File.WriteAllLines(path, s);
                File.AppendAllText(path, textBox3.Text + " - " + counter.ToString());
            }
            else
            {
                File.WriteAllText(path, "1\n");
                File.AppendAllText(path, textBox3.Text + " - " + counter.ToString());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            createTest();
            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < N; ++i)
            {
                int check1 = 0, check2 = 0;
                for(int j = 0; j < N2; ++j)
                {
                    if(C[j + i * N2].Checked && theTask[i].ansTrue[j] == 1) 
                    {
                        check1++;
                    }else if (!C[j + i * N2].Checked && theTask[i].ansTrue[j] == 0)
                    {
                        check2++;
                    }
                }
                if (check1 + check2 == N2) counter++;
            }
            MessageBox.Show("Всего правильных ответов " + counter);
            counter = 0;
            button4.Enabled = true;
            button3.Enabled = false;
            textBox3.Enabled = true;
        }
    }
}
