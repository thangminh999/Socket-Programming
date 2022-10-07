using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_2011438_Bai5_Client
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        static void Main(string[] args)
        {
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(serverEndPoint);
            if (serverSocket.Connected)
            {
                byte[] buff = new byte[BUFFER_SIZE];
                Console.WriteLine("Data send to server");
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                Console.ReadKey();
                try
                {
                    serverSocket.Connect(serverEndPoint);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Khong the ket noi den server");
                    return;
                }
                while (true)
                {
                    str = Console.ReadLine();
                    buff = Encoding.ASCII.GetBytes(str);
                    serverSocket.Send(buff, 0, buff.Length, SocketFlags.None);
                    buff = new byte[1024];
                    byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                    Console.WriteLine(str);
                }

            }
        }
    }
}
