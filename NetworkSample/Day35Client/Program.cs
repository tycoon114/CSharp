using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day35Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);  //루프백 - 내 자신(127.0.0.1)
            //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
            serverSocket.Connect(serverEndPoint);


            byte[] buffer;
            String message = "100 + 200";
            buffer = Encoding.UTF8.GetBytes(message);

            int sendLength = serverSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);

            // 다 보내지 못했을 경우 처리
            //while (sendLength < buffer.Length)
            //{
            //    int sendLength = serverSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            //}


            byte[] buffer2 = new byte[1024];

            int ReceiveLength = serverSocket.Receive(buffer2);
            Console.WriteLine(Encoding.UTF8.GetString(buffer2));

            serverSocket.Close();
        }
    }
}
