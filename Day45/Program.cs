using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LotteGiants(1);
            //Pivo(10);
            double k =1;
            for (int i = 11; i > 1; i--) {
                k = k * i;
            }
            Console.WriteLine(k);
            LotteGiants(1);

        }

        static void LotteGiants(int num)
        {
            Starrr(num);
            num += 1;

            if (num == 5)
            {
                return;
            }

            Console.WriteLine("");
            LotteGiants(num);

        }

        static void Starrr(int star)
        {
            if (star == 0)
            {
                return;
            }
            Console.Write("*");
            Starrr(star - 1);
        }




    }
}
