using System;
using System.Drawing.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        bool checker(string s, bool c)
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
        string[] str;
        public Form1()
        {

            InitializeComponent();
            InstalledFontCollection inst = new InstalledFontCollection();
            foreach (var x in inst.Families)
            {
                comboBox1.Items.Add(x.Name);
            }
            //button2.Enabled = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 newForm = new Form3();
            newForm.button2.Text = textBox2.Text;
            newForm.ShowDialog();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы txt|*.txt|Файлы dat|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;

            str = System.IO.File.ReadAllLines(filename);
            textBox1.Text = str[0];
            textBox2.Text = filename;
            button3.Text = "Ваш тест готов";
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Над проектом работали:\n\nЖуравский Дмитрий\n\nИванов Семен\n\nСирбаев Вильдан\n\nСуслопарова Анастасия\n\nФаузетдинов Ильнар");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тестер\n\nПрограмма,\n\nпредназначенная\n\nдля\n\nсоздания\n\nи\n\nпроведения\n\nтестов");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            bool c = true;
            c = checker(s, c);
            if (c)
            {
                Single p = int.Parse(textBox3.Text);
                InstalledFontCollection inst = new InstalledFontCollection();
                if (comboBox1.SelectedIndex != -1)
                {
                    textBox1.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    textBox3.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    textBox2.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    button1.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    button2.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    button3.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    label1.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    label2.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    label3.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    label4.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    label5.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                    comboBox1.Font = new Font(inst.Families[comboBox1.SelectedIndex], p, FontStyle.Bold);
                }
            }
        }
    }
}
