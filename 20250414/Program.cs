using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250414
{
    internal class Program
    {
        static int N;
        static int K;
        static int MaxQueueSize;



        static string inputString;
        static Queue<long> qu = new Queue<long>();


        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            MaxQueueSize = N;


            for (int i = 1; i <= N; i++)
            {
                qu.Enqueue(i);
}

            while (qu.Count > 1)
            {
                qu.Dequeue();
                qu.Enqueue(qu.Dequeue());
            }
            Console.Write(qu.Dequeue());

        }
    }
}

