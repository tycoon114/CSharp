namespace D20250428_2
{
    internal class Program
    {
        //연결되지 않음
        const int INF = 987654321;
        const int NoWay = -1;

        private static int[][] graph;

        static void ConstructGraph()
        {
            graph = new int[7][];

            graph[0] = new int[] { 0, 7, INF, INF, 3, 10, INF };
            graph[1] = new int[] { 7, 0, 4, 10, 2, 6, INF };
            graph[2] = new int[] { INF, 4, 0, 2, INF, INF, INF };
            graph[3] = new int[] { INF, 10, 2, 0, 11, 9, 4 };
            graph[4] = new int[] { 3, 2, INF, 11, 0, INF, 5 };
            graph[5] = new int[] { 10, 6, INF, 9, INF, 0, INF };
            graph[6] = new int[] { INF, INF, INF, 4, 5, INF, 0 };
        }

        public static void Main(string[] args)
        {
            ConstructGraph();
            int[] path = null;
            Console.WriteLine(GetDistance(0, 3, out path));

            int current = 3;
            int parent = path[current];

            while (true)
            {
                Console.WriteLine($"{current}  <- {path[current]}");
                current = path[current];

                if (current == path[current])
                {
                    Console.WriteLine($"{current}");
                    break;
                }
            }
        }

        //GetDistance : 최단 거리를 구하는 함수
        //입력 : 시작, 도착
        //출력 : 최단 거리
        public static int GetDistance(int start, int goal, out int[] path)
        {
            // 1. 시작에서 다른 모든 정점까지의 거리를 저장할 배열 생성
            // ㄴ 1.1 start에서 i 까지의 최단 거리
            int[] dist = new int[7];

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = INF;
            }
            dist[start] = 0;

            //path 배열 생성, 초기화
            //path[i] : start -> i 가는데 경유하는 정점
            path = new int[7];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = NoWay;
            }
            path[start] = start;

            // 2. 방문하지 않은 정점 중 dist가 최소인 정점을 찾기 위한 우선순위 큐를 생성한다.
            PriorityQueue<int, int> pq = new();
            pq.Enqueue(start, dist[start]);


            // 3. 모든 최단 경로를 찾을 때까지 반복
            while (pq.Count > 0)
            {
                // 3.1 다음에 방문할 정점을 우선순위 큐에서 가져온다.
                int next = pq.Dequeue();

                // 3.2 dist 배열 갱신
                for (int v = 0; v < graph[next].Length; v++)   //연결된 정점만 살펴본다.
                {
                    int disViaNext = dist[next] + graph[next][v];  //start에서 next -> v 로 가는 최단 거리 계산

                    //최단거리 비교
                    //ㄴ start -> next -> v가 더 짧다면 갱신하고,pq에 삽입
                    if (disViaNext < dist[v])
                    {
                        path[v] = next;
                        dist[v] = disViaNext;
                        pq.Enqueue(v, dist[v]);
                    }
                }
            }
            return dist[goal];
        }

    }
}
