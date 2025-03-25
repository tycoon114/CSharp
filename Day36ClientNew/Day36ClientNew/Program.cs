using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day36ClientNew
{
    class Program
    {

        static Socket clientSocket;
        struct Packet
        {
            //[][]
            string id; //20
            //[][]
            string message; //40
        }

        static void ChatInput()
        {
            while (true)
            {
                string InputChat;
                Console.Write("채팅 : ");
                InputChat = Console.ReadLine();

                string jsonString = "{\"id\" : \"asdf\",  \"message\" : \"" + InputChat + ".\"}";
                byte[] message = Encoding.UTF8.GetBytes(jsonString);
                ushort length = (ushort)message.Length;

                byte[] lengthBuffer = new byte[2];
                lengthBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)length));

                byte[] buffer = new byte[2 + length];

                Buffer.BlockCopy(lengthBuffer, 0, buffer, 0, 2);
                Buffer.BlockCopy(message, 0, buffer, 2, length);

                int SendLength = clientSocket.Send(buffer, buffer.Length, SocketFlags.None);
            }
        }


        static void RecvThread()
        {
            while (true)
            {
                byte[] lengthBuffer = new byte[2];

                int RecvLength = clientSocket.Receive(lengthBuffer, 2, SocketFlags.None);
                ushort length = BitConverter.ToUInt16(lengthBuffer, 0);
                length = (ushort)IPAddress.NetworkToHostOrder((short)length);
                byte[] recvBuffer = new byte[4096];
                RecvLength = clientSocket.Receive(recvBuffer, length, SocketFlags.None);

                string JsonString = Encoding.UTF8.GetString(recvBuffer);

                Console.WriteLine(JsonString);
            }
        }


        static void Main(string[] args)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
            clientSocket.Connect(listenEndPoint);

            Thread chatInputThread = new Thread(new ThreadStart(ChatInput));
            Thread recvThread = new Thread(new ThreadStart(RecvThread));


            chatInputThread.IsBackground = true;
            chatInputThread.Start();            //쓰레드가 실제로 시작되었다는 의미가 아닌 OS에 등록했다는 의미, 쓰레드는 언제 시작될지 모름?
            recvThread.IsBackground = true;
            recvThread.Start();


            chatInputThread.Join();
            recvThread.Join();

            clientSocket.Close();
        }
    }
}
