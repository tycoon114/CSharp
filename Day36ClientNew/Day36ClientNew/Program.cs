﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Day36ClientNew
{
    class Program
    {
        static Socket clientSocket;

        static void SendPacket(Socket toSocket, string message)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            ushort length = (ushort)IPAddress.HostToNetworkOrder((short)messageBuffer.Length);

            byte[] headerBuffer = BitConverter.GetBytes(length);

            byte[] packetBuffer = new byte[headerBuffer.Length + messageBuffer.Length];
            Buffer.BlockCopy(headerBuffer, 0, packetBuffer, 0, headerBuffer.Length);
            Buffer.BlockCopy(messageBuffer, 0, packetBuffer, headerBuffer.Length, messageBuffer.Length);

            int SendLength = toSocket.Send(packetBuffer, packetBuffer.Length, SocketFlags.None);

        }

        static void RecvPacket(Socket toSocket, out string jsonString)
        {
            byte[] lengthBuffer = new byte[2];

            int RecvLength = clientSocket.Receive(lengthBuffer, 2, SocketFlags.None);
            ushort length = BitConverter.ToUInt16(lengthBuffer, 0);
            length = (ushort)IPAddress.NetworkToHostOrder((short)length);
            byte[] recvBuffer = new byte[4096];
            RecvLength = clientSocket.Receive(recvBuffer, length, SocketFlags.None);

            jsonString = Encoding.UTF8.GetString(recvBuffer);
        }

        static void Main(string[] args)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);

            clientSocket.Connect(listenEndPoint);

            JObject result = new JObject();
            //result.Add("code", "Login");
            //result.Add("id", "htk008");
            //result.Add("password", "1235");
            //SendPacket(clientSocket, result.ToString());

            result.Add("code", "Signup");
            result.Add("id", "robot2");
            result.Add("password", "1234");
            result.Add("name", "로봇2");
            result.Add("email", "robot@a.com");
            SendPacket(clientSocket, result.ToString());

            string JsonString;
            RecvPacket(clientSocket, out JsonString);

            Console.WriteLine(JsonString);


            clientSocket.Close();
        }
    }
}
