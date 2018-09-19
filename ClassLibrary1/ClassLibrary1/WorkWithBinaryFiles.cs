using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL1
{
    public class WorkWithBinaryFiles
    {
        public string Text { get; set; }
        public string Path { get; set; }

        public WorkWithBinaryFiles(string filename)
        {
            Path = filename;
        }

        public string ReadFile()
        {
            using (FileStream fs = File.OpenRead(Path))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                Text = Encoding.Default.GetString(array);
            }
            return Text;
        }

        public void WriteFile(string text)
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(text);
                fs.Write(array, 0, array.Length);
            }
        }
    }
}
