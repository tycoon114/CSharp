namespace D20250612
{
    internal class Program
    {
        public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput()));

        static long  A, B, C;

        static int[] coins = new int[100];

        static int[] dp;
        static int[] weight = new int[1000000];
        static int[] value = new int[1000];


        static void Main(string[] args)
        {

            //K = int.Parse(input.ReadLine());
            long[] inputs = Array.ConvertAll(input.ReadLine().Split(), long.Parse);
            A = inputs[0];
            B = inputs[1];
            C = inputs[2];

            //Ans(A, B);

            output.Write(Ans(A, B));
            output.Flush();
        }

        static long Ans(long a, long b)
        {

            if (b == 1) return a % C;

            long temp = Ans(a, b / 2);
            temp = (temp * temp) % C;

            if (b % 2 == 0)
                return temp;
            else
                return (temp * a) % C;
        }
    }
}
