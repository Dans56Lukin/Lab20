using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class Sortirovka
    {
        int N { get; set; }
        bool B { get; set; }
        public Sortirovka(int m, bool a)
        {
            N = m;
            B = a;
        }
        static Random rnd = new Random();

        public int SortBubl()
        {
            
            int[] b = new int[N];
            for (int i = 0; i < N; i++)
                b[i] = rnd.Next(100);
            int k = 0;
            int m = 0;
            for (int i = 1; i <= N - 1; i++)
                for (int j = N - 1; j >= i; j--)
                {
                    if (b[j - 1] > b[j])
                    {
                        k++;
                        int t = b[j - 1];
                        b[j - 1] = b[j];
                        b[j] = t;
                    }
                    m++;
                }
            if (B)
                return m;
            return k;
        }

        public int SortShaker()
        {
            
            int[] b = new int[N];
            for (int i = 0; i < N; i++)
                b[i] = rnd.Next(100);
            int k = 0;
            int m = 0;
            int left = 1, right = N - 1, last = right;
            do
            {
                for (int j = right; j >= left; j--)
                {
                    if (b[j - 1] > b[j])
                    {
                        k++;
                        int t = b[j - 1];
                        b[j - 1] = b[j];
                        b[j] = t;
                        last = j;
                    }
                    m++;
                }
                left = last;
                for (int j = left; j <= right; j++)
                {
                    if (b[j - 1] > b[j])
                    {
                        k++;
                        int t = b[j - 1];
                        b[j - 1] = b[j];
                        b[j] = t;
                        last = j;
                    }
                    m++;
                }
                right = last - 1;
            }
            while (left < right);
            if (B)
                return m;
            return k;
        }
    }
}
