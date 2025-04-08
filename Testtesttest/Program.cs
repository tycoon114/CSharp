using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testtesttest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> lst = new List<int>();
            for (int elem = 1; elem <= 10; elem++)
            {
                lst.Add(elem);
            }
            asdasd.asdf();
            //Console.WriteLine(LowerBound(lst, 5) + " 번째 인덱스");
            //Console.WriteLine(UpperBound(lst, 5) + " 번째 인덱스");
        }

        public static bool LinesrSearch(List<int> list, int key)
        {
            foreach (int i in list)
            {
                if (i == key)
                    return true;
            }
            return false;
        }

        public static bool BinarySearch(List<int> list, int key)
        {
            // 주어진 검색 범위에서 중간값 찾기
            //중간값과 키 비교 
            //key보다 큰경우  => 검색 범위를 줄인다 [왼쪽 탐색]
            //같은경우 => 찾음 
            //key보다 중간값이 작은경우 => 검색 범위를 줄인다 [오른쪽 탐색]

            //시작과 끝

            int start = 0;
            int end = list.Count;

            while (start < end)
            {

                int middle = (start + end) / 2;  // start + (end - start) * 0.5;

                if (list[middle] == key)
                {
                    return true;
                }
                else if (list[middle] > key)
                {
                    end = middle;
                }
                else if (list[middle] < key)
                {
                    start = middle + 1;
                }
            }


            return false;
        }


        public static int LowerBound(List<int> list, int key)
        {
            //주어진 값보다 크거나 같은 첫번째 원소의 인덱스를 반환하는 함수

            int start = 0;
            int end = list.Count;

            while (start < end)
            {
                int middle = (start + end) / 2;

                //키와 중간값 비교 
                //같으면 -> 검색 범위 왼쪽으로
                //중간값보다 작으면 범위를 왼쪽으로
                //중간값 보다 크면 검색 범위 오른쪽
                if (key <= list[middle])
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }
            return start;
        }

        public static int UpperBound(List<int> list, int key)
        {
            //주어진 값보다 큰 첫번째 원소의 인덱스를 반환하는 함수

            int start = 0;
            int end = list.Count;
            int result = -1;
            while (start < end)
            {
                int middle = (start + end)/2;

                //키와 중간값 비교 
                //같으면 -> 검색 범위 오른쪽
                //중간값보다 작으면 범위를 왼쪽으로
                //중간값 보다 크면 검색 범위 오른쪽


                if(key >= list[middle])
                {
                    start = middle + 1;
                }
                else 
                {
                    result = middle;
                    end = middle;
                }
            }
            return result;
        }


    }

}
