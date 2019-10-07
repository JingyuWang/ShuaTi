using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class _200
    {
        public static int NumIslands(char[][] grid)
        {
            int count = 0;
            for(int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        Queue<Index> q = new Queue<Index>();
                        q.Enqueue(new Index(i, j));
                        while (q.Count > 0)
                        {
                            Index temp = q.Dequeue();
                            int k = temp.X, l = temp.Y;
                            grid[k][l] = '2';
                            if (k + 1 < grid.Length && grid[k + 1][l] == '1')
                            {
                                q.Enqueue(new Index(k + 1, l));
                                Console.WriteLine("#");
                            }
                            if (l + 1 < grid[k].Length && grid[k][l + 1] == '1')
                            {

                                q.Enqueue(new Index(k, l + 1));
                                Console.WriteLine("##");
                            }
                            if (k - 1 >= 0 && grid[k - 1][l] == '1')
                            {
                                q.Enqueue(new Index(k - 1, l));
                                Console.WriteLine("###");
                            }

                            if (l - 1 >= 0 && grid[k][l - 1] == '1')
                            {
                                q.Enqueue(new Index(k, l - 1));
                                Console.WriteLine("####");
                            }
                        }
                    }
                }
            }

            return count;
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
    }
}


/*
 Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
 An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
 You may assume all four edges of the grid are all surrounded by water.

Example 1:

Input:
11110
11010
11000
00000

Output: 1

Example 2:

Input:
11000
11000
00100
00011

Output: 3*/
