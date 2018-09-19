using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BL1;

namespace _20
{
    public partial class Form1 : Form
    {
        WorkWithStroki k;
        Utils b;
        public Form1()
        {
            InitializeComponent();
        }

        private void inputFromFileButton_Click(object sender, EventArgs e)
        {
            if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                b = new Utils(inputOpenFileDialog.FileName);
                textBox1.Text = b.ReadFromFile();
                k = new WorkWithStroki(b.S);
                inputOpenFileDialog.Dispose();
            }
        }

        private void processButton1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = k.KatoeSlovo(Convert.ToInt32(textBox6.Text) - 1);
        }


        private void processbutton_Click(object sender, EventArgs e)
        {
            textBox5.Text = k.Number();
        }

        private void pervoe_Click(object sender, EventArgs e)
        {
            textBox3.Text = k.FirstOrLastSlovo(true);
        }

        private void poslednee_Click(object sender, EventArgs e)
        {
            textBox3.Text = k.FirstOrLastSlovo(false);
        }
    }
}
