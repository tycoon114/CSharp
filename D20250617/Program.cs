
using System.Text;

namespace D20250617
{
    public class Program
    {
        static int N, M;
        static int[] Arr, Arr2;


        public static readonly StreamReader input = new(new
            BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new
            BufferedStream(Console.OpenStandardOutput()));
        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            N = inputs[0];
            M = inputs[1];

            //6개 1개
            //6a + b = N  a는 묶음으로 사는 개수 b 는 낱개
            //묶음 중 가장 싼거 찾고 N보다 작은 수중 최댓값을 a
            // 낱개중 가장 싼거를 찾고 b
            //해서 둘이 가격 합한거 출력

            for(int i = 0; i < M; i++)
            {
                int[] guitar = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                Arr[i] = guitar[0];
                Arr2[i] = guitar[1];
            }

            Array.Sort(Arr);
            Array.Sort(Arr2);

            output.Flush();
        }
    }
}