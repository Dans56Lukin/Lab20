using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class Dijkstra2
    {
        public int[][] arr1 { get; set; }
        bool[] arr2 { get; set; }
        int Z;

        public void Result(int l, int N, int[][] arr)
        {
            Z = l;
            arr1 = new int[N][];
            arr2 = new bool[N];
            for (int i = 0; i < N; i++)
            {
                arr1[i] = new int[N];
            }
            for (int i = 0; i < N; i++)
            {
                arr2[i] = true;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (i == j)
                        {
                            arr1[i][j] = 9999;
                            break;
                        }
                        if ((arr[k][0] == i && arr[k][1] == j) || (arr[k][0] == j && arr[k][1] == i))
                        {
                            arr1[i][j] = arr[k][2];
                            arr1[j][i] = arr[k][2];
                            break;
                        }
                        if (arr1[i][j] == 0)
                        {
                            arr1[i][j] = 9999;
                        }
                    }
                }
            }
            Dijk(l);
            Proverka(l);
        }

        void Dijk(int n)
        {
            int min = Min(arr1[Z], out int index);
            if (arr2[index])
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    int k = min + arr1[index][i];
                    if (k < arr1[Z][i] && n != i)
                        arr1[Z][i] = k;
                }
                arr2[index] = false;
                Dijk(index);
            }
        }

        int Min(int[] n, out int m)
        {
            int min = n[0];
            m = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (arr2[i] && min > n[i])
                {
                    min = n[i];
                    m = i;
                }
            }
            return min;
        }

        void Proverka(int n)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[n][i] == 9999 && i != n)
                {
                    int k = 0;
                    for (int j = 0; j < arr1.Length; j++)
                    {
                        if (arr1[i][j] < 9999 && k == 0)
                            k = j;
                        if (arr1[n][j] < arr1[n][k] && arr1[i][j] < 9999)
                            k = j;
                        if (j == arr1.Length - 1)
                            arr1[n][i] = arr1[n][k] + arr1[i][k];
                    }
                }
            }
        }
    }
}
