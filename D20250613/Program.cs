using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Security.AccessControl;

namespace D20250613
{
    internal class Program
    {
        public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput()));
        public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput()));

        static long X;

        static List<long> numbers = new();
        static void Main(string[] args)
        {
            X = long.Parse(input.ReadLine()!);

            MakeSquareNumber();

            output.Write(Answer(X));
            output.Flush();
        }

        static void MakeSquareNumber()
        {
            int Limit = 50000;
            bool[] isNotPrime = new bool[Limit + 1];
            for (int i = 2; i <= Limit; i++)
            {
                if (isNotPrime[i]) continue;
                numbers.Add((long)i * i);  // 소수의 제곱만 추가

                for (int j = i * 2; j <= Limit; j += i)
                {
                    isNotPrime[j] = true;
                }
            }
        }


        //이분 탐색
        public static long Answer(long x)
        {
            long left = 1, right = 2*X;
            long answer = 0;

            while(left<=right)
            {
                long mid = (left + right) / 2;
                long count = NonSquareFree(mid, 0, 1, 1);
                long FreeCount = mid - count;
                if (FreeCount < x)
                {
                    left = mid + 1;
                }
                else
                {
                    answer = mid;

                    right = mid - 1;
                }
            }
            return answer;
        }


        //포함 배제
        public static long NonSquareFree(long x, int idx, long lcm, int sign)
        {
            long count = 0;
            for(int i = idx; i < numbers.Count; i++)
            {
                if (numbers[i] >x / lcm) break; //lcm이 x보다 크면 더 이상 진행할 필요 없음
                long nextLcm = LCM(lcm, numbers[i]);
                if (nextLcm > x) break;
                count += sign * (x / nextLcm);
                count += NonSquareFree(x, i + 1, nextLcm, -sign);
            }

            return count;
        }


        //최소 공배수
        public static long LCM(long a, long b)
        {
            return a / GCD(a, b) * b;
        }


        //최대 공약수
        public static long GCD(long a, long b)
        {

            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
