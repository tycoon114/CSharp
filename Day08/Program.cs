namespace Day08
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array52 = new int[52];
            for (int i = 0; i < 52; i++)
            {
                array52[i] = i+1;
            }

            Random rand = new Random();

            int[] selectedNumbers = array52.OrderBy(x => rand.Next()).Take(8).ToArray();

            Console.WriteLine("선택된 숫자: " + string.Join(", ", selectedNumbers));


        }
    }
}
