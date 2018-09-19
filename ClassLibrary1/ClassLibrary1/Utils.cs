using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL1
{
    public class Utils
    {
        public string S { get; set; }
        public string Path { get; set; }

        public Utils(string filename)
        {
            Path = filename;
        }

        public string ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(Path, Encoding.GetEncoding(1251)))
            {
                S = sr.ReadToEnd();
            }
            return S;
        }
    }
}
