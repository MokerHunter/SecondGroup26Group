using System;
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
        string[] str;
        public Form1()
        {
            InitializeComponent();
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
        }

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Над проектом работали:\n\nЖуравский Дмитрий\n\nИванов Семен\n\nСирбаев Вильдан\n\nСуслопарова Анастасия\n\nФаузетдинов Ильнар");
        }
    }
}
