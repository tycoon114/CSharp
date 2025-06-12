using System.Collections.Generic;

internal class Program
{
    static int N;
    static int[] Arr = new int[1000];
    static List<int> list = new List<int>();
    public static readonly StreamReader input = new(new
    BufferedStream(Console.OpenStandardInput()));
    public static readonly StreamWriter output = new(new
    BufferedStream(Console.OpenStandardOutput()));

    static void Main(string[] args)
    {
        N = int.Parse(input.ReadLine());
        string[] tokens = input.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            Arr[i] = int.Parse(tokens[i]);
            list.Add(Arr[i]);

        }
        list.Sort();
        //for (int i = 0; i < list.Count; i++)
        //{
        //}

        output.Write(AtmTime(list));

        output.Flush();
    }


    private static int AtmTime(List<int> people)
    {
        int[] addTime = new int[people.Count];

        addTime[0] = people[0];
        int result2 = addTime[0];
        for (int i = 1; i < people.Count; i++)
        { 
            addTime[i] = addTime[i - 1] + people[i];
            result2 += addTime[i];
        }

        return result2;
    }
}