﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day40_Thread
{
    class Program
    {
        static Object _lock = new Object(); //동기화 객체
                                                //스핀락 - 한번쯤은 구현 해 볼것
                                                //Interlocked.CompareExchange()
        //atomic, 공유영역 작업은 원자성, 중간 끊지 말라고
        //나 끝날때까지 다 하지마
        static int Money = 0;

        static void Add()
        {
            for (int i = 0; i < 100000000; ++i)
            {
                lock (_lock)
                {
                    Money++;

                }
            }

        }

        static void Remove()
        {
            for (int i = 0; i < 100000000; ++i)
            {
                lock (_lock)
                {
                    Money--;
                }
            }
        }

        //foreground, main thread 종료 되면 나머지 쓰레드는 다 종료
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Remove));

            thread1.IsBackground = true;
            thread1.Start();
            thread2.IsBackground = true;
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(Money);
        }
    }
}
