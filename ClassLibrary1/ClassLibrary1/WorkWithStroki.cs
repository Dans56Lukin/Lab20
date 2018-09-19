using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class WorkWithStroki
    {
        public string T { get; set; }
        public WorkWithStroki(string s)
        {
            T = s;
        }

        public List<string> SpisokSlov()
        {
            List<string> list = new List<string>();
            list.Add("");

            string[] arr = T.Split(' ', '\r');
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i].Length > list[0].Length)
                {
                    list.Clear();
                    list.Add(arr[i]);
                }
                else if (arr[i].Length == list[0].Length)
                {
                    list.Add(arr[i]);
                }
            }
            return list;
        }

        public string KatoeSlovo(int i)
        {
            List<string> list = SpisokSlov();
            return list[i];
        }

        public string Number()
        {
            List<string> list = SpisokSlov();
            return Convert.ToString(list.Count);
        }

        public string FirstOrLastSlovo(bool isFirst)
        {
            List<string> list = SpisokSlov();
            if (isFirst)
            {
                return list[0];
            }
            else
            {
                return list[list.Count - 1];
            }
        }
    }
}
