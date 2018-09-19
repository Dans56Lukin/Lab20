using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class WorkWithNumber
    {
        public string T { get; set; }
        public WorkWithNumber(string s)
        {
            T = s;
        }

        public string SpisokDlinSeriy()
        {
            string[] arr1 = T.Split(' ');
            int[] arr = new int[arr1.Length];
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr[i] = Convert.ToInt32(arr1[i]);
            }
            int m;
            int k;
            string s = "";
            for (int i = 0; i < arr.Length - 2; i++)
            {
                m = 1;
                if (arr[i] < arr[i + 1])
                    for (k = i; arr[k] < arr[k + 1] && k < arr.Length - 2; k++)
                    {
                        m++;
                        i = k;
                    }
                if (arr[i] == arr[i + 1])
                    for (k = i; arr[k] == arr[k + 1] && k < arr.Length - 2; k++)
                    {
                        m++;
                        i = k;
                    }
                if (arr[i] > arr[i + 1])
                    for (k = i; arr[k] > arr[k + 1] && k < arr.Length - 2; k++)
                    {
                        m++;
                        i = k;
                    }
                if (i == arr.Length - 3)
                    m++;
                s = s + " " + m;
            }
            return s;
        }
    }
}
