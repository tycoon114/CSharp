using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day36UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 6000);

            serverSocket.Bind(serverEndPoint);

            //이때 보내주는 크기가 1024보다 크면 못받음 -> UDP는 쪼개서 받지 않기 때문
            byte[] buffer = new byte[1024];
            EndPoint clientEndpoint = (EndPoint)serverEndPoint;
            int RecvLength = serverSocket.ReceiveFrom(buffer, ref clientEndpoint);

            int SendLength = serverSocket.SendTo(buffer, clientEndpoint);
            


            //serverSocket.Close();
        }
    }
}
