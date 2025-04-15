using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250415_1
{
    class Stack
    {

        static int top = -1;
        static int size = 0;       //size는 따로 이렇게 선언 해주는 것이 가독성 측면에서 더 좋다.
        static int[] st = new int[10004];

        public void Push(int value)
        {

            st[++top] = value;
            ++size;
        }
        public int Pop()
        {
            if (top == -1)
            {
                return -1;
            }
            --size;
            return st[top--];
        }

        public int Peek() 
        {
            if (top == -1)
            {
                return -1;
            }
            return st[top];
        }

        public int Size() { 
            if(size == 0)
                return 0;

            return size;
        
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {



        }
    }
}
