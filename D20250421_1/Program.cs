using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D20250421_1
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
            List<int>[] dfsList = new List<int>[N+1];

            for (int i = 0; i < N; i++)
            {
                dfsList[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                int[] inputArr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                dfsList[inputArr2[0]].Add(inputArr2[1]);
                dfsList[inputArr2[1]].Add(inputArr2[0]);
            }

            for (int i = 0; i < N; i++)
            {
                dfsList[i].Sort();
            }

            visited = new int[N + 1];
            DFS(R, dfsList);

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(visited[i]);
            }
        }
        static void DFS(int R, List<int>[] V)
        {
            visited[R] = order++;

            foreach (int neighbor in V[R])
            {
                if (visited[neighbor] == 0)
                {
                    DFS(neighbor, V);
                }
            }
        }


    }
}
