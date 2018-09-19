using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Graf
{
    public class Lib
    {
            public static Graph graph;     // граф
            public static int NumNode;     // № узла
            public static int Num;
            public static MyStack myStack; // стек
            public static MyStack path;
            public static int[] arrPath = new int[100];
           public static List<PathGam> pathsGam = new List<PathGam>();

        public enum TypeNode
        {
            ellipse = 0,
            rectangle = 1
        }
    }
}
