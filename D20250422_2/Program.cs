using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250422_2
{
    internal class Program
    {
        static int N, M, dayCount;
        static string[] tomatoBox = new string[1024];   //입력 받을 토마토

        static int[] bx = { 0, 0, -1, 1 };  // 좌우
        static int[] by = { -1, 1, 0, 0 };  // 상하

        static List<int> startTomato = new List<int>();     //시작 정점

        static void Main(string[] args)
        {
            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = inputArr[0];    // 토마토 상자의 가로
            M = inputArr[1];    // 토마토 상자의 세로

            bool[,] isVisited = new bool[N, M];

            //M 값 만큼 Map을 받는다.
            for (int i = 0; i < M; i++)
            {
                tomatoBox[i] = Console.ReadLine();
            }

            //익은 토마토가 담겨있는 위치를 찾는다 -> 시작 정점을 찾자
            //시작 정점은 하나 이상 있다.
            //시작 정점들은 어디에 담을까?
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (tomatoBox[j][i] == '1')
                    {
                        isVisited[j,i] = true;
                    }
                }

            }



            //그 다음 익지 않은 토마토가 있는 위치들을 찾는다?
            //각 익지 않은 토마토는 방문 할 정점



            //모든 순회가 돌고 isVisited가 하나라도 0이면 -1출력
        }
    }
}
