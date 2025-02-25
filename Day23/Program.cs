using static System.Formats.Asn1.AsnWriter;

namespace Day23
{
    internal class Program
    {
        static void ttt(string[] args)
        {

            StreamReader sr = null;
            List<string> sList = new List<string>();

            sr = new StreamReader("temp.txt");
            while (!sr.EndOfStream)
            {
                sList.Add(sr.ReadLine());
            }
            sr.Close();


            sList.RemoveAt(0);

            for (int i = 0; i < sList.Count; i++)
            {
                Console.WriteLine(sList[i]);
            }
            Console.WriteLine(sList.Count);
        }

    }
}
