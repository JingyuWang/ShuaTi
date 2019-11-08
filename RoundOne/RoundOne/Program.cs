using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using RoundOne.Zhongdeng;

namespace RoundOne
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inp = "3[a]";
            Console.WriteLine(DecodeString(inp));

        }
        //-------------------------------------------------------
        public static string DecodeString(string s)
        {
            return helper(1, s);
        }
        public static string helper(int n, string sub)
        {
            if (!sub.Contains('['))
                return repeat(n, sub);
            int start = -1;//number start index  ab2[d],  2[d]
            int end = sub.IndexOf('[');// index of '['

            string pre = sub.Substring(0, end);//ab2[d] or 2[d]
            string rest = sub.Substring(end + 1, sub.Length - end - 2);

            for (int i = 0; i < pre.Length; i++)
            {
                if (Char.IsDigit(pre[i]))
                {
                    start = i;
                    break;
                }
            }

            if (start != -1)
            {//means have head
                string head = pre.Substring(0, start);
                int num = Convert.ToInt32(pre.Substring(start, end - start));
                return head + helper(num, rest);
            }
            else
            {
                int num = Convert.ToInt32(pre);
                return helper(num, rest);
            }

        }
        public static string repeat(int n, string s)
        {
            return new StringBuilder(s.Length * n).AppendJoin(s, new string[n + 1]).ToString();
        }
        //-------------------------------------------------------
        public class Index
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Index(int a, int b)
            {
                X = a;
                Y = b;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>string array</returns>
        public static string[] GetStringListFromString(string t)
        {
            var dd = t.Replace("[", string.Empty).Replace("]",string.Empty).Replace(" ", string.Empty);
            return dd.Split(",");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>int array</returns>
        public static int[] GetIntListFromString(string t)
        {
            try
            {
                var dd = t.Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty);
                return Array.ConvertAll(dd.Split(","), int.Parse);
            }
            catch
            {
                Console.WriteLine("Convertion error.");
                return null;
            }

        }
    }
}
