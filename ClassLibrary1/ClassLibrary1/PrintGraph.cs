using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class PrintGraph
    {
        public static List<string> PrintAllPoints(DekstraAlgoritm da)
        {
            List<string> retListOfPoints = new List<string>();
            foreach (Point p in da.points)
            {
                retListOfPoints.Add(string.Format("до {0} равно {1}", p.Name, p.ValueMetka));
            }
            return retListOfPoints;
        }
    }
}
