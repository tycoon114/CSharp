using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    public class DynamicArray<T>
    {
        protected T[] data;
        protected int count;

        //c#에서 할 경우는 생성자를 쓰는 것을 추천
        public DynamicArray()
        {
            data = new T[10];
            count = 0;
        }

        public void Add(T newData)
        {
            if (count >= data.Length)
            {
                //빠르다 -> 하나씩 복사 하지 않고 한방에 처리
                T[] newArray = new T[data.Length * 2];
                Array.Copy(data, newArray, data.Length);
                data = newArray;
            }
            data[count] = newData;
            count++;
        }

        public void RemoveAt(int index)
        {
            //ArraySegment<Object>

            for (int i = index + 1; i < data.Length; ++i)
            {
                data[i - 1] = data[i];
            }
            count--;
        }

        public T this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                data[i] = value;
            }
        }
        public int Count { 
            get { return count; }
        }

    }



    internal class Day23_1
    {
        static void Main2(string[] args)
        {
            //C#에서 ArrayList는 쓰지 말것, 그냥 Lsit<T> 사용
            DynamicArray<int> dyA = new DynamicArray<int>();
            dyA.Add(1);
            dyA.Add(2);
            dyA.Add(3);
            dyA.Add(4);
            dyA.Add(1);
            dyA.Add(2);
            dyA.Add(3);
            dyA.Add(4);
            dyA.Add(1);
            dyA.Add(2);
            dyA.Add(3);
            dyA.Add(4);
            dyA.Add(1);
            dyA.Add(2);
            dyA.Add(3);
            dyA.Add(4);

            dyA.RemoveAt(0);

            for (int i = 0; i < dyA.Count; ++i) { 
                Console.WriteLine(dyA[i]);
            }

        }

    }
}
