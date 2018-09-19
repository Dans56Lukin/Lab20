using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _20.Graf
{
    public class Graph
    {
        public struct TEdges          // временная структура для ребра
        {
            public int n1;     // № первой вершины
            public int n2;     // № второй вершины
            public int A;      // вес ребра
        }
        public static TEdges[] Edges;
        public int[] Link;
        const int hx = 50, hy = 10;
        public Bitmap bitmap;
        public static Node[] Nodes = new Node[0];       // узлы
        public static Node SelectNode;                  // выделенный
        public static Node SelectNodeBeg;
        public Lib.TypeNode typ_graph = Lib.TypeNode.rectangle; // тип графа
        public bool visibleA = false;
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public int[,] A;                                // матрица смежности
        Font MyFont;
        Color[] Colors = new Color[7] { Color.White, Color.Yellow, Color.Lime, Color.Gray, Color.Red, Color.Azure, Color.SandyBrown };

        public static int[][] Array1()
        {
            // формируем массив всех ребер
            int N = Nodes.Length; int m = 0;
            for (int i = 0; i <= N - 1; i++)
            {
                int L = 0;
                if (Nodes[i].Edge != null)
                {
                    L = Nodes[i].Edge.Length;
                    for (int j = 0; j <= L - 1; j++)
                        if (!Find(i, Nodes[i].Edge[j].numNode) & (Nodes[i].Edge[j].A != 0))
                        {
                            Array.Resize<TEdges>(ref Edges, ++m);
                            Edges[m - 1].n1 = i;
                            Edges[m - 1].n2 = Nodes[i].Edge[j].numNode;
                            Edges[m - 1].A = Nodes[i].Edge[j].A;
                        }
                }
            }
            int n;
            int[][] arr;
            n = Edges.Length;
            arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[3] { Edges[i].n1, Edges[i].n2, Edges[i].A };
            }
            return arr;
        }

        static bool Find(int m1, int m2)
        {
            bool Result = false;
            if (Edges == null)
                return Result;
            int N = Edges.Length; int i = -1;
            while ((i < N - 1) && !Result)
                Result = ((Edges[++i].n1 == m1) & (Edges[i].n2 == m2)) | ((Edges[i].n1 == m2) & (Edges[i].n2 == m1));
            return Result;
        }

        int IsNode(int n1, int n2) // у узла n2 есть ребро на n1
        {
            int result = -1;
            int L = 0;
            if (Nodes[n2].Edge != null)
            {
                L = Nodes[n2].Edge.Length;
                bool Ok = false;
                int i = -1;
                while ((i < L - 1) && !Ok)
                    Ok = Nodes[n2].Edge[++i].numNode == n1;
                if (Ok)
                    result = i;
            }
            return result;
        }

        public static void ChangeA(Node node)
        {
            int a, b;
            if (node.Edge != null)
                for (int i = 0; i < node.Edge.Length; i++)
                {
                    int n = node.Edge[i].numNode;
                    a = Nodes[n].x;
                    b = Nodes[n].y;
                    node.Edge[i].A = (int)Math.Sqrt((node.x - a) * (node.x - a) + (node.y - b) * (node.y - b));

                    for (int k = 0; k < Nodes.Length; k++)
                        if ((Nodes[k] != node) & (Nodes[k].Edge != null))
                            for (int j = 0; j < Nodes[k].Edge.Length; j++)
                                if (Nodes[Nodes[k].Edge[j].numNode] == node)
                                {
                                    Nodes[k].Edge[j].A = node.Edge[i].A;
                                }

                }
        }

        public void SetFull()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                int L = 0;
                for (int j = 0; j < Nodes.Length; j++)
                    if (i != j)
                    {
                        TEdge e = new TEdge();

                        double a1 = Nodes[i].x;
                        double b1 = Nodes[i].y;
                        double a2 = Nodes[j].x;
                        double b2 = Nodes[j].y;

                        e.A = (int)Math.Sqrt((a2 - a1) * (a2 - a1) + (b2 - b1) * (b2 - b1));
                        e.x1c = Lib.graph.x1 - Nodes[i].x;
                        e.x2c = Lib.graph.x2 - Nodes[j].x;
                        e.yc = (Nodes[j].y + Nodes[i].y) / 2;
                        e.numNode = j;
                        e.color = Color.Silver;

                        L++;
                        Array.Resize<TEdge>(ref Nodes[i].Edge, L);
                        Nodes[i].Edge[L - 1] = e;
                    }
            }
        }

        public void SetSim() // установить граф неориентированным
        {
            int N = Nodes.Length;
            for (int i = 0; i < N; i++)
            {
                int L = 0;
                if (Nodes[i].Edge != null)
                {
                    L = Nodes[i].Edge.Length;
                    for (int j = 0; j < L; j++)
                    {
                        int NumNode = Nodes[i].Edge[j].numNode;
                        int m = IsNode(i, Nodes[i].Edge[j].numNode);
                        if (m == -1)
                        {
                            int Le = 0;
                            if (Nodes[NumNode].Edge == null)
                                Nodes[NumNode].Edge = new TEdge[0];
                            {
                                Le = Nodes[NumNode].Edge.Length;
                                Array.Resize<TEdge>(ref Nodes[NumNode].Edge, ++Le);
                                Nodes[NumNode].Edge[Le - 1].A = Nodes[i].Edge[j].A;
                                Nodes[NumNode].Edge[Le - 1].numNode = i;
                                Nodes[NumNode].Edge[Le - 1].x1c = Nodes[i].Edge[j].x2c;
                                Nodes[NumNode].Edge[Le - 1].x2c = Nodes[i].Edge[j].x1c;
                                Nodes[NumNode].Edge[Le - 1].yc = Nodes[i].Edge[j].yc;
                            }
                        }
                        else
                            if (Nodes[i].Edge[j].A != 0)
                            Nodes[NumNode].Edge[m].A = Nodes[i].Edge[j].A;
                    }
                }
            }
        }

        public void ChangeBitmap(int VW, int VH)
        {
            bitmap = new Bitmap(VW, VH);
            Draw(false);
        }

        public Graph(int VW, int VH)
        {
            bitmap = new Bitmap(VW, VH);
            MyFont = new Font("Courier New", 10, FontStyle.Bold);
        }

        public int FindNumEdge(int i, int j) // i-ый узел имеет смежный j-ый узел
        {
            int result = -1;
            int L = Nodes[i].Edge.Length;
            bool ok = false;
            while ((result < L - 1) && !ok)
                ok = Nodes[i].Edge[++result].numNode == j;
            if (!ok)
                return -1;
            else
                return result;
        }

        public void SetA()
        {
            int N = Nodes.Length;
            A = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    A[i, j] = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                A[i, i] = 0;
                int LL = 0;
                if (Nodes[i].Edge != null)
                {
                    LL = Nodes[i].Edge.Length;
                    for (int j = 0; j < LL; j++)
                        A[i, Nodes[i].Edge[j].numNode] = Nodes[i].Edge[j].A;
                }
            }
        }

        public void Clear() // очистить граф 
        {
            int N = Nodes.Length;
            for (int i = 0; i < N; i++)
                Array.Resize<TEdge>(ref Nodes[i].Edge, 0);
            Array.Resize<Node>(ref Nodes, 0);
        }

        public void AddNode(int x, int y) // добавить узел 
        {
            int N = Nodes.Length;
            Array.Resize<Node>(ref Nodes, ++N);
            Nodes[N - 1] = new Node();
            Nodes[N - 1].name = "Node " + Convert.ToString(N - 1);
            Nodes[N - 1].x = x;
            Nodes[N - 1].y = y;
            Nodes[N - 1].color = Color.White;
        }

        public void AddEdge()  // добавить ребро
        {
            int n = -1; bool ok = false;
            int Ln = Nodes.Length;
            while ((n < Ln - 1) && !ok)
                ok = Nodes[++n] == SelectNode;

            int L = 0;
            if (SelectNodeBeg.Edge != null)
                L = SelectNodeBeg.Edge.Length;
            Array.Resize<TEdge>(ref SelectNodeBeg.Edge, ++L);
            SelectNodeBeg.Edge[L - 1].numNode = n;
            double a1 = SelectNodeBeg.x;
            double b1 = SelectNodeBeg.y;
            double a2 = SelectNode.x;
            double b2 = SelectNode.y;

            SelectNodeBeg.Edge[L - 1].A = (int)Math.Sqrt((a2 - a1) * (a2 - a1) + (b2 - b1) * (b2 - b1));
            SelectNodeBeg.Edge[L - 1].x1c = x1 - SelectNodeBeg.x;
            SelectNodeBeg.Edge[L - 1].x2c = x2 - SelectNode.x;
            SelectNodeBeg.Edge[L - 1].yc = (SelectNode.y + SelectNodeBeg.y) / 2;
            SelectNodeBeg.Edge[L - 1].color = Color.Silver;
        }

        public Node FindNode(int x, int y) // найти узел
        {
            int N = Nodes.Length;
            int i = -1;
            bool Ok = false;
            while ((i < N - 1) && !Ok)
            {
                i++;
                Ok = (Nodes[i].x - hx <= x) && (x <= Nodes[i].x + hx) &&
                     (Nodes[i].y - hy <= y) && (y <= Nodes[i].y + hy);
            }
            if (Ok) return Nodes[i]; else return null;
        }

        public void DeSelectEdge()
        {
            int N = Nodes.Length;
            for (int i = 0; i < N; i++)
            {
                if (Nodes[i].Edge != null)
                {
                    int L = Nodes[i].Edge.Length;
                    for (int j = 0; j < L; j++)
                        Nodes[i].Edge[j].select = false;
                }
            }
        }

        public void Draw(bool fl) // нарисовать
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Color cl = Color.FromArgb(255, 255, 255);
                g.Clear(cl);
                Pen MyPen = Pens.Black;

                SolidBrush MyBrush = (SolidBrush)Brushes.White;
                string s;
                int N = Nodes.Length;

                //Line
                for (int i = 0; i < N; i++)
                {
                    // Edge
                    if (Nodes[i].Edge != null)
                    {
                        int L = Nodes[i].Edge.Length;
                        MyBrush.Color = Color.White;



                        for (int j = 0; j < L; j++)
                        {
                            switch (typ_graph)
                            {
                                case Lib.TypeNode.ellipse:
                                    if (Nodes[i].Edge[j].select)
                                        MyPen = Pens.Red;
                                    else
                                        MyPen = new Pen(Nodes[i].Edge[j].color); // Pens.Black;
                                    int a1 = Nodes[i].x;
                                    int b1 = Nodes[i].y;
                                    int a2 = Nodes[Nodes[i].Edge[j].numNode].x;
                                    int b2 = Nodes[Nodes[i].Edge[j].numNode].y;
                                    g.DrawLine(MyPen, new Point(a1, b1), new Point(a2, b2));

                                    double a = Math.Atan2(b2 - b1, a2 - a1);
                                    double d = Math.Sqrt((b2 - b1) * (b2 - b1) + (a2 - a1) * (a2 - a1)) - 3;
                                    int x = (int)(a1 + (d - hy) * Math.Cos(a));
                                    int y = (int)(b1 + (d - hy) * Math.Sin(a));
                                    g.FillEllipse(Brushes.Black, x - 3, y - 3, 6, 6);

                                    s = Convert.ToString(Nodes[i].Edge[j].A);
                                    SizeF size = g.MeasureString(s, MyFont);
                                    if (Lib.graph.visibleA)
                                    {
                                        g.FillRectangle(Brushes.White, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                        g.DrawString(s, MyFont, Brushes.Black,
                                            (a1 + a2) / 2 - size.Width / 2,
                                            (b1 + b2) / 2 - size.Height / 2);
                                    }
                                    break;
                                case Lib.TypeNode.rectangle:
                                    a1 = Nodes[i].x + Nodes[i].Edge[j].x1c;
                                    b1 = Nodes[i].y;
                                    a2 = Nodes[Nodes[i].Edge[j].numNode].x + Nodes[i].Edge[j].x2c;
                                    b2 = Nodes[Nodes[i].Edge[j].numNode].y;

                                    if (Nodes[i].Edge[j].select)
                                        MyPen = Pens.Red;
                                    else
                                        MyPen = new Pen(Nodes[i].Edge[j].color); // Pens.Black;

                                    g.DrawLine(MyPen, new Point(a1, b1 + hy), new Point(a1, (b1 + b2) / 2));
                                    g.DrawLine(MyPen, new Point(a1, (b1 + b2) / 2), new Point(a2, (b1 + b2) / 2));
                                    g.DrawLine(MyPen, new Point(a2, (b1 + b2) / 2), new Point(a2, b2 - hy));

                                    s = Convert.ToString(Nodes[i].Edge[j].A);
                                    size = g.MeasureString(s, MyFont);
                                    if (Lib.graph.visibleA)
                                    { 
                                        g.FillRectangle(Brushes.White, (a1 + a2) / 2 - size.Width / 2, (b1 + b2) / 2 - size.Height / 2, size.Width, size.Height);
                                        g.DrawString(s, MyFont, Brushes.Black,
                                            (a1 + a2) / 2 - size.Width / 2,
                                            (b1 + b2) / 2 - size.Height / 2);
                                    }
                                    if (b1 < b2)
                                        g.FillEllipse(Brushes.Black, a2 - 3, b2 - hy - 3 - 3, 6, 6);
                                    else
                                        g.FillEllipse(Brushes.Black, a2 - 3, b2 + hy - 3 + 3, 6, 6);
                                    break;
                            }
                        }
                    }
                }

                if ((Edges != null) && !Lib.graph.visibleA)
                {
                    for (int i = 0; i < Edges.Length; i++)
                    {
                        s = "E[" + i + "] = " + Edges[i].n1 + "," + Edges[i].n2;
                        SizeF size = g.MeasureString(s, MyFont);
                        int a1 = Nodes[Edges[i].n1].x;
                        int b1 = Nodes[Edges[i].n1].y;
                        int a2 = Nodes[Edges[i].n2].x;
                        int b2 = Nodes[Edges[i].n2].y;
                        g.DrawString(s, MyFont, Brushes.Black,
                                                (a1 + a2) / 2 - size.Width / 2,
                                                (b1 + b2) / 2 - size.Height / 2);
                    }
                }
                // Nodes
                for (int i = 0; i < N; i++)
                {
                    if (Nodes[i] == SelectNode)
                        MyPen = Pens.Red;
                    else
                        MyPen = Pens.Silver;
                    if (Nodes[i].visit)
                        MyBrush.Color = Color.Silver;
                    else
                        if (Nodes[i] == SelectNode)
                        MyBrush.Color = Color.Yellow;
                    else
                        MyBrush.Color = Color.LightYellow;
                    switch (typ_graph)
                    {
                        case Lib.TypeNode.ellipse:
                            MyBrush.Color = Nodes[i].color;
                            g.FillEllipse(MyBrush, Nodes[i].x - hy, Nodes[i].y - hy, 2 * hy, 2 * hy);
                            g.DrawEllipse(Pens.Black, Nodes[i].x - hy, Nodes[i].y - hy, 2 * hy, 2 * hy);
                            s = Convert.ToString(i);
                            if ((Link != null) && !Lib.graph.visibleA)
                                s += ":" + Link[i];
                            SizeF size = g.MeasureString(s, MyFont);
                            g.DrawString(s, MyFont, Brushes.Black,
                                Nodes[i].x - size.Width / 2,
                                Nodes[i].y - size.Height / 2);
                            break;
                        case Lib.TypeNode.rectangle:
                            g.FillRectangle(MyBrush, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
                            g.DrawRectangle(MyPen, Nodes[i].x - hx, Nodes[i].y - hy, 2 * hx, 2 * hy);
                            s = Convert.ToString(Nodes[i].name);

                            size = g.MeasureString(s, MyFont);
                            g.DrawString(s, MyFont, Brushes.Black,
                                Nodes[i].x - size.Width / 2,
                                Nodes[i].y - size.Height / 2);
                            break;
                    }
                }
                if (fl)
                    g.DrawLine(MyPen, new Point(x1, y1), new Point(x2, y2));
            }
        }

        int DistLine(int u, int v, int x1, int y1, int x2, int y2)  // расстояние до линии
        {

            int A = y2 - y1;
            int B = -x2 + x1;
            int C = -x1 * A - y1 * B;
            int D = A * A + B * B;
            if (D != 0)
                return (int)(Math.Abs(A * u + B * v + C) / Math.Sqrt(D));
            else
                return 0;
        }

        public int FindLine(int x, int y, out int NumLine)  // найти ребро
        {
            int L = Nodes.Length;
            bool ok = false; int i = -1; NumLine = -1; int j = -1;
            while ((i < L - 1) && !ok)
            {
                i++;
                if (Nodes[i].Edge != null)
                {
                    int L1 = Nodes[i].Edge.Length; j = -1;
                    while ((j < L1 - 1) && !ok)
                    {
                        j++;
                        int a1 = Nodes[i].x;
                        int b1 = Nodes[i].y;
                        int a2 = Nodes[Nodes[i].Edge[j].numNode].x;
                        int b2 = Nodes[Nodes[i].Edge[j].numNode].y;
                        int u1 = Math.Min(a1, a2);
                        int u2 = Math.Max(a1, a2);
                        int v1 = Math.Min(b1, b2);
                        int v2 = Math.Max(b1, b2);
                        int Eps = 4;
                        ok = (u1 - Eps <= x) && (x <= u2 + Eps) && (v1 - Eps <= y) && (y <= v2 + Eps);
                        ok = (DistLine(x, y, a1, b1, a2, b2) <= Eps) && ok;
                    }
                }
            }
            if (ok)
            {
                NumLine = j;
                return i;
            }
            else
                return -1;
        }

        public void DelEdge(int NumNode, int NumEdge)  // удалить ребро
        {
            int L = Nodes[NumNode].Edge.Length;
            for (int i = NumEdge; i < L - 2; i++)
                Nodes[NumNode].Edge[i] = Nodes[NumNode].Edge[i + 1];
            Array.Resize<TEdge>(ref Nodes[NumNode].Edge, L - 1);
        }
    }
}
