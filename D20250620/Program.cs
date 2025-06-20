namespace D20250620
{
    internal class Program
    {
        static int N, M;
        static long[] Arr;

        static string numb;

        public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput()));


        static void Main(string[] args)
        {
            //N = int.Parse(input.ReadLine());
            numb = input.ReadLine();

            Arr = new long[numb.Length];

            for (int i=0; i<numb.Length; i++)
            {
                Arr[i] = long.Parse(numb[i].ToString());
            }

            Array.Sort(Arr);
            Array.Reverse(Arr);

            //output.WriteLine(M);
            output.Flush();
        }
    }
}