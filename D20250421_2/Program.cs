using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250421_2
{
    internal class Program
    {
        static int computer, node;
        static bool[] isVisited = new bool[101];

        static List<int>[] virusList = new List<int>[101];

        //static int answer = 0;

        static void Main(string[] args)
        {
            computer = int.Parse(Console.ReadLine());      //존재하는 컴퓨터 개수
            node = int.Parse(Console.ReadLine());          //연결된 컴퓨터 개수


            for (int i = 1; i <= computer; i++)
            {
                virusList[i] = new List<int>();
            }

            for (int i = 0; i < node; i++)
            {
                int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                virusList[inputArr[0]].Add(inputArr[1]);
                virusList[inputArr[1]].Add(inputArr[0]);
            }
            // 그래프 생성


            

           
            Console.WriteLine(DFS(1) - 1);

        }

        static int DFS(int computer)
        {
            int answer = 1;
            //방문 했다면?
            if (isVisited[computer])
            {
                //return 0;
            }
      
            isVisited[computer] = true;
                

            
            foreach (int i in virusList[computer])
            {
                if (isVisited[i] == false)
                {
                   answer+= DFS(i);
                }
            }
            return answer;

        }

    }
}
