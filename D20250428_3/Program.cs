namespace D20250428_3
{
    internal class Program
    {


        public static void Main(string[] args)
        {
            ConstructMap();

            int path;
            //path[i] : start ->i 가는데 경유한 정점
            //start : 0

        }

        const int MAX_Y = 10;
        const int MAX_X = 10;
        static char[][] map = new char[MAX_Y][];

        // 정점 : 좌표 => X,Y
        static int startX, startY, endX, endY;
        //FindStartAndEnd() : 시작 지점과 도착 지점을 찾는 함수

        public static void FindStartAndEnd()
        {
            for (int y = 0; y < MAX_X; y++)
            {
                for (int x = 0; x < MAX_Y; x++)
                {
                    if (map[y][x].Equals("S"))
                    {
                        startX = x;
                        startY = y;
                    }
                    else if (map[y][x].Equals("G"))
                    {
                        endX = x;
                        endY = y;
                    }
                }
            }
        }


        // 맵을 구성한다.
        static void ConstructMap()
        {
            map[0] = "          ".ToCharArray();
            map[1] = "          ".ToCharArray();
            map[2] = "          ".ToCharArray();
            map[3] = "    #     ".ToCharArray();
            map[4] = " S  #  G  ".ToCharArray();
            map[5] = "    #     ".ToCharArray();
            map[6] = "          ".ToCharArray();
            map[7] = "          ".ToCharArray();
            map[8] = "          ".ToCharArray();
            map[9] = "          ".ToCharArray();
        }


        static void PrintMap()
        {

        }

        class AStarNode
        {
            public int X;
            public int Y;
            public int F;
            public AStarNode Path;
        }

        //GetHeuristic : 휴리스틱을 구하는 함수 => 맨해튼 거리
        // 입력 : 좌표 2개 
        static public int GetHeuristic(int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);

            return dx + dy;

        }


        static void SetPath()
        {
            //경로 생성
            AStarNode[,] path = new AStarNode[MAX_Y, MAX_X]; //맵과 대응되는 path 객체

            for (int x = 0; x < MAX_X; x++)
            {
                for (int y = 0; y < MAX_Y; y++)
                {
                    path[y, x] = new AStarNode() { X = x, Y = y };
                }
            }

            //우선순위 큐
            // 원소 : 노드
            // 우선순위 : F값
            PriorityQueue<AStarNode, int> pq = new();
            pq.Enqueue(path[startY, startX], 0);

            //8방향 탐색
            int[] dy = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] dx = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] dg = { 14, 10, 14, 10, 14, 10, 14, 10 };

            //경로를 찾을 때까지 반복
            while (pq.Count > 0)
            {
                // 1. 다음에 방문할 정점을 가져온다.
                AStarNode next = pq.Dequeue();
                // 2. 8방향으로 탐색 진행
                for (int i = 0; i < 8; i++)
                {
                    int nx = next.X + dx[i];
                    int ny = next.Y + dy[i];

                    //유효성 검사
                    //nx : 0 ~  MAX_X, ny : 0 ~ MAX_Y
                    if (nx < 0 || nx >= MAX_X || ny < 0 || ny > MAX_Y)
                    {
                        continue;
                    }
                    //이동 가능 한가?
                    if (map[ny][nx] == '#')
                    {
                        continue;
                    }
                    // ㄴ 2.1 부분 최단 경로를 찾아 큐에 삽입

                    int f = dg[i] + 10 * GetHeuristic(nx, ny, endX, endY);
                    AStarNode newNode = path[ny, nx];

                    if (newNode.F > f)
                    {
                        newNode.F = f;
                        newNode.Path = next;
                        pq.Enqueue(newNode, newNode.F);
                    }
                }
            }

            //맵에 경로 표시
            AStarNode current = path[endY, endX].Path;
            while
        }

    }
}
