using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class FileHandler
    {
        public static string[] ReadFileAsStrArr(string path)
        {
            var text = File.ReadAllText(path);
            var strArr = text.Split(new string[] { "\n", " " }, StringSplitOptions.RemoveEmptyEntries);
            return strArr;
        }
    }
}
