using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL1;

namespace _20._2
{
    public partial class Form2 : Form
    {
        WorkWithNumber k;
        WorkWithBinaryFiles b;

        public Form2()
        {
            InitializeComponent();
        }

        private void inputFromFileButton_Click(object sender, EventArgs e)
        {
            if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                b = new WorkWithBinaryFiles(inputOpenFileDialog.FileName);
                textBox1.Text = b.ReadFile();
                k = new WorkWithNumber(b.Text);
                inputOpenFileDialog.Dispose();
            }
        }

        private void processbutton_Click(object sender, EventArgs e)
        {
            textBox2.Text = k.SpisokDlinSeriy();
        }

        private void outputToFileButton_Click(object sender, EventArgs e)
        {
            if (outputSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                b = new WorkWithBinaryFiles(outputSaveFileDialog.FileName);
                b.WriteFile(textBox2.Text);
                outputSaveFileDialog.Dispose();
            }
        }
    }
}
