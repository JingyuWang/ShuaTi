using System;
using System.Collections.Generic;
using System.Text;

namespace RoundOne.Zhongdeng
{
    public class TicTacToe
    {
        public int num = 0;
        public Dictionary<int, double> dic;
        
        public TicTacToe(int n)
        {
            dic = new Dictionary<int, double>();
            //step = new Dictionary<int, int>();
            num = n;
        }

        public int Move(int row, int col, int player)
        {
            double heng = 0.0;
            double shu = 0.0;
            double zuoxie = 0.0;
            double youxie = 0.0;
            //--x axis--
            if (dic.ContainsKey(row))
            {
                dic[row] += player - 1.5;
                //Console.WriteLine("-");
                heng = dic[row];
            }
            else
            {
                dic.Add(row, player - 1.5);
                //Console.WriteLine("-");
            }

            //--y axis--
            if (dic.ContainsKey(col + num))
            {
                dic[col + num] += player - 1.5;
                //Console.WriteLine("|");
                shu = dic[col + num];
            }
            else
            {
                dic.Add(col + num, player - 1.5);
                //Console.WriteLine("|");
            }

            // diag
            if (row == col)
            {
                if (dic.ContainsKey(2 * num))
                {
                    dic[2 * num] += player - 1.5;
                    //Console.WriteLine("x?");
                    zuoxie = dic[2 * num];
                }
                else
                {
                    dic.Add(2 * num, player - 1.5);
                    //Console.WriteLine("\");
                }

            }
            if (row + col == num - 1)
            {
                if (dic.ContainsKey(2 * num + 1))
                {
                    dic[2 * num + 1] += player - 1.5;
                    //Console.WriteLine("/");
                    youxie = dic[2 * num + 1];
                    //return (dic[2 * num + 1] == num * 0.5 || dic[2 * num + 1] == -num * 0.5) ? player : 0;
                }
                else
                {
                    dic.Add(2 * num + 1, player - 1.5);
                    Console.WriteLine("/");
                }
            }
            Console.WriteLine("what?{0}",player);
            double res = num * 0.5;
            return (Math.Abs(heng) == res ||  Math.Abs(shu) == res ||  Math.Abs(zuoxie) == res ||  Math.Abs(youxie) == res)? player: 0;
        }
        public Dictionary<int,double> GetDic(){
            return dic;
        }
    }
}
