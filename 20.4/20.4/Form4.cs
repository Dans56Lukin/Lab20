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

namespace _20._4
{
    public partial class Form4 : Form
    {
        WorkwithOchered k = new WorkwithOchered();
        public Form4()
        {
            InitializeComponent();
        }

        private void sozdanie_Click(object sender, EventArgs e)
        {
            textBox1.Text = k.Sozdanie();
        }

        private void reshenie_Click(object sender, EventArgs e)
        {
            textBox2.Text = k.Udalenie();
        }
    }
}
