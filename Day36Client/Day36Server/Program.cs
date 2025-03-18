using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day36Server
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isRunning = true;


            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            listenSocket.Bind(serverEndPoint);
            listenSocket.Listen(10);

            while (isRunning) { 
                Socket clientSocket = listenSocket.Accept();
                byte[] buffer = new byte[1024];
                int recieveLength = clientSocket.Receive(buffer);

                Console.WriteLine(Encoding.UTF8.GetString(buffer));

                byte[] sendBuffer;
                if (recieveLength > 0) {
                    String sendMessage = "반가워요";
                    sendBuffer = Encoding.UTF8.GetBytes(sendMessage);
                    clientSocket.Send(sendBuffer);
                }
                clientSocket.Close();
            }

            listenSocket.Close();
        }
    }
}
