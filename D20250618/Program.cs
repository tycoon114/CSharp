using System.Reflection;
using System.Text;

namespace D20250618
{
    internal class Program
    {
        static int N;    
        static string M;    


        public static readonly StreamReader input = new(new
            BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new
            BufferedStream(Console.OpenStandardOutput()));
        static void Main(string[] args)
        {
            N = int.Parse(input.ReadLine());
            M = input.ReadLine();
            int sum = 0;

            for(int i=0; i<M.Length; i++)
            {
                sum+= int.Parse(M[i].ToString());
            }

            output.WriteLine(sum);
            output.Flush();
        }
    }
}
