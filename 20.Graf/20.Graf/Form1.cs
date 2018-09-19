using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BL1;

namespace _20.Graf
{
    public partial class Form1 : Form
    {
        public static byte flTools = 0;
        bool drawing = false;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            Lib.graph = new Graph(ClientRectangle.Width, ClientRectangle.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            int w = Screen.PrimaryScreen.Bounds.Width;
            this.Location = new System.Drawing.Point(w - this.Width, 30);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyDraw(false);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (flTools)
            {
                case 0:
                    Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                    drawing = Graph.SelectNode != null;
                    break;
                case 1:
                    Lib.graph.AddNode(e.X, e.Y);
                    MyDraw(false);
                    break;
                case 2:
                    Graph.SelectNodeBeg = Lib.graph.FindNode(e.X, e.Y);
                    drawing = Graph.SelectNodeBeg != null;
                    Lib.graph.x1 = e.X; Lib.graph.y1 = e.Y;
                    Lib.graph.x2 = e.X; Lib.graph.y2 = e.Y;
                    break;
                case 3:
                    Lib.graph.DeSelectEdge();
                    int NumLine = -1;
                    int NumNode = Lib.graph.FindLine(e.X, e.Y, out NumLine);
                    if (NumNode != -1)
                    {
                        Lib.graph.DelEdge(NumNode, NumLine);
                        MyDraw(false);
                    }
                    break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                switch (flTools)
                {
                    case 0:
                        Graph.SelectNode.x = e.X;
                        Graph.SelectNode.y = e.Y;
                        Graph.ChangeA(Graph.SelectNode);
                        MyDraw(false);
                        break;
                    case 2:
                        Lib.graph.x2 = e.X; Lib.graph.y2 = e.Y;
                        MyDraw(true);
                        break;
                }
            }
            else
            {
                switch (flTools)
                {
                    case 0:
                    case 2:
                        Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                        MyDraw(false);
                        break;
                    case 3:
                        Lib.graph.DeSelectEdge();
                        int NumLine = -1;
                        int NumNode = Lib.graph.FindLine(e.X, e.Y, out NumLine);
                        if (NumNode != -1)
                        {
                            Graph.Nodes[NumNode].Edge[NumLine].select = true;
                            MyDraw(false);
                        }
                        break;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            switch (flTools)
            {
                case 2:
                    Graph.SelectNode = Lib.graph.FindNode(e.X, e.Y);
                    if ((Graph.SelectNode != null) && (Graph.SelectNode != Graph.SelectNodeBeg))
                    {
                        Lib.graph.AddEdge();
                        MyDraw(false);
                    }
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Lib.graph != null)
                Lib.graph.ChangeBitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        public void MyDraw(bool fl)
        {
            Lib.graph.Draw(fl);
            g.DrawImage(Lib.graph.bitmap, ClientRectangle);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.typ_graph = Lib.TypeNode.ellipse;
            Program.formMain.MyDraw(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.typ_graph = Lib.TypeNode.rectangle;
            Program.formMain.MyDraw(false);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            flTools = Convert.ToByte((sender as RadioButton).Tag);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Lib.graph.visibleA = checkBox1.Checked;
            Program.formMain.MyDraw(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dijkstra1 O = new Dijkstra1();
            Node[] nodes;
            nodes = Graph.Nodes;
            int L = nodes.Length;
            int[][] arr = Graph.Array1();
            int X = Convert.ToInt32(textBox3.Text);
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            List<string> list = O.Result(X, L, arr);
            sw1.Stop();
            string s1 = "От " + textBox3.Text + " ";
            string s = "";
            for (int i = 0; i < list.Count; i++)
            {
                s = s + s1 + list[i] + Environment.NewLine;
            }
            textBox1.Text = s;

            Dijkstra2 D = new Dijkstra2();
            s = "";
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            D.Result(X, L, arr);
            sw2.Stop();
            for (int i = 0; i < D.arr1.Length; i++)
            {
                if (i == X)
                    s = s + s1 + "до " + i + " равно " + 0 + Environment.NewLine;
                else
                    s = s + s1 + "до " + i + " равно " + D.arr1[X][i] + Environment.NewLine;
            }
            textBox2.Text = s;
            textBox4.Text = "Время работы: " + Convert.ToString(sw1.ElapsedMilliseconds) + "мс";
            textBox5.Text = "Время работы: " + Convert.ToString(sw2.ElapsedMilliseconds) + "мс";
        }
    }
}
