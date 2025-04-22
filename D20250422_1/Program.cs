using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace D20250422_1
{
    internal class Program
    {
        static int N, K, Count;
        static void Main(string[] args)
        {
            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            N = inputArr[0];        //  수빈의 위치
            K = inputArr[1];        //  동생의 위치


            //입력 받은 값N 부터 시작
            //그래프를 어떻게 그릴까
            //임의의 배열? arr[]가 있다면
            //첫번째에 N-1, N+1, N*2 -> arr[0], [1] ,[2]

            //그래프는 만들어 둘 필요 없이 BFS에서 값을 비교해 가며 만들면 될듯

            bool[] isVisited = new bool[100001];
            //다음에 방문할 정점을 기록할 컨테이너 생성 - 큐를 생성
            Queue<int> bfsQueue = new Queue<int>();
            //시작 정점을 큐에 삽입 하고 
            bfsQueue.Enqueue(N);
            //방문을 기록한다.
            isVisited[N] = true;


            int second = 0;

            //탐색 시작

            //우선 동생을 찾자
            while (bfsQueue.Count > 0)
            {
                //여기서  카운트
                int lineCount = bfsQueue.Count;
                bool isFound = false;
                for (int i = 0; i < lineCount; i++)
                {
                    // 1. 우선 다음 방문할 정점을 가져온다
                    int current = bfsQueue.Dequeue();

                    // 2. 동생이 있다면 탐색 종료
                    if (current == K)
                    {
                        Console.WriteLine("끝");
                        isFound = true;
                        break;
                    }
                    // 2-1. 방문

                    //isvisit 을 true로
                    isVisited[current] = true;

                    //  여기서 시간 증가? -X : 이렇게 하면 정점의 수를 카운트 하게됨


                    // 3. 없다면 계속 탐색
                    // 3-1. 앞으로
                    {
                        int next = current + 1;
                        //다음 정점이 유효한지 확인
                        //방문여부
                        if (next <= 100000 || isVisited[next] == false)
                        {
                            bfsQueue.Enqueue(next);
                        }
                        
                    }
                    // 3-2. 뒤로
                    {
                        int next = current - 1;

                        if (next >= 0 || isVisited[next] == false)
                        {
                            bfsQueue.Enqueue(next);
                        }
                   
                    }

                    // 3-3. 순간 이동 ( *2)
                    {
                        int next = current * 2;
                        if (next <= 100000 || isVisited[next] == false)
                        {
                            bfsQueue.Enqueue(next);
                        }
                    }
                }
                if (isFound)
                {
                    break;
                }
                ++second;
            }

            Console.WriteLine(second);

        }
    }
}
