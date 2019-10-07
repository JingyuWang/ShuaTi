using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;

namespace RoundOne
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[][]
            {
                new char[] { '1', '1' ,'0', '0', '0'},
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            };
            Queue<Index> queue = new Queue<Index>();
            int count = 0;
            for(int i = 0; i < board.Length; i++)
            {
                for (int j=0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '1')
                    {
                        Console.WriteLine("k is {0}: l is {1}", i, j);
                        count++;
                        Index po = new Index(i, j);
                        queue.Enqueue(po);
                        while (queue.Count > 0)
                        {
                            Index temp = queue.Dequeue();
                            //Console.WriteLine("Queue length is {0}", queue.Count);
                            int k = temp.X, l = temp.Y;
                            //Console.WriteLine("k is {0}: l is {1}", k, l);
                            board[k][l] = '2';
                            //Console.WriteLine(board[k][l]);

                            if (k + 1 < board.Length && board[k + 1][l] == '1')
                            {
                                queue.Enqueue(new Index(k + 1, l));
                                Console.WriteLine("#");
                            }                                
                            if (l + 1 < board[k].Length && board[k][l + 1] == '1') { 

                                queue.Enqueue(new Index(k, l + 1));
                                Console.WriteLine("##");
                            }
                            if (k - 1 >= 0 && board[k-1][l] == '1')
                            {
                                queue.Enqueue(new Index(k - 1, l));
                                Console.WriteLine("###");
                            }
                                
                            if (l - 1 >= 0 && board[k][l - 1] == '1')
                            {
                                queue.Enqueue(new Index(k, l - 1));
                                Console.WriteLine("####");
                            }
                               
                            Thread.Sleep(300);
                        }
                    }
                }
            }

            foreach(var item in board)
            {
                foreach(var s in item)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total island is {0}", count);
        }
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
