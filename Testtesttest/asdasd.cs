using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testtesttest
{

    internal class asdasd
    {

        static int N;
        static int M;
        static int[] arr;
        static int[] arr2;



        public static void asdf()
        {
            N = int.Parse(Console.ReadLine());

            arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            M = int.Parse(Console.ReadLine());
            arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);


            Array.Sort(arr);

            for (int i = 0; i < M; i++)
            {
                ArrReturn(arr, arr2[i]);
            }

        }

        static bool ArrReturn(int[] arr1, int key)
        {
            int start = 0;
            int end = arr1.Length;

            while (start < end)
            {

                int middle = (start + end) / 2;  // start + (end - start) * 0.5;

                if (arr1[middle] == key)
                {
                    Console.WriteLine(1);
                    return true;
                }
                else if (arr1[middle] > key)
                {
                    end = middle;
                }
                else if (arr1[middle] < key)
                {
                    start = middle + 1;
                }
            }
            Console.WriteLine(0);
            return false;
        }


    }
}
