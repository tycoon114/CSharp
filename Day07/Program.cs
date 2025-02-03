using System.Reflection.Metadata.Ecma335;

namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] box = new int[5, 5];

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 5; j > 0; j--)
                {
                    if (i >= j)
                    {
                        Console.Write("*");

                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine("");


            }



            int[] dt = new int[10];

            for (int k = 0; k < dt.Length; k++)
            {
                dt[k] = k + 1;

                Console.Write(dt[k]);
                if (k < dt.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine("");
            string s = "Asdf asdf";

            //for (int l = 0; l < dt.Length ; l++){
            //    Console.WriteLine(s[l]);
            //}
            int temp = 1;
            int[,] data = new int[10, 10];
            for (int i = 0; i < 10; i++) {

                for (int j = 0; j < 10; j++)
                {
                    data[i, j] = temp;
                    Console.Write(temp + "\t");
                    temp++;
                }
                Console.WriteLine("");

            }

            int A, B;



            Console.WriteLine(multiple(3, 4));

        }
    

        static int multiple(int a, int b) {
            
            return a * b;
    
        }
    }

}
