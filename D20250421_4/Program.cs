using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250421_4
{
    internal class Program
    {
        static int N, M, R;
        static int[] visited;
        static int order = 1;
        static void Main(string[] args)
        {
            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = inputArr[0];        //정점의 개수
            M = inputArr[1];        //간선의 개수
            R = inputArr[2];        //정점의 시작
            List<int>[] bfsList = new List<int>[N + 1];

            for (int i = 0; i < N; i++)
            {
                bfsList[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                int[] inputArr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                bfsList[inputArr2[0]].Add(inputArr2[1]);
                bfsList[inputArr2[1]].Add(inputArr2[0]);
            }

            for (int i = 0; i < N; i++)
            {
                bfsList[i].Sort();
            }

            visited = new int[N + 1];
            bfs(R, bfsList);

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(visited[i]);
            }


        }

        static void bfs(int start, List<int>[] V)
        {
            Queue<int> bfsQueue = new Queue<int>();
            bfsQueue.Enqueue(start);
            visited[start] = order++;
            while (bfsQueue.Count > 0)
            {
                int nextVertex = bfsQueue.Dequeue();

                foreach (int v in V[nextVertex])
                {
                    if (visited[v] == 0)
                    {
                        visited[v] = order++;
                        bfsQueue.Enqueue(v);
                    }
                }

            }

        }

    }
}
