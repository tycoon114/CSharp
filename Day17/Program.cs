﻿using System;
using System.Net.Sockets;
using System.Text;

namespace Day17
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Engine.Instance.Init();

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();
        }



    }
}
