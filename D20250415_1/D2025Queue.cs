using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace D20250415_1
{

    class Queue 
    {
        static int size = 0;
        static int front = 0;
        static int back = 0;
        static int returnValue;
        static int[] qu = new int[10004];

        public void Enqueue(int value)
        {
            qu[back] = value;
            back++;
            size++;

            if ( )
            {
                while (front > back)
                {
                    back = 0;
                }
            }
        }

        public int Dequeue() 
        {
            if (Empty() == 0)
            {
                return 0;
            }
            returnValue = qu[front];
            front++;
            size--;
            return returnValue;
        }

        public int Empty() {
            if (front == back)
                return 0;
            else
                return 1;
        }


    }


    internal class D2025Queue
    {


    }
}
