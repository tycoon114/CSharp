using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day36Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
            serverSocket.Connect(serverEndPoint);

            byte[] buffer;
            String message = "안녕하세요";
            buffer = Encoding.UTF8.GetBytes(message);

            serverSocket.Send(buffer, 0 ,buffer.Length, SocketFlags.None);

            byte[] recieveBuffer = new byte[1048];
            serverSocket.Receive(recieveBuffer);

            Console.WriteLine(Encoding.UTF8.GetString(recieveBuffer));

            serverSocket.Close();
        }
    }
}
