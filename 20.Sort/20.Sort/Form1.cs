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

namespace _20.Sort
{
    public partial class Form1 : Form
    {
        Sortirovka k;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();  // создаем место для рисования
            g.TranslateTransform(5, 500); // смещение начала координат
            g.ScaleTransform(3f, 0.1f);

            Pen pen1 = new Pen(Color.Green, 1f);
            Pen pen2 = new Pen(Color.Red, 1f);
            Pen gridPen = new Pen(Color.Black, 0.0001f);
            Pen penCO = new Pen(Color.Black, 1f);

            g.DrawLine(penCO, new Point(-5000, 0), new Point(5000, 0));
            g.DrawLine(penCO, new Point(0, -5000), new Point(0, 5000));
            Font font = new Font(FontFamily.GenericSansSerif, 7f);

            // рисуем координатную сетку
            int x = 0;
            int y = 0;
            while (x <= 3000)
            {
                x = x + 10;
                y = y - 200;
                g.DrawLine(gridPen, new Point(x, 0), new Point(x, -10000));
                g.DrawLine(gridPen, new Point(0, y), new Point(3000, y));
            }

            //подписываем ось OX
            g.ScaleTransform(1f, 10f);
            x = 0;
            g.DrawString("0", font, Brushes.Black, -3, -7);
            while (x < 100)
            {
                x = x + 20;
                g.DrawString(Convert.ToString(x), font, Brushes.Black, x - 7, -7);
            }

            //подписываем ось OY
            x = 0;
            y = 0;
            while (x <= 3000)
            {
                x = x + 40;
                y = y + 400;
                g.DrawString(Convert.ToString(y), font, Brushes.Black, -3, -x - 3);
            }
            g.ScaleTransform(1f, 0.1f);

            
            List<Point> p1 = new List<Point>();
            Point pos1 = new Point(0, 0);
            p1.Add(pos1);
            for (int i = 0; i <= 100; i = i + 5)
            {
                k = new Sortirovka(i, true);
                pos1 = new Point(i, -k.SortBubl());
                p1.Add(pos1);
            }
            List<Point> p2 = new List<Point>();
            Point pos2 = new Point(0, 0);
            p2.Add(pos2);
            for (int i = 5; i <= 100; i = i + 5)
            {
                k = new Sortirovka(i, true);
                pos2 = new Point(i, -k.SortShaker());
                p2.Add(pos2);
            }

            g.DrawCurve(pen1, p1.ToArray());
            g.DrawCurve(pen2, p2.ToArray());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel2.CreateGraphics();  // создаем место для рисования
            g.TranslateTransform(5, 500); // смещение начала координат
            g.ScaleTransform(3f, 0.16f);

            Pen pen1 = new Pen(Color.Green, 1f);
            Pen pen2 = new Pen(Color.Red, 1f);
            Pen gridPen = new Pen(Color.Black, 0.0001f);
            Pen penCO = new Pen(Color.Black, 1f);

            g.DrawLine(penCO, new Point(-5000, 0), new Point(5000, 0));
            g.DrawLine(penCO, new Point(0, -5000), new Point(0, 5000));
            Font font = new Font(FontFamily.GenericSansSerif, 7f);

            // рисуем координатную сетку
            int x = 0;
            int y = 0;
            while (x <= 3000)
            {
                x = x + 10;
                y = y - 200;
                g.DrawLine(gridPen, new Point(x, 0), new Point(x, -10000));
                g.DrawLine(gridPen, new Point(0, y), new Point(3000, y));
            }

            //подписываем ось OX
            g.ScaleTransform(1f, 6.25f);
            x = 0;
            g.DrawString("0", font, Brushes.Black, -3, -7);
            while (x < 100)
            {
                x = x + 20;
                g.DrawString(Convert.ToString(x), font, Brushes.Black, x - 7, -7);
            }

            //подписываем ось OY
            x = 0;
            y = 0;
            while (x <= 3000)
            {
                x = x + 32;
                y = y + 200;
                g.DrawString(Convert.ToString(y), font, Brushes.Black, -3, -x - 3);
            }
            g.ScaleTransform(1f, 0.16f);

            List<Point> p1 = new List<Point>();
            Point pos1 = new Point(0, 0);
            p1.Add(pos1);
            for (int i = 0; i <= 100; i = i + 5)
            {
                k = new Sortirovka(i, false);
                pos1 = new Point(i, -k.SortBubl());
                p1.Add(pos1);
            }
            List<Point> p2 = new List<Point>();
            Point pos2 = new Point(0, 0);
            p2.Add(pos2);
            for (int i = 5; i <= 100; i = i + 5)
            {
                k = new Sortirovka(i, false);
                pos2 = new Point(i, -k.SortShaker());
                p2.Add(pos2);
            }

            g.DrawCurve(pen1, p1.ToArray());
            g.DrawCurve(pen2, p2.ToArray());
        }
    }
}
