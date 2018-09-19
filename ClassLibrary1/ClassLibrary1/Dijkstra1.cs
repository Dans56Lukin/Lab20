using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class Dijkstra1
    {
        public List<string> Result(int k, int N, int[][] arr)
        {
            Point[] v = new Point[N];
            for (int i = 0; i < N; i++) 
            {
                if (i == k)
                    v[i] = new Point(0, false, Convert.ToString(i));
                else
                    v[i] = new Point(9999, false, Convert.ToString(i));
            }
            int M = arr.Length;
            Rebro[] rebras = new Rebro[M];
            for (int i = 0; i < M; i++)
            {
                rebras[i] = new Rebro(v[arr[i][0]], v[arr[i][1]], arr[i][2]);
            }
            DekstraAlgoritm da = new DekstraAlgoritm(v, rebras);
            da.AlgoritmRun(v[k]);
            List<string> b = PrintGraph.PrintAllPoints(da);
            return b;
        }
    }
}
