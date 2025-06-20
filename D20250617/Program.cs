
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

            Arr = new int[M];
            Arr2 = new int[M];

            for (int i = 0; i <M; i++)
            {
                int[] guitar = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
                Arr[i] = guitar[0];
                Arr2[i] = guitar[1];
            }

            Array.Sort(Arr);
            Array.Sort(Arr2);

            output.Write(Answer());
            output.Flush();
        }

        static public int Answer()
        {
            int a = N / 6;
            int b = N % 6;
            int price = 0;
            if (a > 0)
            {
                price += Arr[0] * a;
            }
            if (b > 0)
            {
                price += Arr2[0] * b;
            }
            if (price > Arr[0] * (N / 6 + 1))
            {
                price = Arr[0] * (N / 6 + 1);
            }
            return price;
        }
    }
}