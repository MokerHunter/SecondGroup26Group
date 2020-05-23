using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    

    
    public partial class Form2 : Form
    {
        struct tasker
        {
            public string qwest;
            public string[] ans;
            public int[] ansTrue;
        }
        tasker[] theTask;
        bool checkd = false;
        TextBox textBox1 = new TextBox();
        TextBox textBox2 = new TextBox();
        TextBox textBox3 = new TextBox();
        Label label1 = new Label();
        Label label2 = new Label();
        Label label3 = new Label();
        Label label4 = new Label();
        Panel panel1 = new Panel();
        TextBox[] t;
        TextBox[] T;
        CheckBox[] C;
        Size sz = new Size(155, 30);
        Size Tsz = new Size(0, 0);
        Size Bsz = new Size(134, 53);
        Size tsz = new Size(319, 20);
        const int con = 35;
        void creating()
        {
            
            Button button1 = new Button();
            button1.Location = new Point(76, 36);
            button1.Text = "Добавить новый";
            button1.Size = Bsz;
            button1.Click += new EventHandler(button1Button_Click);
            Button button2 = new Button();
            button2.Text = "Назад";
            button2.Size = Bsz;
            button2.Click += new EventHandler(button2Button_Click);
            button2.Location = new Point(766, 10);
            Button button3 = new Button();
            button3.Text = "Сохранить";
            button3.Size = Bsz;
            button3.Click += new EventHandler(button3Button_Click);
            button3.Location = new Point(766, 69);
            Button button4 = new Button();
            button4.Text = "Открыть для редактирования";
            button4.Size = Bsz;
            button4.Click += new EventHandler(button4Button_Click);
            button4.Location = new Point(900, 69);
            textBox1.Location = new Point(257, 16);
            textBox1.Size = tsz;
            textBox2.Location = new Point(257, 53);
            textBox2.Size = tsz;
            textBox3.Location = new Point(257, 92);
            textBox3.Size = tsz;
            panel1.Location = new Point(1, 128);
            panel1.Size = new Size(1050, 503);
            panel1.AutoScroll = true;
            label1.Location = new Point(594, 19);
            label2.Location = new Point(594, 56);
            label3.Location = new Point(594, 95);
            label1.Size = new Size(170, 20);
            label2.Size = new Size(170, 20);
            label3.Size = new Size(170, 20);
            label1.Text = "Введите название теcта";
            label2.Text = "Введите кол-во вопросов";
            label3.Text = "Введите макс.кол-во ответов";
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(button4);
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);
            this.Controls.Add(panel1);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
        }

        bool checker (string s, bool c)
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if ((int)s[i] < 48 || (int)s[i] > 57)
                {
                    c = false;
                }
            }
            if (s.Length < 1) return false;
            if (s[0] == '0') return false;
            else return c;
        }
        public Form2()
        {           
            creating();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void createTask(int N, int N2)
        {
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
                T[i].Location = new Point(con * 2, i * T[i].Size.Height + i * (N2  * (t[0].Size.Height + 5) + 2 * con) + con);
                panel1.Controls.Add(T[i]);
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
                    panel1.Controls.Add(t[j + i * N2]);
                    panel1.Controls.Add(C[j + i * N2]);
                    l++;
                }
            }
            panel1.AutoScroll = true;
        }

        void button1Button_Click(object sender, EventArgs e)
        {
            checkd = false;
            this.Controls.Clear();
            panel1.Controls.Clear();
            creating();
            string s2 = textBox3.Text;
            string s = textBox2.Text;
            bool c = true;
            c = checker(s, c);
            c = checker(s2, c);

            if (!c)
            {
                label4.ForeColor = Color.Red;
                label4.Size = new Size(300, 300);
                label4.Font = new Font(label4.Font.FontFamily, 20F, label4.Font.Style);
                label4.Text = "Error";
                label4.Location = new Point(400, 115);
                panel1.Controls.Add(label4);
            }
            else
            {
                if(int.Parse(s) > 0 && int.Parse(s2) > 0)
                {
                    createTask(int.Parse(s), int.Parse(s2));
                    checkd = true;
                }
            }
        }
        void button2Button_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }
        void button3Button_Click(object sender, EventArgs e)
        {
            checkd = true;
            checkd = checker(textBox2.Text, checkd);
            checkd = checker(textBox3.Text, checkd);
            if (checkd)
            {
                int s = int.Parse(textBox2.Text);
                int s2 = int.Parse(textBox3.Text);
                int summ = 0;
                for (int i = 0; i < s; ++i)
                {
                    
                    for (int j = 0; j < s2; ++j)
                    {
                        if (C[i * s2 + j].Checked == true)
                        {
                            summ++;
                            break;
                        }
                    }
                }
                if(summ == s)
                { 
                    saveFileDialog1.InitialDirectory = "";
                    saveFileDialog1.Filter = "Файлы txt|*.txt|Файлы dat|*.dat";
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    string filename = saveFileDialog1.FileName;
                    saveFileDialog1.FileName = filename;

                    theTask = new tasker[s + 1];
                    theTask[0] = new tasker();
                    if(T[0].Text == "") theTask[0].qwest = "NoName";
                    else theTask[0].qwest = textBox1.Text;
                    theTask[0].ansTrue = new int[s2];
                    theTask[0].ansTrue[0] = s;
                    theTask[0].ansTrue[1] = s2;


                    System.IO.File.WriteAllText(filename, theTask[0].qwest + '\n');
                    System.IO.File.AppendAllText(filename, theTask[0].ansTrue[0].ToString() + '\n');
                    System.IO.File.AppendAllText(filename, theTask[0].ansTrue[1].ToString() + '\n');

                    for (int i = 0; i < s; ++i)
                    {
                        theTask[i + 1] = new tasker();
                        theTask[i + 1].qwest = T[i].Text;
                        System.IO.File.AppendAllText(filename, theTask[i + 1].qwest + '\n');
                        theTask[i + 1].ansTrue = new int[s2];
                        theTask[i + 1].ans = new string[s2];
                        for (int j = 0; j < s2; ++j)
                        {
                            theTask[i + 1].ans[j] = t[i * s2 + j].Text;
                            theTask[i + 1].ansTrue[j] = 0;
                            if (C[i * s2 + j].Checked == true)
                            {
                                theTask[i + 1].ansTrue[j] = 1;
                            }
                            System.IO.File.AppendAllText(filename, theTask[i + 1].ans[j] + '\n');
                            System.IO.File.AppendAllText(filename, theTask[i + 1].ansTrue[j].ToString() + '\n');
                        }
                    }
                    MessageBox.Show("Файл сохранен");
                    checkd = false;
                }
                else
                {
                    MessageBox.Show("Варианты правильных ответов указаны не везде");
                }
                
            }
            else
            {
                MessageBox.Show("Файл пустой");
            }
            
        }

        void button4Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы txt|*.txt|Файлы dat|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;

            string[] str = System.IO.File.ReadAllLines(filename);
            int s = int.Parse(str[1]), s2 = int.Parse(str[2]);
            theTask = new tasker[s + 1];
            theTask[0] = new tasker();
            theTask[0].qwest = str[0];
            theTask[0].ansTrue = new int[s2];
            theTask[0].ansTrue[0] = s;
            theTask[0].ansTrue[1] = s2;

            textBox1.Text = theTask[0].qwest;
            textBox2.Text = theTask[0].ansTrue[0].ToString();
            textBox3.Text = theTask[0].ansTrue[1].ToString();

            for (int i = 0; i < s; ++i)
            {
                theTask[i + 1] = new tasker();
                theTask[i + 1].qwest = str[i * 2 * s2 + i + 3];
                theTask[i + 1].ans = new string[s2];
                theTask[i + 1].ansTrue = new int[s2];
                for(int j = 0; j < s2* 2; ++j)
                {
                    if (j % 2 == 0) theTask[i + 1].ans[j / 2] = str[i + i * 2 *s2 + j + 4];
                    else theTask[i + 1].ansTrue[j / 2] = int.Parse(str[i + i * 2 * s2 + j + 4]);
                }
            }

            createTask(s, s2);

            for(int i = 0; i < s; ++i)
            {
                T[i].Text = theTask[i + 1].qwest;
                for(int j = 0; j < s2; j++)
                {
                    t[i * s2 + j].Text = theTask[i + 1].ans[j];
                    if (theTask[i + 1].ansTrue[j] == 1)
                    {
                        C[i * s2 + j].Checked = true;
                    }
                }
            }
            MessageBox.Show("Файл открыт");
            checkd = true;
        }
    }
}
