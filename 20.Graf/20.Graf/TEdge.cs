using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _20.Graf
{
    public class TEdge
    {
        public int A;            // вес дуги
        public int numNode;      // № узла
        public int x1c, x2c, yc; // геометрия дуги
        public Color color;      // цвет
        public bool select;
    }
}
