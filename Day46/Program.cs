using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day46
{
    internal class Program
    {

        static long[] memo = new long[100];

        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------------");
            //CountNum(k,6);
            Console.WriteLine(Fibo1(k));
        }


        //static void CountNum(int num, int maxCount) {
        //    Console.Write(num);
        //    if ((maxCount < 0))
        //        return;
        //    Console.WriteLine("");
        //    num++;
        //    maxCount--;
        //    CountNum(num,maxCount);
        //}

        static int Fibo1(int n)
        {

            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            
            return Fibo1(n - 2) + Fibo1(n - 1);
        }



    }
}
