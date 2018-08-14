using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyIO
{
   public class In
    {
       /// <summary>
       /// 读取英文单词
       /// </summary>
       /// <param name="filePath"></param>
       /// <returns></returns>
        public static string[] ReadEnWords(string filePath)
        {
            string file = File.ReadAllText(filePath);
            //[^a-zA-Z]|\\S 错了
            //以下方法未去除换行符
            //file = Regex.Replace(file, "[^a-zA-Z\\s]", "");
            //这才是正确的 空格即为 " "
            file = Regex.Replace(file, "[^a-zA-Z ]", "");
            return file.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }
        /// <summary>
        /// 读取int数组
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int[] ReadInts(string filePath)
        {
            string file = File.ReadAllText(filePath);
            file =   Regex.Replace(file, "[^0-9 ]", " ");
            string[] strs = file.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] ins = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                ins[i] = int.Parse(strs[i]);
            }
            return ins;
        }
    }
}
