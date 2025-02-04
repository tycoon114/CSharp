namespace Day08
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array52 = new int[52];
            int[] array8 = new int[8];
            for (int i = 0; i < 52; i++)
            {
                array52[i] = i+1;
            }

            Random rand = new Random();


            for (int i = 0; i < 8; i++)
            {
                int index = rand.Next(52 - i); // 남은 요소 개수 내에서 랜덤 선택
                array8[i] = array52[index];

                // 선택된 요소를 배열 끝으로 이동하여 중복 방지 (Fisher-Yates Shuffle 방식)
                array52[index] = array52[51 - i];
            }

            Console.WriteLine("선택된 숫자: " + string.Join(", ", array8));


        }
    }
}
