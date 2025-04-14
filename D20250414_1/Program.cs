using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D20250414_1
{
    class Queue
    {
        private int[] _container = new int[10004];
        int _top = -1;
        int _size = 0;
        int lastValue;

        public void Push(int x)
        {
            _container[++_top] = x;
            lastValue = x;
            ++_size;
        }

        public int Pop()
        {
            if (_top == -1)
            {
                return -1;
            }

            --_size;
            return _container[_top--];
        }

        public int Size() => _size;

        public int Empty()
        {
            return (_size == 0) ? 1 : 0;
        }
        public int Front()
        {
            if (_size == 0)
            {
                return -1;
            }

            return _container[0];
        }

        public int Back()
        {
            if (_size == 0)
            {
                return -1;
            }

            return lastValue;
        }

    }


    class Program
    {
        static int N;
        
        static Queue qu = new Queue();    

        static void Main()
        {
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; ++i)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "push":
                        int operand = int.Parse(command[1]);
                        qu.Push(operand);
                        break;
                    case "pop":
                        Console.WriteLine(qu.Pop());
                        break;
                    case "size":
                        Console.WriteLine(qu.Size());
                        break;
                    case "front":
                        Console.WriteLine(qu.Front());
                        break;
                    case "empty":
                        Console.WriteLine(qu.Empty());
                        break;
                    case "back":
                        Console.WriteLine(qu.Back());
                        break;
                }
            }

        }
    }
}
