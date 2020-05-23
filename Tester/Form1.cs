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
      
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1000, 800);
            this.Left = 0;
            button1.Location = new Point(this.Size.Width / 8, this.Size.Height - this.Size.Height / 5);
            button2.Location = new Point(2 * this.Size.Width / 8, this.Size.Height - this.Size.Height / 5);
            button3.Location = new Point(3 * this.Size.Width / 8, this.Size.Height - this.Size.Height / 5);
            button4.Location = new Point(4 * this.Size.Width / 8, this.Size.Height - this.Size.Height / 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 newForm = new Form2();
            this.Width = 1200;
            this.Width = 1200;
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
       
    }
}
