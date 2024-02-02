using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest.Util
{
    public class FileToLineArray
    {

        public static string[] ReadFile(string path)
        {
            var lines = File.ReadAllLines(path);
            List<string> LinesResult = new List<string>();
            foreach (string line in lines)
            {
                LinesResult.Add(line);
                

            }

            return LinesResult.ToArray();

        }
    }
}
