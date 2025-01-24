namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num;


            //Console.WriteLine("슷자 입력 : ");

            //num = Console.ReadLine();

            //int number = int.Parse(num);     

            //Console.WriteLine(number);

            //if (number % 4 == 0 && number !=0)
            //{
            //    Console.WriteLine("4이 배수");
            //}
            //else {
            //    Console.WriteLine("4의 배수 아님");
            //}


            //int[] number = new int[10];

            //for (int i = 0; i < number.Length; i++)
            //{
            //    Console.WriteLine("슷자 입력 : ");

            //    number[i] = int.Parse(Console.ReadLine());
            //}



            //int[] number = new int[5];

            //for (int i = 0; i < number.Length; i++)
            //{
            //    Console.Write("*");

            //}

            int hap = 0;
            int addNum = 0;
            int addHolNum = 0;


            for (int i = 1; i < 101; i++)
            {
                hap += i;
                if (i % 2 == 0)
                {
                    addNum += i;
                } else
                {
                    addHolNum += i;
                }
            
            }

            Console.WriteLine(hap);

            Console.WriteLine(addNum);

            Console.WriteLine(addHolNum);


        }
    }
}
