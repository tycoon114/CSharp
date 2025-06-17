namespace D20250616
{
    internal class Program
    {
        static int K, N;
        static int min = int.MaxValue;
        public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput()));

        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(input.ReadLine().Split(), int.Parse);
            K = inputs[0];
            N = inputs[1];




            output.Write(min);
            output.Flush();
        }


        static int AnswerDp()
        {
            //배열? 숫자 받을것을 DP 돌리기
            //최소 개수를 구해야됨
            //모든 경우의 수 중 가장 작은 값


            // 불가능할 경우 -1



            return min;
        }

    }
}
