using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class WorkwithOchered
    {
        Queue<int> que = new Queue<int>();
        public string Sozdanie()
        {
            string s = "";
            que.Clear();
            int x;
            Random ran = new Random();
            for (int i = 0; i < 20; i++)
            {
                x = ran.Next(-50, 51);
                que.Enqueue(x);
                s = s + " " + x;
            }
            return s;
        }

        public string Udalenie()
        {
            return que.Delete();
        }
    }
}
