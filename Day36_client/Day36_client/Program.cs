﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day36_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            clientSocket.Connect(listenEndPoint);

            FileStream fsOutput = new FileStream("networkTestCopy.webp", FileMode.Create);
            int RecvLength = 0;
            do
            {
                byte[] buffer = new byte[4096 * 4 * 10];
                RecvLength = clientSocket.Receive(buffer);
                fsOutput.Write(buffer, 0, RecvLength);
            } while (RecvLength > 0);

            clientSocket.Close();
            fsOutput.Close();
        }
    }
}
