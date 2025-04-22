using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace D20250422_3
{
    internal class Program
    {

        //각 노드의 부모는 누구인가?
        //트리의 부모는 하나라는 성질을 이용해서 풀이
        //순차 : 배열
        //연결 : 노드

        //노드의 식별은 번호로 할 수 있다. [1,N] => 순차 자료 구조
        //노드의 타입은? 
        //ㄴ어떤 데이터가 모여야 노드라고 정의?
        //ㄴ자식 노드, 부모 노드


        static int[] parent = new int[100001];
        static int N;
        static bool[] isVisited = new bool[100001];

        static List<int>[] graph = new List<int>[100001];
        static void Main(string[] args)
        {
            //트리를 구성
            //인접 리스트
            //양방향

            N = int.Parse(Console.ReadLine());

            for (int i = 1; i < N; i++)
            {
                graph[i] = new List<int>();

            }

            for (int i = 0; i <= N; i++)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int u = arr[0];
                int v = arr[1];

                graph[u].Add(v);
                graph[v].Add(u);
            }

            SetParent(1);

            //부모를 설정하는 로직
            //부모는 자기 자식한테 자신이 부모라는 것을 알려줄 수 있다.

            //parent[2]에 2의 부모 값이 들어간다.

            //모든 노드 마다 자식에게 본인이 부모라는 것을 알려준다.
            // 모든 노드마다 parent[child] = node


            for (int node = 2; node <= N; node++)
            {
                Console.Write(parent[node]);
            }


        }

        //DFS
        //입력 : 노드
        //출력할것은 없음
        static void SetParent(int node)
        {
            //현재 노드 방문 체크,
            isVisited[node] = true;

            foreach (int child in graph[node])
            {
                if (isVisited[child] == false)
                {
                    parent[child] = child;
                    SetParent(child);
                }
            }


        }

    }
}
