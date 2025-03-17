using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day35Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 실제로 쓸때는  Any말고 주소로 적을것 192.168.0.31
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000);
            //192.168.0.22
            ListenSocket.Bind(listenEndPoint);

            // 너무 큰 숫자로 잡지 말것
            ListenSocket.Listen(10);

            bool isRunning = true;
            int num1;
            int num2;
            string calOperator;
            int result;
            string sendM;

            while (isRunning)
            {
                //동기 방식, 블록킹
                Socket clientSocket = ListenSocket.Accept();

                byte[] buffer = new byte[1024];
                byte[] buffer2 = new byte[1024];
                int receiveLength = clientSocket.Receive(buffer);   //return 값이 int (배열의 길이) -> 값이 0이면 close, 보다 작으면 에러

                if (receiveLength <= 0)
                {
                    //close
                    //에러
                    clientSocket.Close();

                    isRunning = false;
                }

                string[] recvMessage = Encoding.UTF8.GetString(buffer).Split(' ');
                num1 = int.Parse(recvMessage[0]);
                calOperator = recvMessage[1];
                num2 = int.Parse(recvMessage[2]);

                switch (calOperator)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    default:
                        Console.WriteLine("지원하지 않는 연산자입니다.");
                        return;
                }

                sendM = Encoding.UTF8.GetString(buffer) + " = " + result;
                buffer2 = Encoding.UTF8.GetBytes(sendM);

                int sendLength = clientSocket.Send(buffer2);  // return 값이 길이

                if (sendLength <= 0) {
                    //에러 - 통신이 안됨
                    clientSocket.Close();
                    isRunning = false;
                }
                //keep alive time
                //Console.WriteLine(Encoding.UTF8.GetString(buffer2));
                clientSocket.Close();
            }

            ListenSocket.Close();
        }
    }
}
