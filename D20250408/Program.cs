using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250408
{
    internal class Program
    {

        static long K, N;
        static long minX = int.MaxValue;
        static long[] lan = new long[10000];

        static void Main(string[] args)
        {
            long[] inputs = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

            K = inputs[0];
            N = inputs[1];

            for (int i = 0; i < K; ++i)
            {
                lan[i] = long.Parse(Console.ReadLine());
                minX = Math.Min(minX, lan[i]);
            }

            long start = 1;
            long end = minX;

            long result = 0;
            while (start <= end)
            {
                long middle = (start + end) / 2;

                long sum = 0;
                for (int i = 0; i < K; ++i)
                {
                    sum += lan[i] / middle;

                }


                if (sum >= N)
                {
                    result = Math.Max(result, middle);
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            Console.WriteLine(result);

        }

    }
}
