using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RoundOne.Zhongdeng
{
    public static class Solution
    {
        public static char[][] UpdateBoard(char[][] board, int[] click)
        {
            int x = click[0];
            int y = click[1];
            if (board[x][y] == 'M')
            {
                board[x][y] = 'X';
            }
            if (board[x][y] == 'E')
            {
                Flip(board, x, y);
            }
            return board;
        }

        public static void Flip(char[][] board, int x, int y)
        {
            int count = 0;
            for(int i=-1; i <= 1; i++)
            {
                for (int j=-1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int r = x + i, c = y + j;
                    if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) continue;
                    if (board[r][c] == 'M')
                        count++;
                }
            }
            Console.WriteLine("X is {0}, Y is {1}", x,y);
            foreach (var item in board)
            {
                foreach (var it in item)
                {
                    Console.Write(it);
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------");
            Thread.Sleep(3000);
            if (count == 0)
            {
                board[x][y] = 'B';
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        int r = x + i, c = y + j;
                        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length) continue;
                        if (board[r][c]=='E')
                            Flip(board, r, c);
                    }
                }
            }
            else
            {
                board[x][y] = (char)(count + 48);
            }
        }
    }
}
