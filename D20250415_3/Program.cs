using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250415_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int>[] neighbors = new List<int>[7];
            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = new List<int>();
            }


            neighbors[0].Add(1);

            neighbors[1].Add(0);
            neighbors[1].Add(2);
            neighbors[1].Add(3);

            neighbors[2].Add(1);
            neighbors[2].Add(5);
            neighbors[2].Add(6);

            neighbors[3].Add(1);
            neighbors[3].Add(4);
            neighbors[3].Add(5);

            neighbors[4].Add(3);

            neighbors[5].Add(2);
            neighbors[5].Add(3);

            neighbors[6].Add(2);

            //BFS 구현

            //각 정점 마다 방문 여부를 기록한다.
            bool[] isVisited = new bool[7];

            //스택 생성
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(0);


            //모든 정점을 방문할 때까지 반복
            while (qu.Count > 0)
            {
                //다음에 방문할 정점을 가져온다.
                int vertexToVisit = qu.Dequeue();

                //이미 방문 했다면 방문 하지 않는다
                if (isVisited[vertexToVisit])
                {
                    continue;
                }


                //방문 여부를 기록한다.
                Console.Write($"{vertexToVisit}  -> ");
                isVisited[vertexToVisit] = true;

                //주변 노드를 방문한다.
                foreach (int neighbor in neighbors[vertexToVisit])
                {
                    //방문하지 않은 정점만 스택에 추가한다.
                    if (isVisited[neighbor] == false)
                    {
                        qu.Enqueue(neighbor);
                    }
                }


            }
        }
    }
}
