using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250415_2
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

            //DFS 구현

            //각 정점 마다 방문 여부를 기록한다.
            bool[] isVisited = new bool[7];
            dfs(0,isVisited,neighbors);
        }

        //정점(vertexToVisit)을 방문 하는 일
        static void dfs(int vertexToVisit, bool[] isVisited, List<int>[] neighbors)
        {

            //이미 방문 했다면 방문 하지 않는다
            if (isVisited[vertexToVisit])
            {
                return;
            }

            //방문 여부를 기록한다.
            Console.Write($"{vertexToVisit}  -> ");
            isVisited[vertexToVisit] = true;

            //주변 노드를 방문한다.
            foreach (int neighbor in neighbors[vertexToVisit])
            {
                if (isVisited[neighbor] == false)
                {
                    //암시적인 스택에 넣는다.
                    dfs(neighbor, isVisited, neighbors);
                }

            }
        }
    }
}
