using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace D20250421_3
{

    struct houseStruct
    {
        public int x;
        public int y;

        public houseStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    internal class Program
    {
        static int N, houseCount;
        static string[] Map = new string[25];
        static bool[,] isVisited = new bool[25, 25];


        static int[] dr = { 1, -1, 0, 0 };
        static int[] dc = { 0, 0, 1, -1 };

        static List<int> townSize = new List<int>();
        static void Main(string[] args)
        {

            N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Map[i] = Console.ReadLine();
            }

            //단지 -> 연결된 컴포넌트
            //그래프의 개수를 카운트

            //단지는 그래프 순회를 통해서 분리할 수 있다.

            //집-> 좌표 -> 행과 열
            //(1,1)
            int townCount = 0;
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    //단지가 구성할 때  갯수를 늘린다
                    //ㄴ집이 있고, 방문한 적이 없을때
                    if (Map[r][c] == '1' && isVisited[r, c] == false)
                    {
                        townCount++;
                        MakeTown(r, c);
                        townSize.Add(houseCount);
                    }
                    houseCount = 0;
                }

            }

            Console.WriteLine(townCount);
            townSize.Sort();
            for (int k = 0; k < townCount; k++)
            {
                Console.Write(townSize[k]);
            }
        }

        static void BFS(int x, int y)
        {
            //houseStruct start = new houseStruct(x, y);
            //Queue<houseStruct> bfsQueue = new Queue<houseStruct>();
            //bfsQueue.Enqueue(start);
            //isVisited[x, y] = true;

            //while (bfsQueue.Count > 0)
            //{
            //    houseStruct search = bfsQueue.Dequeue();

            //    //인접할 애들을 찾아서 탐색
            //    Map[y][x]
            //    if (isVisited[y, x] == true)
            //    {
            //        continue;
            //    }

            //    foreach (int neighbor in Map[])
            //    {

            //    }
            //}
        }

        static void MakeTown(int r, int c)
        {
            //기저 조건 - 방문 했다면 or 유효한 좌표인지
            //유효한 좌표값인지 먼저 확인
            if (r < 0 || r >= N || c < 0 || c >= N)
            {
                return;
            }
            // 방문한 좌표인지 확인
            if (isVisited[r, c] == true)
            {
                return;
            }
            //집이 존재하는지 확인
            if (Map[r][c] != '1')
            {
                return;
            }
            isVisited[r, c] = true;
            houseCount++;
            //윗집
            MakeTown(r - 1, c);
            //아래
            MakeTown(r + 1, c);
            //왼
            MakeTown(r, c - 1);
            //오른
            MakeTown(r, c + 1);
        }

    }
}
