using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _20.Graf
{
    public class Node
    {
        public string name;  // 4+4*Name.Length
        public TEdge[] Edge; // 4+L2*(5*4) - ребра
        public bool visit;
        public int x, y;     // 4+4
        public int numVisit; // № визита
        public Color color;  // цвет
    }
}
