using System;
using System.Collections.Generic;
using System.IO;

namespace _20250611
{
    public class Program
    {
        static int K, N;
        static HashSet<string> ASet = new HashSet<string>();

        public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput()));

        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            K = inputs[0];
            N = inputs[1];

            for (int i = 0; i < K; ++i)
            {
                ASet.Add(input.ReadLine());
            }

            int ans = 0;
            for (int i = 0; i < N; ++i)
            {
                string B = input.ReadLine();
                if (ASet.Contains(B))
                {
                    ans++;
                }
            }

            output.Write(ans);
            output.Flush();
        }
    }
}
